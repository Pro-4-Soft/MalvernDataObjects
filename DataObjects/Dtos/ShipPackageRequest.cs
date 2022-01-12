using Pro4Soft.Malvern.DataObjects.Infrastructure;

namespace Pro4Soft.Malvern.DataObjects.Dtos
{
    [MalvernTransaction("001")]
    public class ShipPackageRequest: RatePackageRequest
    {
        /// <summary>
        /// Bill to Account # (Conditional for alternate billing STP, BRC, B3P, COL).  Not required for 
        /// any Prepaid, UPS Consignee Billing (C/B) or FedEx Ground Collect (COL)
        /// </summary>
        public string BillShipNo { get; set; }

        /// <summary>
        /// COL, BRC, B3P, C/B etc (prepa   id is the default)
        /// </summary>
        [MalvernField(23, 3)]
        public string BillOption { get; set; }

        /// <summary>
        /// Item Description with line number suffix, e.g., 79-1, 79-2 etc)
        /// </summary>
        [MalvernField(79, 50)]
        public string Description { get; set; }

        /// <summary>
        /// Line Item Country of Origin (Manufacture) 2-Characters (US, CA, CN, etc) 
        /// with line number suffix, e.g., 81-1, 82-2 etc)
        /// </summary>
        [MalvernField(81, 2)]
        public string Origin { get; set; }

        /// <summary>
        /// Line Item Item Quantity with line number suffix, e.g., 82-1, 82-2 etc)
        /// </summary>
        [MalvernField(82, 7)]
        public string Quantity { get; set; }
        
        /// <summary>
        /// Line Item Units e.g., EA for Each. with line number suffix, e.g., 414-1, 414-2 etc)
        /// </summary>
        [MalvernField(414, 10)]
        public string Units { get; set; }
        
        /// <summary>
        /// Line Item Unit Value with line number suffix, e.g., 1030-1, 1030-2 etc)
        /// </summary>
        [MalvernField(1030, 8, 2)]
        public string Value { get; set; }
        
        /// <summary>
        /// Bill to company (required for UPS STP)
        /// </summary>
        [MalvernField(7011, 30)]
        public string PayorCompany { get; set; }
        
        /// <summary>
        /// Bill to contact (optional for UPS STP)
        /// </summary>
        [MalvernField(7012, 30)]
        public string PayorContact { get; set; }
        
        /// <summary>
        /// Bill to Address Line 1 (required for UPS STP)
        /// </summary>
        [MalvernField(7013, 30)]
        public string PayorAddress1 { get; set; }

        
        /// <summary>
        /// Bill To Address Line 2 (optional for UPS STP)
        /// </summary>
        [MalvernField(7014, 30)]
        public string PayorAddress2 { get; set; }

        /// <summary>
        /// Bill To City (required for UPS STP)
        /// </summary>
        [MalvernField(7015, 30)]
        public string PayorCity { get; set; }
        
        /// <summary>
        /// Bill To State (required for UPS STP)
        /// </summary>
        [MalvernField(7016, 2)]
        public string PayorState { get; set; }

        /// <summary>
        /// Bill to Zip (required for UPS STP)
        /// </summary>
        [MalvernField(7017, 9)]
        public string PayorZip { get; set; }

        /// <summary>
        /// Bill to Country (optional for UPS STP, defaults to "US" if not provided)
        /// </summary>
        [MalvernField(7018, 2)]
        public string PayorCountryCode { get; set; }
    }

    [MalvernTransaction("101")]
    public class ShipPackageResponse: RatePackageResponse
    {
        

        [MalvernField(188, 30 * 1024)]
        public string LabelBuffer { get; set; }

        [MalvernField(189, 10 * 1024)]
        public string AdditionalLabelBuffer { get; set; }

        [MalvernField(194, 3)]
        public string FedexDeliveryDayOfWeek { get; set; }

        [MalvernField(409, 7)]//ddmmmyy
        public string FedexDeliveryByDate { get; set; }

        [MalvernField(411, 3 * 1024)]
        public string CodLabelBuffer { get; set; }

        [MalvernField(430, 11, 2)]
        public decimal? CodFee { get; set; }

        [MalvernField(9031, 3 * 1024)]
        public string CustomLabelBuffer { get; set; }
    }
}