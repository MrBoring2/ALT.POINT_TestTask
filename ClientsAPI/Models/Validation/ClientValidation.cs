using ClientsAPI.Data.Entities;
using ClientsAPI.Models.Enums;

namespace ClientsAPI.Models.Validation
{
    public class ClientValidation : EntityValidation<Client>
    {
        private readonly string entityPath;
        public ClientValidation(Client client, string entityPath = "") : base(client)
        {
            this.entityPath = entityPath;
            if (!string.IsNullOrEmpty(this.entityPath))
            {
                this.entityPath = this.entityPath + ".";
            }
        }

        public override IEnumerable<ValidationExceptions> Validate()
        {
            List<ValidationExceptions> errors = new List<ValidationExceptions>();
            if (!ValidateString(entity.Name))
            {
                errors.Add(new ValidationExceptions($"{entityPath}name", "Поле не должно быть пустым", "Поле name пустое"));
            }
            if (!ValidateString(entity.Surname))
            {
                errors.Add(new ValidationExceptions($"{entityPath}surname", "Поле не должно быть пустым", "Поле name пустое"));
            }
            if (!ValidateString(entity.Patronymic))
            {
                errors.Add(new ValidationExceptions($"{entityPath}patronymic", "Поле не должно быть пустым", "Поле name пустое"));
            }

            if (entity.CurWorkExp == null || !ValidateRealNumber((float)entity.CurWorkExp.Value, true))
            {
                errors.Add(new ValidationExceptions($"{entityPath}curWorkExp", "Число должно быть больше или равно нулю", "Число меньше нуля"));
            }
            if (entity.MonIncome == null || !ValidateRealNumber((float)entity.MonIncome.Value, true))
            {
                errors.Add(new ValidationExceptions($"{entityPath}monIncome", "Число должно быть больше или равно нулю", "Число меньше нуля"));
            }
            if (entity.MonExpenses == null || !ValidateRealNumber((float)entity.MonExpenses.Value, true))
            {
                errors.Add(new ValidationExceptions($"{entityPath}monExpenses", "Число должно быть больше или равно нулю", "Число меньше нуля"));
            }
            if (!ValidateDate(entity.Dob))
            {
                errors.Add(new ValidationExceptions($"{entityPath}dob", "Неккоректная дата", "Дата должна быть в промежутке от 1900 до текущей даты"));
            }

            var values = Enumerable.Range((int)EducationTypeEnum.Secondary, (int)EducationTypeEnum.AcademicDegree + 1)
                        .Select(i => (EducationTypeEnum)i).ToList();
            if (!values.Contains(entity.TypeEducation))
            {
                errors.Add(new ValidationExceptions($"{entityPath}educationType", "IsEnum", "Поле не является enum"));
            }

            var livingAddressValidationResult = new AddressValidation(entity.LivingAddress, $"{entityPath}livingAddress").Validate();
            if (livingAddressValidationResult.Any())
            {
                errors.AddRange(livingAddressValidationResult);
            }
            var regAddressValidationResult = new AddressValidation(entity.RegAddress, $"{entityPath}regAddress").Validate();
            if (regAddressValidationResult.Any())
            {
                errors.AddRange(regAddressValidationResult);
            }
            var passportValidationResult = new PassportValidation(entity.Passport, $"{entityPath}passport").Validate();
            if (passportValidationResult.Any())
            {
                errors.AddRange(passportValidationResult);
            }

            if (entity.Children.Any())
            {
                int i = 0;
                foreach (var child in entity.Children)
                {
                    var childValidationResult = new ChildValidation(child, $"{entityPath}child.{i}").Validate();
                    if (childValidationResult.Any())
                    {
                        errors.AddRange(childValidationResult);
                    }
                    i++;
                }
            }
            if (entity.Jobs.Any())
            {
                int i = 0;
                foreach (var job in entity.Jobs)
                {
                    var jobValidationResult = new JobValidation(job, $"{entityPath}job.{i}").Validate();
                    if (jobValidationResult.Any())
                    {
                        errors.AddRange(jobValidationResult);
                    }
                    i++;
                }
            }
            if (entity.Communications.Any())
            {
                int i = 0;
                foreach (var communication in entity.Communications)
                {
                    var communicationValidationResult = new CommunicationValidation(communication, $"{entityPath}communication.{i}").Validate();
                    if (communicationValidationResult.Any())
                    {
                        errors.AddRange(communicationValidationResult);
                    }
                    i++;
                }
            }

            return errors;

        }

    }
}
