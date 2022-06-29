using System.Runtime.Serialization;

namespace ClientsAPI.Models.Enums
{
    public enum CommunicationTypeEnum
    {
        [EnumMember(Value = "email")]
        Email = 0,
        [EnumMember(Value = "phone")]
        Phone = 1
    }
}
