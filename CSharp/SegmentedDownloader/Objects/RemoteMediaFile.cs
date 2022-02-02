using System;
using FFmpeg.Net.Data;
using FFmpeg.Net.Enums;
using SegmentedDownloader.Protocol;

namespace SegmentedDownloader.Objects
{
    public class RemoteMediaFile
    {

        public readonly int Id;
        public readonly string FilePath;
        
        public RemoteMediaFile(int segmentId, string filePath)
        {
            Id = segmentId;
            FilePath = filePath;
        }

        public MediaFile GetMediaFile() => FilePath != null ? new(FilePath) : throw new Exception("File Path is null");

    }
}