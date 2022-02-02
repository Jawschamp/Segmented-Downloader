using System;
using System.Threading;
using System.Threading.Tasks;
using SegmentedDownloader.Objects;

namespace SegmentedDownloader.Protocol
{
    public class FtpProtocol : ProtocolBase
    {
        public FtpProtocol(ProtocolOptions options) : base(options)
        { }
        
        public override Task<RemoteFileInfo> GetSegmentStreamAsync(Uri uri, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}