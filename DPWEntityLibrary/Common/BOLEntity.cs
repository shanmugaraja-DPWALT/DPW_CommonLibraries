using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace DPWEntityLibrary.Common
{
    public class CBOLEntity
    {
        [Required]
        [StringLength(30)]
        [JsonPropertyName("bolNbr")]
        public string BolNumber { get; set; }

        [JsonPropertyName("tradeMode")]
        public string TradeMode { get; set; }

        [Required]
        [StringLength(100)]
        [JsonPropertyName("consignee")]
        public string Consignee { get; set; }

        [JsonPropertyName("shipper")]
        public string Shipper { get; set; }

        [JsonPropertyName("notifier")]
        public string Notifier { get; set; }

        [JsonPropertyName("org")]
        public string Org { get; set; }

        [JsonPropertyName("pol")]
        public string Pol { get; set; }

        [JsonPropertyName("pod")]
        public string Pod{ get; set; }

        [JsonPropertyName("dst")]
        public string Dst{ get; set; }

        [Required]
        [JsonPropertyName("cargoCode")]
        public string CargoCode{ get; set; }

        [JsonPropertyName("userDefinedName0")]
        public string UserDefinedName0{ get; set; }

        [JsonPropertyName("userDefinedName1")]
        public string UserDefinedName1{ get; set; }

        [JsonPropertyName("userDefinedName2")]
        public string UserDefinedName2{ get; set; }

        [JsonPropertyName("userDefinedName3")]
        public string UserDefinedName3{ get; set; }

        [JsonPropertyName("userDefinedName4")]
        public string UserDefinedName4{ get; set; }

        [JsonPropertyName("userDefinedName5")]
        public string UserDefinedName5{ get; set; }

        [JsonPropertyName("userDefinedName6")]
        public string UserDefinedName6{ get; set; }

        [JsonPropertyName("userDefinedName7")]
        public string UserDefinedName7{ get; set; }

        [JsonPropertyName("userDefinedName8")]
        public string UserDefinedName8{ get; set; }

        [JsonPropertyName("userDefinedName9")]
        public string UserDefinedName9 { get; set; }

        [JsonPropertyName("userDefinedCode0")]
        public string UserDefinedCode0{ get; set; }

        [JsonPropertyName("userDefinedCode1")]
        public string UserDefinedCode1{ get; set; }

        [JsonPropertyName("userDefinedCode2")]
        public string UserDefinedCode2 { get; set; }

        [JsonPropertyName("userDefinedCode3")]
        public string UserDefinedCode3 { get; set; }

        [JsonPropertyName("userDefinedCode4")]
        public string UserDefinedCode4 { get; set; }

        [JsonPropertyName("userDefinedCode5")]
        public string UserDefinedCode5 { get; set; }

        [JsonPropertyName("userDefinedCode6")]
        public string UserDefinedCode6 { get; set; }

        [JsonPropertyName("userDefinedCode7")]
        public string UserDefinedCode7 { get; set; }

        [JsonPropertyName("userDefinedCode8")]
        public string UserDefinedCode8 { get; set; }

        [JsonPropertyName("userDefinedCode9")]
        public string UserDefinedCode9 { get; set; }

        [JsonPropertyName("userDefinedNbr0")]
        public int UserDefinedNbr0 { get; set; }

        [JsonPropertyName("userDefinedNbr1")]
        public int UserDefinedNbr1 { get; set; }

        [JsonPropertyName("userDefinedNbr2")]
        public int UserDefinedNbr2 { get; set; }

        [JsonPropertyName("userDefinedNbr3")]
        public int UserDefinedNbr3 { get; set; }

        [JsonPropertyName("userDefinedNbr4")]
        public int UserDefinedNbr4 { get; set; }

        [JsonPropertyName("userDefinedNbr5")]
        public int UserDefinedNbr5 { get; set; }

        [JsonPropertyName("userDefinedNbr6")]
        public int UserDefinedNbr6 { get; set; }

        [JsonPropertyName("userDefinedNbr7")]
        public int UserDefinedNbr7 { get; set; }

        [JsonPropertyName("userDefinedNbr8")]
        public int UserDefinedNbr8 { get; set; }

        [JsonPropertyName("userDefinedNbr9")]
        public int UserDefinedNbr9 { get; set; }

        [JsonPropertyName("userDefinedTime0")]
        public string UserDefinedTime0 { get; set; }

        [JsonPropertyName("userDefinedTime1")]
        public string UserDefinedTime1 { get; set; }

        [JsonPropertyName("userDefinedTime2")]
        public string UserDefinedTime2 { get; set; }

        [JsonPropertyName("userDefinedTime3")]
        public string UserDefinedTime3 { get; set; }

        [JsonPropertyName("userDefinedTime4")]
        public string UserDefinedTime4 { get; set; }

        [JsonPropertyName("userDefinedTime5")]
        public string UserDefinedTime5 { get; set; }

        [JsonPropertyName("userDefinedTime6")]
        public string UserDefinedTime6 { get; set; }

        [JsonPropertyName("userDefinedTime7")]
        public string UserDefinedTime7 { get; set; }

        [JsonPropertyName("userDefinedTime8")]
        public string UserDefinedTime8 { get; set; }

        [JsonPropertyName("userDefinedTime9")]
        public string UserDefinedTime9 { get; set; }

        [JsonPropertyName("placeOfDelivery")]
        public string PlaceOfDelivery { get; set; }

        //[Required]
        //[JsonPropertyName("actionType")]
        //public string ActionType { get; set; }
        //C - Create
        //A - Amendment
        
        //=======================================================================================================

        [JsonPropertyName("crn")]
        public string Crn { get; set; }

        [JsonPropertyName("blType")]
        public string BillType { get; set; }

        [JsonPropertyName("loadingPortCode")]
        public string LoadingPortCode { get; set; }

        [JsonPropertyName("loadingPortName")]
        public string LoadingPortName { get; set; }

        [JsonPropertyName("destinationPlaceCode")]
        public string DestinationPlaceCode { get; set; }

        [JsonPropertyName("destinationPlaceName")]
        public string DestinationPlaceName { get; set; }

        [JsonPropertyName("deliveryPlaceCode")]
        public string DeliveryPlaceCode { get; set; }

        [JsonPropertyName("deliveryPlaceName")]
        public string DeliveryPlaceName { get; set; }

        [JsonPropertyName("cargoClassificationCode")]
        public string CargoClassificationCode { get; set; }

        [JsonPropertyName("cargoClassificationName")]
        public string CargoClassificationName { get; set; }

        [JsonPropertyName("shippingAgentCode")]
        public string ShippingAgentCode { get; set; }

        [JsonPropertyName("shippingAgentName")]
        public string ShippingAgentName { get; set; }

        [JsonPropertyName("forwarderCode")]
        public string ForwarderCode { get; set; }

        [JsonPropertyName("forwarderName")]
        public string ForwarderName { get; set; }

        [JsonPropertyName("forwarderTel")]
        public string ForwarderTel { get; set; }

        [JsonPropertyName("exporterName")]
        public string ExporterName { get; set; }

        [JsonPropertyName("exporterAddress")]
        public string ExporterAddress { get; set; }

        [JsonPropertyName("exporterTel")]
        public string ExporterTel { get; set; }

        [JsonPropertyName("consigneeTin")]
        public string ConsigneeTin { get; set; }

        [JsonPropertyName("consigneeName")]
        public string ConsigneeName { get; set; }

        [JsonPropertyName("consigneeAddress")]
        public string ConsigneeAddress { get; set; }

        [JsonPropertyName("consigneeTel")]
        public string ConsigneeTel { get; set; }

        [JsonPropertyName("notifyName")]
        public string NotifyName { get; set; }

        [JsonPropertyName("notifyAddress")]
        public string NotifyAddress { get; set; }

        [JsonPropertyName("notifyTel")]
        public string NotifyTel { get; set; }

        //========================================================================================================

        [Required]
        [JsonPropertyName("bolCargos")]
        public List<CCargoEntity> BolCargos { get; set; }
        
        [JsonPropertyName("bolCntrs")]
        public List<CContainerEntity> BolContainers { get; set; }

        [JsonPropertyName("bolVehicles")]
        public List<CVehicleEntity> BolVehicles { get; set; }
       
    }
}
