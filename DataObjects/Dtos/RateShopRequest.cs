using System.Collections.Generic;
using System.Linq;
using Pro4Soft.Malvern.DataObjects.Infrastructure;

namespace Pro4Soft.Malvern.DataObjects.Dtos
{
    [MalvernTransaction("003")]
    public class RateShopRequest : BaseMalvernRequest
    {
        [MalvernField(17, 9)]
        public string RecipientZipCode { get; set; }

        [MalvernField(21, 6, 2)]
        public string ActualPackageWeight { get; set; }

        [MalvernField(1033, 250)]
        public List<CarrierServiceRate> RateRequestTypes { get; set; } = new List<CarrierServiceRate>();

        [MalvernField(9001, 5, 1)] 
        public string LtlFreightClass { get; set; }

        //Optional
        [MalvernField(440, 1)]
        public bool? IsResidential { get; set; }

        [MalvernField(1273, 2)]
        public string PackageType { get; set; }

        [MalvernField(9020, 20)]
        public string MultipleAccountCodes { get; set; }

        [MalvernField(9060, 2)]
        public string NumberOfBoxes { get; set; }
    }

    [MalvernTransaction("103")]
    public class RateShopResponse : BaseMalvernResponse
    {
        [MalvernField(1034, 250)]
        public List<CarrierServiceRate> Rates { get; set; }

        [MalvernField(1035, 250)]
        public List<CarrierServiceRate> DiscountedRates { get; set; }
    }

    public class CarrierServiceRate
    {
        public string Carrier { get; set; }
        public string Service { get; set; }
        public decimal? Rate { get; set; }

        public override string ToString()
        {
            return string.Join(" ", new[] {Carrier, Service, Rate?.ToString("0.00")}.Where(c => c != null));
        }
    }
}