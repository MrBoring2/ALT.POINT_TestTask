using ClientsAPI.Data.Entities;

namespace ClientsAPI.Models.Validation
{
    public abstract class EntityValidation<T> where T : BaseEntity
    {
        protected T entity;

        protected EntityValidation(T entity)
        {
            this.entity = entity;
        }

        public virtual IEnumerable<ValidationExceptions> Validate() { return null; }
        protected bool ValidateString(string str)
        {
            return !string.IsNullOrEmpty(str);
        }
        protected bool ValidateString(string str, int minLength = 0, int maxLength = 10)
        {
            return !string.IsNullOrEmpty(str);
        }
        protected bool ValidateStringAsNumber(string str, int minLength = 0, int maxLength = 10)
        {
            return !string.IsNullOrEmpty(str) && str.All(p => char.IsDigit(p));
        }
        protected bool ValidateRealNumber(float number, bool nullable = false)
        {
            if (number < 0)
            {
                return false;
            }

            return (number >= 0 && nullable == true) || (number > 0 && nullable == false);
        }
        protected bool ValidateIntNumber(int number, bool nullable = false)
        {
            if (number < 0)
            {
                return false;
            }

            return (number >= 0 && nullable == true) || (number > 0 && nullable == false);
        }
        protected bool ValidateDate(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                return false;
            }
            return date <= DateTime.Now.ToLocalTime() && date >= new DateTime(1900, 1, 1);
        }
    }
}
