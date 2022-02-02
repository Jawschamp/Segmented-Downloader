using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using SegmentedDownloader.Enums;
using SegmentedDownloader.Exceptions;
using SegmentedDownloader.Objects;
using SegmentedDownloader.Util;

namespace SegmentedDownloader.Protocol
{
    public sealed class HttpProtocol : ProtocolBase
    {

        private HttpResponseMessage _response;
        private readonly Regex _regex;
        private readonly HttpClient _client;
        
        internal HttpProtocol(long timeout, ProtocolOptions options) : base(options)
        {
            var httpClientHandler = new HttpClientHandler();

            if (options != null && options.Certificates != null)
                httpClientHandler.Credentials = options.Credentials;

            if (options != null && options.Certificates != null)
                httpClientHandler.ClientCertificates.AddRange(options.Certificates.ToArray());

            _regex = new("seg+-(\\d)+-.*(\\d)");
            _client = new HttpClient();
            
            if (timeout != 0L)
                _client.Timeout = TimeSpan.FromMilliseconds(timeout);
            
            _client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            _client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.99 Safari/537.36");
        }
        
        public override async Task<RemoteFileInfo> GetSegmentStreamAsync(Uri uri, CancellationToken token = default)
        {
            try
            {
                _response = await _client.GetAsync(uri, token);

                var stream = await _response.Content.ReadAsStreamAsync(token);

                var fileInfo = GetFileInfo();

                if (fileInfo.Size < Options.MinimalReceivableBytes)
                    return null;

                var match = _regex.Match(uri.ToString());

                if (!match.Success)
                    return null;
                //    throw new SegmentDownloadException(uri, "Unrecognized segment Id");

                fileInfo.Name = match.Value;
                fileInfo.BaseStream = CreateStream(stream); /* TODO Temporary Data for Testing will cleanup later */

                return fileInfo;
            }
            catch
            {
                throw new SegmentDownloadException(uri,
                    "Request did not return a successful status code and will therefore be terminated.");
            }

        }

        private Stream CreateStream(Stream stream)
        {
            if (Options.CryptoType == EncryptionType.AES)
            {
                var buffer = stream.ReadToEnd();
                using var aes = Aes.Create();
                using var decrypt = aes.CreateDecryptor(Options.Key, Options.Key);
                var read = decrypt.TransformFinalBlock(buffer, 0, buffer.Length);
                return new MemoryStream(read);
            }

            return stream;
        }
        
        private RemoteFileInfo GetFileInfo()
            => new()
            {
                Size = _response.Content.Headers.ContentLength ?? 0L,
                ContentType = _response.Content.Headers.ContentType?.MediaType,
                LastModified = _response.Content.Headers.LastModified ?? DateTimeOffset.Now
            };

        public override void Dispose() => _client.Dispose();
        
    }
}