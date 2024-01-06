using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DPWEntityLibrary.Common
{
    public class CVesselEntity
    {
        [JsonPropertyName("mrn")]
        public string Mrn { get; set; }

        [Required]
        [StringLength(16)]
        [JsonPropertyName("vesselVisitCode")]
        public string vesselVisitCode { get; set; }

        [JsonPropertyName("approvalDate")]
        public string ApprovalDate { get; set; }

        [JsonPropertyName("carrierCode")]
        public string CarrierCode { get; set; }

        [JsonPropertyName("carrierName")]
        public string CarrierName { get; set; }

        [JsonPropertyName("callSign")]
        public string CallSign { get; set; }

        [JsonPropertyName("vesselName")]
        public string VesselName { get; set; }

        [JsonPropertyName("voyageNumber")]
        public string VoyageNumber { get; set; }

        [JsonPropertyName("tpaUid")]
        public string TpaUid { get; set; }

        [JsonPropertyName("departurePortCode")]
        public string DeparturePortCode { get; set; }

        [JsonPropertyName("departurePortName")]
        public string DeparturePortName { get; set; }

        [JsonPropertyName("dischargePortCode")]
        public string DischargePortCode { get; set; }

        [JsonPropertyName("dischargePortName")]
        public string DischargePortName { get; set; }

        [JsonPropertyName("terminalCode")]
        public string TerminalCode { get; set; }

        [JsonPropertyName("terminalName")]
        public string TerminalName { get; set; }

        [JsonPropertyName("inBallastYn")]
        public string InBallastYn { get; set; }

        [JsonPropertyName("transportMeansId")]
        public string TransportMeansId { get; set; }

        [JsonPropertyName("transportMeansNationality")]
        public string TransportMeansNationality { get; set; }

        [JsonPropertyName("nextPortOfCall")]
        public string NextPortOfCall { get; set; }

        [JsonPropertyName("departureDate")]
        public string DepartureDate { get; set; }

        [JsonPropertyName("expectedArrivalDate")]
        public string ExpectedArrivalDate { get; set; }

        [JsonPropertyName("actionType")]
        public string ActionType { get; set; }
    }
}
