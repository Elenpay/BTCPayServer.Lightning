using System;
using System.Collections.Generic;

namespace BTCPayServer.Lightning;

public class LightningInvoice
{
    public string Id { get; set; }
    public string PaymentHash { get; set; }
    public string Preimage { get; set; }
    public LightningInvoiceStatus Status { get; set; }
    public string BOLT11 { get; set; }
    public DateTimeOffset? PaidAt { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
    public LightMoney Amount { get; set; }
    public LightMoney AmountReceived { get; set; }
    public Dictionary<ulong, string> CustomRecords { get; set; }
    public List<RouteHints> RouteHints { get; set; }
}

public class RouteHints
{
    public List<HopHint> Hints { get; set; }
}

public class HopHint
{
    // The public key of the node at the start of the channel.
    public string NodeId { get; set; }

    // The unique identifier of the channel.
    public string ChanId { get; set; }

    // The base fee of the channel denominated in millisatoshis.
    public long FeeBaseMsat { get; set; }

    // The fee rate of the channel for sending one satoshi across it denominated in millionths of a satoshi.
    public long FeeProportionalMillionths { get; set; }

    // The time-lock delta of the channel.
    public long CltvExpiryDelta { get; set; }
}

