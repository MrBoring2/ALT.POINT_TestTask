using System.Runtime.Serialization;

namespace ClientsAPI.Models.Enums
{
    public enum JobTypeEnum
    {
        [EnumMember(Value = "main")]
        Main = 0,
        [EnumMember(Value = "part-time")]
        PartTime = 1
    }
}
