using ClientsAPI.Data.Entities;
using ClientsAPI.Models.Enums;

namespace ClientsAPI.Models.Filters
{
    public interface IFilter<T> where T : BaseEntity
    {
        string Search { get; }
        string SortBy { get; }
        SortDirEnum? SortDir { get; }
        EducationTypeEnum? EducationType { get; }
        int Page { get; }
        int Limit { get; }
        Func<T, bool> FilterExpression { get; }
    }
}
