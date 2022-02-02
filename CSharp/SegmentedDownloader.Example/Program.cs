using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using FFmpeg.Net;
using FFmpeg.Net.Enums;

using SegmentedDownloader.Objects;
using SegmentedDownloader.Protocol;

namespace SegmentedDownloader.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Directory.CreateDirectory("Movie");
            
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var segmentOptions = new ProtocolOptions();
            var segmentDownloader = new SegmentDownloader(threadCount: 8);
            var remoteMediaFiles = new List<RemoteMediaFile>();
            var clientOptions = new FFmpegClientOptions("./ffmpeg.exe", false);
            var client = new FFmpegClient(clientOptions);
            var movieUrl = new Uri("LINK-TO-SEGMENT");

            segmentDownloader.SegmentDownloaded += async (file) =>
            {
                var uri = Path.Combine(Directory.GetCurrentDirectory(), $"Movie/{file.Name}.mp4");
                await using var fileStream = File.Open(uri, FileMode.OpenOrCreate);
                await file.BaseStream.CopyToAsync(fileStream);
                remoteMediaFiles.Add(new RemoteMediaFile(file.Id, uri));
                Console.WriteLine($"Segment ID: {file.Name}, Size: {file.Size}");
                await file.DisposeAsync();
            };
            
           await segmentDownloader.DownloadSegmentsAsync(movieUrl, 80, segmentOptions);
            
            var mediaFiles = remoteMediaFiles
                .OrderBy(file => file.Id)
                .Select(file => file.GetMediaFile())
                .ToList();
            
            await client.MergeAsync(mediaFiles, "Spongebob", VideoType.MP4, "./");
            
            stopWatch.Stop();
            
            var elapsed = DateTimeOffset.FromUnixTimeMilliseconds(stopWatch.ElapsedMilliseconds);
            
            Console.WriteLine($"Downloading {remoteMediaFiles.Count} segments with {segmentDownloader.ThreadCount} threads took {elapsed.Minute} Minutes, {elapsed.Second} Seconds");
        }
    }
}