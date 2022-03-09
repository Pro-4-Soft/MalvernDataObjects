using System.Collections.Generic;
using Pro4Soft.Malvern.DataObjects.Infrastructure;

namespace Pro4Soft.Malvern.DataObjects.Dtos
{
    [MalvernTransaction("002")]
    public class RatePackageRequest : BaseMalvernRequest
    {
        [MalvernField(11, 30)]
        public string ShipToName { get; set; }

        [MalvernField(12, 30)]
        public string ShipToAttnTo { get; set; }

        [MalvernField(13, 30)]
        public string ShipToAddress1 { get; set; }
        
        [MalvernField(14, 30)]
        public string ShipToAddress2 { get; set; }

        [MalvernField(15, 30)]
        public string ShipToCity { get; set; }

        [MalvernField(16, 2)]
        public string ShipToStateProvince { get; set; }

        [MalvernField(17, 9)]
        public string ShipToZipPostal { get; set; }

        [MalvernField(18, 15)]
        public string ShipToPhone { get; set; }

        [MalvernField(19, 3)]
        public string CarrierCode { get; set; }

        [MalvernField(20, 30)]
        public string BillToAccountNumber { get; set; }
        
        [MalvernField(21, 6, 2)]
        public decimal? PackageWeight { get; set; }

        [MalvernField(22, 3)]
        public string ServiceLevelCode { get; set; }

        // COL, BRC, B3P, C/B etc (prepay id is the default)
        [MalvernField(23, 3)]
        public string BillOption { get; set; }

        [MalvernField(25, 15)]
        public string Department { get; set; }

        [MalvernField(50, 3)]
        public string ShipToCountry { get; set; }

        // COD Amount (Sending a value > 0 services as the COD Flag)
        [MalvernField(53, 10, 2)]
        public string CODAmount { get; set; }
                
        // COD Payment Terms 1=company check acceptable (default) 2=Certified payment required
        [MalvernField(54, 1)]
        public string CODTerms { get; set; }
        
        [MalvernField(57, 6, 2)]
        public decimal? PackageLength { get; set; }
        
        [MalvernField(58, 6, 2)]
        public decimal? PackageWidth { get; set; }
        
        [MalvernField(59, 6, 2)]
        public decimal? PackageHeight { get; set; }

        [MalvernField(71, 9)]
        public string DutiesAccount { get; set; }

        // Add Shipping charges to CODAmount Y or N (defaults to N)
        [MalvernField(186, 1)]
        public bool CODAddShippingCharges { get; set; }

        [MalvernField(440, 1)]
        public bool IsResidential { get; set; }

        [MalvernField(1266, 1)]
        public bool SaturdayDelivery { get; set; }

        [MalvernField(1202, 50)]
        public string Email { get; set; }

        [MalvernField(6005, 20)]
        public string PurchaseOrderNo { get; set; }

        [MalvernField(7011, 30)]
        public string BillToName { get; set; }

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
        public string BillToCountryCode { get; set; }

        [MalvernField(8002, 20)]
        public string CustomerNo { get; set; }

        [MalvernField(8004, 20)]
        public string ShipmentId { get; set; }

        [MalvernField(9020, 20, 0, true)]
        public string MultipleAccountCode { get; set; }

        // DCR = Delivery Confirmation, DCS = Signature Required, DCA = Adult Signature Required
        [MalvernField(9041, 3)]
        public string ConfirmationService { get; set; }

        [MalvernField(9051, 30)]
        public string ShipFromContact { get; set; }

        [MalvernField(9052, 30)]
        public string ShipFromName { get; set; }

        [MalvernField(9053, 30)]
        public string ShipFromAddress1 { get; set; }

        [MalvernField(9054, 30)]
        public string ShipFromAddress2 { get; set; }

        [MalvernField(9055, 30)]
        public string ShipFromCity { get; set; }

        [MalvernField(9056, 2)]
        public string ShipFromStateProvince { get; set; }

        [MalvernField(9057, 9)]
        public string ShipFromZipPostal { get; set; }

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

        [MalvernField]
        public List<CustomsLineItem> CustomsLines { get; set; } = new();
    }

    public class CustomsLineItem: BaseMalvernEntity
    {
        // Line Item Country of Origin (Manufacture) 2-Characters (US, CA, CN, etc) with line number suffix, e.g., 81-1, 82-2 etc)
        [MalvernField(80, 2)]
        public string Origin { get; set; }

        [MalvernField(81, 50)]
        public string HtsCode { get; set; }

        // Item Description with line number suffix, e.g., 79-1, 79-2 etc)
        [MalvernField(79, 50)]
        public string CommodityDescription { get; set; }

        // Line Item Units e.g., EA for Each. with line number suffix, e.g., 414-1, 414-2 etc)
        [MalvernField(414, 10)]
        public string Units { get; set; }

        // Line Item Quantity with line number suffix, e.g., 82-1, 82-2 etc)
        [MalvernField(82, 7)]
        public decimal? Quantity { get; set; }

        // Line Item Unit Value with line number suffix, e.g., 1030-1, 1030-2 etc)
        [MalvernField(1030, 8, 2)]
        public decimal? UnitValue { get; set; }
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