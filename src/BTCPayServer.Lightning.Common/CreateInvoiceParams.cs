using System;
using System.Collections.Generic;
using System.Text;
using NBitcoin;
using NBitcoin.Crypto;

namespace BTCPayServer.Lightning
{
    public class CreateInvoiceParams
    {
        public CreateInvoiceParams(LightMoney amount, string description, TimeSpan expiry, List<RouteHints> routeHints = null)
        {
            if (amount == null)
                throw new ArgumentNullException(nameof(amount));
            if (description == null)
                throw new ArgumentNullException(nameof(description));

            Amount = amount;
            Description = description;
            Expiry = expiry;
            RouteHints = routeHints;
        }

        [Obsolete("Set the Description and turn DescriptionHashOnly to true instead")]
        public CreateInvoiceParams(LightMoney amount, uint256 descriptionHash, TimeSpan expiry)
        {
            if (amount == null)
                throw new ArgumentNullException(nameof(amount));
            if (descriptionHash == null)
                throw new ArgumentNullException(nameof(descriptionHash));

            Amount = amount;
            DescriptionHash = descriptionHash;
            Expiry = expiry;
        }

        public LightMoney Amount { get; set; }
        public string Description { get; set; }
        uint256 _DescriptionHash;
        public uint256 DescriptionHash
        {
            get
            {
                if (_DescriptionHash is null && (Description is null || !DescriptionHashOnly))
                    return null;
                return _DescriptionHash ?? new uint256(Hashes.SHA256(Encoding.UTF8.GetBytes(Description)), false);
            }
            [Obsolete("Set the Description and turn DescriptionHashOnly to true instead")]
            set
            {
                _DescriptionHash = value;
            }
        }
        public bool DescriptionHashOnly { get; set; }
        public TimeSpan Expiry { get; set; }
        public bool PrivateRouteHints { get; set; }
        public List<RouteHints> RouteHints { get; set; }
    }
}
