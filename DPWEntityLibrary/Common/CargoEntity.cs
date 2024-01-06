using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DPWEntityLibrary.Common
{
    public class CCargoEntity
    {
        [JsonProperty(Required = Required.Default)]
        [JsonPropertyName("cargoTypeCode")]
        public string CargoTypeCode { get; set; }

        [JsonPropertyName("markAndNbr")]
        public string MarkAndNumber { get; set; }

        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        [JsonPropertyName("commodityCode")]
        public string CommodityCode { get; set; }

        [Required]
        [JsonPropertyName("hsCode")]
        public string HsCode { get; set; }

        [Required]
        [JsonPropertyName("qty")]
        public float Quantity { get; set; }

        [Required]
        [JsonPropertyName("qtyUom")]
        public string QuantityUom { get; set; }
        
        [JsonPropertyName("volumeInCBM")]
        public float VolumeInCBM { get; set; }
        
        [JsonPropertyName("volume")]
        public float Volume { get; set; }
        
        [JsonPropertyName("volumeUom")]
        public string VolumeUom { get; set; }

        [Required]
        [JsonPropertyName("weightInKg")]
        public float WeightInKg { get; set; }
        
        [JsonPropertyName("weight")]
        public float weight { get; set; }
        
        [JsonPropertyName("weightUom")]
        public string WeightUom { get; set; }
        
        [JsonPropertyName("remarks")]
        public string Remarks { get; set; }
        
        [JsonPropertyName("refCntrNbr")]
        public string RefControlNumber { get; set; }
    }
}
