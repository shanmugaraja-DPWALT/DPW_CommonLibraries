using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DPWEntityLibrary.Common
{
    public class CVehicleEntity
    {
        [Required]
        [JsonPropertyName("make")]
        public string Make { get; set; }

        [Required]
        [JsonPropertyName("model")]
        public string Model { get; set; }

        [Required]
        [JsonPropertyName("caseNbr")]
        public string CaseNumber { get; set; }

        [JsonPropertyName("vehicleId")]
        public string VehicleId { get; set; }

        [Required]
        [JsonPropertyName("engineNbr")]
        public string EngineNumber { get; set; }

        [JsonPropertyName("colorCode")]
        public string ColorCode { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("keyNbr")]
        public string KeyNumber { get; set; }

        [JsonPropertyName("prodMonth")]
        public string ProductionMonth { get; set; }

        [Required]
        [JsonPropertyName("weightInKg")]
        public float WeightInKg { get; set; }

        [JsonPropertyName("weight")]
        public float Weight { get; set; }

        [JsonPropertyName("weightUom")]
        public string WeightUom { get; set; }

        [JsonPropertyName("volumeInCBM")]
        public float VolumeInCBM { get; set; }

        [JsonPropertyName("volume")]
        public float Volume { get; set; }

        [JsonPropertyName("volumeUom")]
        public string VolumeUom { get; set; }

        [Required]
        [JsonPropertyName("usedCar")]
        public string UsedCar { get; set; }
        
        [JsonPropertyName("remarks")]
        public string remarks { get; set; }

        //================================================================================================
        //Infuture this will be required fields
        [JsonPropertyName("length")]
        public float Length { get; set; }

        [JsonPropertyName("width")]
        public float Width { get; set; }

        [JsonPropertyName("height")]
        public float Height { get; set; }
    }
}
