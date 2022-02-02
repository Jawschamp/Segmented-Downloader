using System;

namespace SegmentedDownloader.Exceptions
{
    public class SegmentDownloadException : Exception
    {

        public readonly Uri Uri;
        
        public SegmentDownloadException(Uri uri, string message) : base(message)
        {
            Uri = uri;
        }
        
    }
}