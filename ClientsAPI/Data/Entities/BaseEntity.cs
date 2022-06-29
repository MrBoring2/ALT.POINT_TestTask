using ClientsAPI.Models.Validation;

namespace ClientsAPI.Data.Entities
{
    public class BaseEntity 
    {
        public object GetProperty(string property)
        {
            var value = GetType().GetProperties().FirstOrDefault(p => p.Name.ToUpper().Equals(property.ToUpper()));
            return GetType().GetProperty(value.Name).GetValue(this, null);
        }
        public bool IsPropertyExist(string property)
        {
            return GetType().GetProperties().FirstOrDefault(p => p.Name.ToUpper().Equals(property.ToUpper())) != null;
        }
    }
}
