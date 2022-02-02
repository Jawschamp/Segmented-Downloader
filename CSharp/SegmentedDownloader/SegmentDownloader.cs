using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

using SegmentedDownloader.Objects;
using SegmentedDownloader.Protocol;

namespace SegmentedDownloader
{
    public class SegmentDownloader : IDisposable
    {

        public IWebProxy Proxy;
        public ICredentials Credentials;
        public IEnumerable<X509Certificate> Collection;
        public long Timeout;
        public int ThreadCount;

        private ProtocolBase _protocol;

        private readonly SemaphoreSlim _lock;
        private readonly HttpClient _client;

        
        public delegate Task SegmentDownloadEventArgs(RemoteFileInfo remoteFileInfo);
        
        public event SegmentDownloadEventArgs SegmentDownloaded;
        
        public SegmentDownloader(
            IWebProxy proxy = null, 
            ICredentials credentials = null, 
            IEnumerable<X509Certificate> collection = null, 
            int threadCount = 0,
            long timeout = 50000L)
        {
            Proxy = proxy;
            Credentials = credentials;
            Collection = collection;
            ThreadCount = threadCount == 0 ? Environment.ProcessorCount / 2 : threadCount;
            Timeout = timeout;
            
            _client = new HttpClient();
            _lock = new SemaphoreSlim(ThreadCount, ThreadCount);
        }

        public async Task<IEnumerable<RemoteFileInfo>> DownloadSegmentsAsync(string uri, int count = 4000, ProtocolOptions options = null, CancellationToken token = default)
        {
            _protocol = new HttpProtocol(Timeout, options);

            var uris = GetSegmentUris(uri, count).ToArray();
            var tasks = new List<Task>();
            var segments = new List<RemoteFileInfo>();
            var regex = new Regex("seg-(\\d+)");
            
            foreach (var url in uris)
            {
                await _lock.WaitAsync(token);
                
                var task = await Task.Factory.StartNew(async () =>
                {
                    try
                    {
                        var segment = await DownloadSegmentAsync(url, token);

                        if (segment == null)
                        {
                            _lock.Release();
                            return;
                        }

                        var segmentIdMatch = regex.Match(segment.Name);
                        var segmentId = int.Parse(segmentIdMatch.Value.Split("-")[1]);
                        segment.Id = segmentId;
                        segments.Add(segment);
                        SegmentDownloaded?.Invoke(segment);
                        _lock.Release();
                    }
                    catch
                    {
                        _lock.Release();
                    }
                }, token);
                
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray(), token);

            return segments;
        }

        public Task<IEnumerable<RemoteFileInfo>> DownloadSegmentsAsync(Uri uri, int count = 4000,
            ProtocolOptions options = null, CancellationToken token = default)
            => DownloadSegmentsAsync(uri.ToString(), count, options, token);

        public Task<RemoteFileInfo> DownloadSegmentAsync(Uri uri, CancellationToken token = default) => _protocol.GetSegmentStreamAsync(uri, token);

        public IEnumerable<Uri> GetSegmentUris(string uri, int count)
        {
            var segments = new List<Uri>();
            var regex = new Regex("seg-(\\d+)");
            
            for (var i = 0; i <= count; i++)
            {
                var match = regex.Match(uri);

                if (match.Success)
                {
                    var url = new Uri(uri.Replace(match.Value, $"seg-{i}"));
                    segments.Add(url);   
                }
            }
            
            return segments;
        }

        public void Dispose() => _client.Dispose();
        
    }
}