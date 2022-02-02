using System;
using System.Threading;
using System.Threading.Tasks;
using SegmentedDownloader.Objects;

namespace SegmentedDownloader.Protocol
{
    public abstract class ProtocolBase : IDisposable
    {

        internal readonly ProtocolOptions Options;

        public ProtocolBase(ProtocolOptions options)
        {
            Options = options;
        }

        public abstract Task<RemoteFileInfo> GetSegmentStreamAsync(Uri uri, CancellationToken token = default);
        
        public abstract void Dispose();
    }
}