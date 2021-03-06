using Pro4Soft.Malvern.DataObjects.Infrastructure;

namespace Pro4Soft.Malvern.DataObjects.Dtos
{
    [MalvernTransaction("001")]
    public class ShipPackageRequest: RatePackageRequest
    {
        
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

        [MalvernField(288)]
        public string CommercialInvoiceBase64 { get; set; }
    }
}