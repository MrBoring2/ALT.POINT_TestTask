using ClientsAPI.Data.Entities;
using ClientsAPI.Models.Enums;

namespace ClientsAPI.Models.Validation
{
    public class JobValidation : EntityValidation<Job>
    {
        private readonly string entityPath;
        public JobValidation(Job entity, string entityPath) : base(entity)
        {
            this.entityPath = entityPath;
        }

        public override IEnumerable<ValidationExceptions> Validate()
        {
            List<ValidationExceptions> errors = new List<ValidationExceptions>();
            var factAddressValidationResult = new AddressValidation(entity.FactAddress, $"{entityPath}.factAddress").Validate();
            if (factAddressValidationResult.Any())
            {
                errors.AddRange(factAddressValidationResult);
            }
            var jurAddressValidationResult = new AddressValidation(entity.JurAddress, $"{entityPath}.jurAddress").Validate();
            if (jurAddressValidationResult.Any())
            {
                errors.AddRange(jurAddressValidationResult);
            }
            if (entity.Type != JobTypeEnum.Main && entity.Type != JobTypeEnum.PartTime)
            {
                errors.Add(new ValidationExceptions($"{entityPath}.type", "IsEnum", "Поле не является Enum"));
            }
            if(!ValidateString(entity.PhoneNumber, 11, 11))
            {
                errors.Add(new ValidationExceptions($"{entityPath}.phoneNumber", "Поле должно являться номером телефона", "Поле не является номером телефона"));
            }
            if (!ValidateString(entity.Tin, 12, 12))
            {
                errors.Add(new ValidationExceptions($"{entityPath}.tin", "Поле должно являться номером ИНН", "Поле не является номером ИНН"));
            }
            if (!ValidateDate(entity.DateEmp))
            {
                errors.Add(new ValidationExceptions($"{entityPath}.dateEmp", "Неккоректная дата", "Дата должна быть в промежутке от 1900 до текущей даты"));
            }
            if (!ValidateDate(entity.DateDismissal))
            {
                errors.Add(new ValidationExceptions($"{entityPath}.dateDismissal", "Неккоректная дата", "Дата должна быть в промежутке от 1900 до текущей даты"));
            }
            if (!ValidateRealNumber((float)entity.MonIncome))
            {
                errors.Add(new ValidationExceptions($"{entityPath}.monIncome", "Поле должно быть больше нуля", "Значение поля minIncome меньше или равно нулю"));
            }
            return errors;
        }
    }
}
