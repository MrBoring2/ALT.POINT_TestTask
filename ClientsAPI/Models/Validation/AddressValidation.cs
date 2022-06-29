using ClientsAPI.Data.Entities;

namespace ClientsAPI.Models.Validation
{
    public class AddressValidation : EntityValidation<Address>
    {
        private readonly string entityPath;
        public AddressValidation(Address entity, string entityPath) : base(entity)
        {
            this.entityPath = entityPath;
        }

        public override IEnumerable<ValidationExceptions> Validate()
        {
            List<ValidationExceptions> errors = new List<ValidationExceptions>();
            if (!ValidateStringAsNumber(entity.ZipCode, 6, 6))
            {
                errors.Add(new ValidationExceptions($"{entityPath}.zipCode", "Поле должно являться числом", "Поле не является числом"));
            }
            if (!ValidateString(entity.Country))
            {
                errors.Add(new ValidationExceptions($"{entityPath}.contry", "Поле не должно быть пустым", "Поле пустое"));
            }
            if (!ValidateString(entity.City))
            {
                errors.Add(new ValidationExceptions($"{entityPath}.city", "Поле не должно быть пустым", "Поле пустое"));
            }
            if (!ValidateString(entity.Street))
            {
                errors.Add(new ValidationExceptions($"{entityPath}.street", "Поле не должно быть пустым", "Поле пустое"));
            }
            if (!ValidateString(entity.House))
            {
                errors.Add(new ValidationExceptions($"{entityPath}.house", "Поле не должно быть пустым", "Поле пустое"));
            }
            if (!ValidateString(entity.Apartment))
            {
                errors.Add(new ValidationExceptions($"{entityPath}.apartment", "Поле не должно быть пустым", "Поле пустое"));
            }
            return errors;
        }
    }
}
