using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace DPWEntityLibrary.Common
{
    public class CManifestEntity
    {
        [JsonPropertyName("vessel")]
        public CVesselEntity VesselDetails { get; set; }

        [JsonPropertyName("bolList")]
        public List<CBOLEntity> BOLList { get; set; }

    }
}
