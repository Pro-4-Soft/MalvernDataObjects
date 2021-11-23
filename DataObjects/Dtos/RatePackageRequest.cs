using Pro4Soft.Malvern.DataObjects.Infrastructure;

namespace Pro4Soft.Malvern.DataObjects.Dtos
{
    [MalvernTransaction("002")]
    public class RatePackageRequest: BaseMalvernRequest
    {
        //Required
        [MalvernField(11, 30)]
        public string CompanyName { get; set; }

        [MalvernField(12, 30)]
        public string AttentionTo { get; set; }

        [MalvernField(13, 30)]
        public string AddressLine1 { get; set; }

        [MalvernField(15, 30)]
        public string City { get; set; }

        [MalvernField(16, 2)]
        public string State { get; set; }

        [MalvernField(17, 9)]
        public string ZipCode { get; set; }

        [MalvernField(19, 3)]
        public string CarrierCode { get; set; }

        [MalvernField(21, 6, 2)]
        public decimal? PackageWeight { get; set; }

        [MalvernField(22, 3)]
        public string ServiceLevelCode { get; set; }

        [MalvernField(9000, 10)]
        public string CarrierNumber { get; set; }

        [MalvernField(9001, 5, 1)]
        public string FreightClass { get; set; }

        //Optional
        [MalvernField(9, 5, 0, true)]
        public string OriginZipCode { get; set; }

        [MalvernField(9020, 20, 0, true)]
        public string MultipleAccountCode { get; set; }
    }

    [MalvernTransaction("102")]
    public class RatePackageResponse: BaseMalvernResponse
    {
        [MalvernField(21, 6, 2)]
        public decimal? PackageWeight { get; set; }

        [MalvernField(25, 15)]
        public string DepartmentId { get; set; }

        [MalvernField(29, 19)]
        public string TrackingNumber { get; set; }

        [MalvernField(34, 11, 2)]
        public decimal? TotalNonDiscountedCharge { get; set; }

        [MalvernField(37, 11, 2)]
        public decimal? TotalDiscountedCharge { get; set; }

        [MalvernField(1393, 11, 2)]
        public decimal? FueldSurcharge { get; set; }

        [MalvernField(3027, 11, 2)]
        public decimal? FedexRuralAreaSurcharge { get; set; }

        [MalvernField(6005, 20)]
        public string PurchaseOrderNumber { get; set; }

        [MalvernField(8002, 20)]
        public string CustomerId { get; set; }

        [MalvernField(8004, 30)]
        public string ShipmentId { get; set; }

        [MalvernField(8013, 3)]
        public string Zone { get; set; }

        [MalvernField(9034, 11, 2)]
        public decimal? BaseShippingCharge { get; set; }

        [MalvernField(9035, 11, 2)]
        public decimal? TotalAccessorialCharge { get; set; }

        [MalvernField(9036, 11, 2)]
        public decimal? HandlingCharge { get; set; }
    }
}