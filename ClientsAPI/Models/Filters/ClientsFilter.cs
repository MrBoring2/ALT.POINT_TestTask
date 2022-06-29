using ClientsAPI.Data.Entities;
using ClientsAPI.Models.Enums;

namespace ClientsAPI.Models.Filters
{
    public class ClientsFilter : IFilter<Client>
    {
        public ClientsFilter(string search, string sortBy, SortDirEnum? sortDir, EducationTypeEnum? educationType, int page, int limit)
        {
            Search = search == null ? "" : search;
            SortBy = sortBy;
            SortDir = sortDir;
            Page = page;
            EducationType = educationType;
            Limit = limit;
        }

        public string Search { get; private set; }
        public string SortBy { get; private set; }
        public SortDirEnum? SortDir { get; private set; }
        public EducationTypeEnum? EducationType { get; private set; }
        public int Page { get; private set; }
        public int Limit { get; private set; }
        public Func<Client, bool> FilterExpression
        {
            get
            {
                return p =>
                {
                    bool searchResult = false;
                    bool isDeleteResult = false;
                    bool education = false;
                    searchResult = p.FullName.ToUpper().Contains(Search.ToUpper());
                    if (searchResult == false)
                    {
                        return false;
                    }
                    isDeleteResult = p.DeletedAt != null;
                    education = p.TypeEducation == EducationType;


                    return searchResult == true && isDeleteResult == false && education == true;
                };
            }
        }
    }
}
