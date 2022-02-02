using System;
using System.IO;
using System.Threading.Tasks;

namespace SegmentedDownloader.Objects
{
    public class RemoteFileInfo : IAsyncDisposable
    {
        
        public string Name { get; set; }
        
        public int Id { get; set; }
        
        public string ContentType { get; internal set; }

        public long Size { get; internal set; }
        
        public DateTimeOffset LastModified { get; internal set; }

        public Stream BaseStream { get; internal set; }
        
        public async ValueTask DisposeAsync()
        {
            await BaseStream.DisposeAsync();
        }
    }
}