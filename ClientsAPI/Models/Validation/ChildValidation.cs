using ClientsAPI.Data.Entities;

namespace ClientsAPI.Models.Validation
{
    public class ChildValidation : EntityValidation<Child>
    {
        private readonly string entityPath;
        public ChildValidation(Child entity, string entityPath) : base(entity)
        {
            this.entityPath = entityPath;
        }

        public override IEnumerable<ValidationExceptions> Validate()
        {
            List<ValidationExceptions> errors = new List<ValidationExceptions>();
            if (!ValidateString(entity.Name))
            {
                errors.Add(new ValidationExceptions($"{entityPath}.name", "Поле не должно быть пустым", "Поле name пустое"));
            }
            if (!ValidateString(entity.Surname))
            {
                errors.Add(new ValidationExceptions($"{entityPath}.surname", "Поле не должно быть пустым", "Поле name пустое"));
            }
            if (!ValidateString(entity.Patronymic))
            {
                errors.Add(new ValidationExceptions($"{entityPath}.patronymic", "Поле не должно быть пустым", "Поле name пустое"));
            }
            if (!ValidateDate(entity.Dob))
            {
                errors.Add(new ValidationExceptions($"{entityPath}.dob", "Неккоректная дата", "Дата должна быть в промежутке от 1900 до текущей даты"));
            }
            return errors;
        }
    }
}
