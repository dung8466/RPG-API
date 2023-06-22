using System.Text.Json.Serialization;

namespace dotnet_api.Models
{
    [JsonConverter(typeof(Js))]
    public enum RpgClass
    {
        Knight = 1,
        Mage = 2,
        Cleric = 3
    }
}