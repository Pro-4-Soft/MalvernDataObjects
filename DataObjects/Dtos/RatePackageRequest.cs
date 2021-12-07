using Pro4Soft.Malvern.DataObjects.Infrastructure;

namespace Pro4Soft.Malvern.DataObjects.Dtos
{
    [MalvernTransaction("002")]
    public class RatePackageRequest : BaseMalvernRequest
    {
        [MalvernField(1, 15)]
        public string OrderNo { get; set; }

        [MalvernField(11, 30)]
        public string CompanyName { get; set; }

        [MalvernField(12, 30)]
        public string AttentionTo { get; set; }

        [MalvernField(13, 30)]
        public string AddressLine1 { get; set; }

        [MalvernField(14, 30)]
        public string AddressLine2 { get; set; }

        [MalvernField(15, 30)]
        public string City { get; set; }

        [MalvernField(16, 2)]
        public string State { get; set; }

        [MalvernField(17, 9)]
        public string ZipCode { get; set; }

        [MalvernField(18, 15)]
        public string Phone { get; set; }

        [MalvernField(19, 3)]
        public string CarrierCode { get; set; }

        [MalvernField(21, 6, 2)]
        public decimal? PackageWeight { get; set; }

        [MalvernField(22, 3)]
        public string ServiceLevelCode { get; set; }

        /// <summary>
        /// COL, BRC, B3P, etc (prepaid is the default)
        /// </summary>
        [MalvernField(23, 3)]
        public string BillOption { get; set; }

        [MalvernField(25, 15)]
        public string Department { get; set; }

        [MalvernField(50, 3)]
        public string CountryCode { get; set; }

        [MalvernField(57, 6, 2)]
        public string PackageLength { get; set; }
        
        [MalvernField(58, 6, 2)]
        public string PackageWidth { get; set; }
        
        [MalvernField(59, 6, 2)]
        public string PackageHeight { get; set; }

        [MalvernField(71, 9)]
        public string DutiesAccount { get; set; }

        [MalvernField(1202, 50)]
        public string Email { get; set; }

        [MalvernField(6005, 20)]
        public string PurchaseOrderNo { get; set; }

        [MalvernField(7011, 30)]
        public string BillToCompany { get; set; }

        [MalvernField(7012, 30)]
        public string BillToContact { get; set; }

        [MalvernField(7013, 30)]
        public string BillToAddressLine1 { get; set; }
        
        [MalvernField(7014, 30)]
        public string BillToAddressLine2 { get; set; }
        
        [MalvernField(7015, 30)]
        public string BillToCity { get; set; }
        
        [MalvernField(7016, 2)]
        public string BillToState { get; set; }

        [MalvernField(7017, 9)]
        public string BillToZip { get; set; }
        
        [MalvernField(7018, 30)]
        public string BillToCntryCode { get; set; }

        [MalvernField(8002, 20)]
        public string CustomerNo { get; set; }

        [MalvernField(8004, 20)]
        public string ShipmentId { get; set; }

        [MalvernField(9020, 20, 0, true)]
        public string MultipleAccountCode { get; set; }

        [MalvernField(9051, 30)]
        public string ShipFromContact { get; set; }

        [MalvernField(9052, 30)]
        public string ShipFromCompany { get; set; }

        [MalvernField(9053, 30)]
        public string ShipFromAddressLine1 { get; set; }

        [MalvernField(9054, 30)]
        public string ShipFromAddressLine2 { get; set; }

        [MalvernField(9055, 30)]
        public string ShipFromCity { get; set; }

        [MalvernField(9056, 2)]
        public string ShipFromState { get; set; }

        [MalvernField(9057, 9)]
        public string ShipFromZip { get; set; }

        [MalvernField(9058, 30)]
        public string ShipFromPhone { get; set; }

        [MalvernField(9401, 30)]
        public string PackageRef1 { get; set; }
        
        [MalvernField(9402, 30)]
        public string PackageRef2 { get; set; }
        
        [MalvernField(9403, 30)]
        public string PackageRef3 { get; set; }
        
        [MalvernField(9404, 30)]
        public string PackageRef4 { get; set; }
        
        [MalvernField(9405, 30)]
        public string PackageRef5 { get; set; }

        //[MalvernField(9000, 10)]  //LTL - Not in use
        //public string CarrierNumber { get; set; }

        //[MalvernField(9001, 5, 1)]  //LTL - Not in use
        //public string FreightClass { get; set; }

    }

    [MalvernTransaction("102")]
    public class RatePackageResponse : BaseMalvernResponse
    {
        [MalvernField(19, 30)]
        public string Carrier { get; set; }

        [MalvernField(21, 6, 2)]
        public decimal? PackageWeight { get; set; }

        [MalvernField(22, 30)]
        public string Service { get; set; }

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