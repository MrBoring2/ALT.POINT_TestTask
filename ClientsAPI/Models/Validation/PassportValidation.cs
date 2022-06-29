using ClientsAPI.Data.Entities;

namespace ClientsAPI.Models.Validation
{
    public class PassportValidation : EntityValidation<Passport>
    {
        private readonly string entityPath;
        public PassportValidation(Passport entity, string entityPath) : base(entity)
        {
            this.entityPath = entityPath;
        }

        public override IEnumerable<ValidationExceptions> Validate()
        {
            List<ValidationExceptions> errors = new List<ValidationExceptions>();
            if (!ValidateStringAsNumber(entity.Number, 6, 6))
            {
                errors.Add(new ValidationExceptions($"{entityPath}.number", "Поле должно являтьcя числом", "Поле не является числом"));
            }
            if (!ValidateStringAsNumber(entity.Series, 4, 4))
            {
                errors.Add(new ValidationExceptions($"{entityPath}.series", "Поле должно являтьcя числом", "Поле не является числом"));
            }
            if (!ValidateString(entity.Giver))
            {
                errors.Add(new ValidationExceptions($"{entityPath}.number", "Поле не должно быть пустым", "Поле пустое"));
            }
            if (!ValidateDate(entity.DateIssued))
            {
                errors.Add(new ValidationExceptions($"{entityPath}.number", "Поле не должно быть пустым", "Поле пустое"));
            }
            return errors;
        }
    }
}
