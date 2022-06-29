using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace ClientsAPI.Models.Enums
{
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum EducationTypeEnum
    {
        [EnumMember(Value = "secondary")]
        Secondary = 0,
        [EnumMember(Value = "secondarySpecial")]
        SecondarySpecial = 1,
        [EnumMember(Value = "incompleteHigher")]
        IncompleteHigher = 2,
        [EnumMember(Value = "higher")]
        Higher = 3,
        [EnumMember(Value = "twoOrMoreHigher")]
        TwoOrMoreHigher = 4,
        [EnumMember(Value = "academicDegree")]
        AcademicDegree = 5
    }
}
