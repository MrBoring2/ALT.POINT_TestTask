using ClientsAPI.Data.Entities;
using ClientsAPI.Models.Enums;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ClientsAPI.Models.Validation
{
    public class CommunicationValidation : EntityValidation<Communication>
    {
        private readonly string entityPath;
        public CommunicationValidation(Communication entity, string entityPath) : base(entity)
        {
            this.entityPath = entityPath;
        }

        public override IEnumerable<ValidationExceptions> Validate()
        {
            List<ValidationExceptions> errors = new List<ValidationExceptions>();
            if (entity.Type != CommunicationTypeEnum.Email && entity.Type != CommunicationTypeEnum.Phone)
            {
                errors.Add(new ValidationExceptions($"{entityPath}.type", "IsEnum", "Поле не является Enum"));
                return errors;
            }

            if (entity.Type == CommunicationTypeEnum.Email)
            {
                var email = Regex.Replace(entity.Value, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }


                if (!Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
                {
                    errors.Add(new ValidationExceptions($"{entityPath}.value", "Неккоректный ввод", "Поле email введено неверно"));
                    return errors;
                }
            }
            else if (entity.Type == CommunicationTypeEnum.Phone)
            {
                if (!ValidateStringAsNumber(entity.Value, 11, 11))
                {
                    errors.Add(new ValidationExceptions($"{entityPath}.value", "Неккоректный ввод", "Поле phoneNumber введено неверно"));
                    return errors;
                }
            }

            return errors;
        }

    }
}
