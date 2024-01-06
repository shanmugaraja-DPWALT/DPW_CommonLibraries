using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace DPWEntityLibrary.Common
{
    public class CContainerEntity
    {
        [Required]
        [JsonPropertyName("cntrNbr")]
        public string ContainerNumber { get; set; }

        [Required]
        [JsonPropertyName("seal1Nbr")]
        public string Seal1Number { get; set; }
        

        [JsonPropertyName("seal2Nbr")]
        public string Seal2Number { get; set; }
        
        [JsonPropertyName("seal3Nbr")]
        public string Seal3Number { get; set; }

        [Required]
        [JsonPropertyName("cntrSize")]
        public string ContainerSize { get; set; }
        
        [JsonPropertyName("cntrBoxOper")]
        public string ContainerBoxOperator { get; set; }
        
        [JsonPropertyName("grossWeightInKg")]
        public float GrossWeightInKg { get; set; }

        //============================================================================================

        [JsonPropertyName("freightIndicator")]
        public string FreightIndicator { get; set; }

        [JsonPropertyName("containerPackage")]
        public int ContainerPackage { get; set; }

        [JsonPropertyName("packageUnit")]
        public string PackageUnit { get; set; }

        [Required]
        [JsonPropertyName("containerWeight")]
        public float ContainerWeight { get; set; }

        [JsonPropertyName("containerWeightUnit")]
        public string ContainerWeightUnit { get; set; }

        [JsonPropertyName("containerVolume")]
        public float ContainerVolume { get; set; }

        [JsonPropertyName("containerVolumeUnit")]
        public string ContainerVolumeUnit { get; set; }

        [JsonPropertyName("referPlugYn")]
        public string ReferPlugYn { get; set; }

        [JsonPropertyName("minTemp")]
        public float MinimumTemperature { get; set; }

        [JsonPropertyName("maxTemp")]
        public float MaximumTemparature { get; set; }

    }
}
