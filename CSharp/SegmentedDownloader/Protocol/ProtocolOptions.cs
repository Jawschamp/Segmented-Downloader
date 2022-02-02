using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using SegmentedDownloader.Enums;

namespace SegmentedDownloader.Protocol
{
    public class ProtocolOptions
    {

        public ICredentials Credentials;
        public IEnumerable<X509Certificate> Certificates;
        public EncryptionType CryptoType = EncryptionType.NONE;
        public byte[] Key;
        public long MinimalReceivableBytes = 11111L;

    }
}