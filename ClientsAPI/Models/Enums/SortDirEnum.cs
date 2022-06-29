using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace ClientsAPI.Models.Enums
{

    public enum SortDirEnum
    {

        [Display(Name = "ask")]
        [JsonConverter(typeof(StringEnumConverter))]
        ask,
        [Display(Name = "desk")]
        [JsonConverter(typeof(StringEnumConverter))]
        desk,
    }
}
