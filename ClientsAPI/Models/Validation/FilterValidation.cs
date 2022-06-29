using ClientsAPI.Data.Entities;
using ClientsAPI.Models.Enums;
using ClientsAPI.Models.Errors;
using ClientsAPI.Models.Filters;

namespace ClientsAPI.Models.Validation
{
    public class FilterValidation<T> where T : BaseEntity
    {
        private IFilter<T> filter;

        public FilterValidation(IFilter<T> filter)
        {
            this.filter = filter;
        }
        public IEnumerable<ValidationExceptions> Validate()
        {
            List<ValidationExceptions> errors = new List<ValidationExceptions>();
            if (!ValidateSortParameter(filter.SortBy))
            {
                errors.Add(new ValidationExceptions("sortBy", "Поле должно существовать", $"Поля {filter.SortBy} не существует"));
            }

            if (!ValidateSortDir(filter.SortDir))
            {
                errors.Add(new ValidationExceptions("sortDir", "IsEnum", $"{filter.SortDir} не является Enum"));
            }

            if (!ValidateInt(filter.Page, false))
            {
                errors.Add(new ValidationExceptions("page", "Текущая страница больше нуля", $"Номер старницы {filter.SortDir} ниже или равен нуля"));
            }

            if (!ValidateInt(filter.Limit, false))
            {
                errors.Add(new ValidationExceptions("limit", "Количество элементов на старинце больше нуля", $"Количество элементов на странице {filter.Limit} ниже или равно нуля"));
            }

            return errors;
        }

        private bool ValidateSortDir(SortDirEnum? sortDirEnum)
        {
            if (sortDirEnum == null)
            {
                return false;
            }

            if (sortDirEnum == SortDirEnum.ask || sortDirEnum == SortDirEnum.desk)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ValidateSortParameter(string sortBy)
        {
            if (sortBy == null || string.IsNullOrEmpty(sortBy))
            {
                return false;
            }

            if (!new Client().IsPropertyExist(sortBy))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool ValidateInt(int number, bool canBeNull)
        {
            if (number >= 0 || (number == 0 && canBeNull))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
