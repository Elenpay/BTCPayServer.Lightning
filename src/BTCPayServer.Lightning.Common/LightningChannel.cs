using NBitcoin;

namespace BTCPayServer.Lightning
{
    public class LightningChannel
    {
        public PubKey RemoteNode { get; set; }
        public bool IsPublic { get; set; }
        public bool IsActive { get; set; }
        public LightMoney Capacity { get; set; }
        public LightMoney LocalBalance { get; set; }
        public LightMoney RemoteBalance { get; set; }
        public OutPoint ChannelPoint { get; set; }
        // The unique identifier of the channel.
        public string ChanId { get; set; }
    }
}
