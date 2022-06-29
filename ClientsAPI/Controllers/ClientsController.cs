using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClientsAPI.Data;
using ClientsAPI.Data.Entities;
using ClientsAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;
using ClientsAPI.Models.Filters;
using ClientsAPI.Models.Errors;
using ClientsAPI.Models.Validation;
using Microsoft.AspNetCore.JsonPatch;

namespace ClientsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly TestTaskClientsContext _context;

        public ClientsController(TestTaskClientsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: Листинг клиентов
        /// </summary>
        /// <param name="sortBy">Параметр сортировки</param>
        /// <param name="sortDir">Направление сортировки</param>
        /// <param name="limit">Количество элементов на старинце</param>
        /// <param name="page">Номер страницы</param>
        /// <param name="search">Стркоа поиска</param>
        /// <returns>Результат фильтации или ошибка валидации/сервера/сущьность не найдена</returns>
        [HttpGet]
        public async Task<ActionResult<Client>> GetClients([System.Runtime.InteropServices.DefaultParameterValue("createdAt")] string sortBy, SortDirEnum sortDir, EducationTypeEnum educationType, int limit = 10, int page = 1, string search = "Ива")
        {

            var filter = new ClientsFilter(search, sortBy, sortDir, educationType, page, limit);

            var validationResult = new FilterValidation<Client>(filter).Validate();
            if (validationResult.Count() > 0)
            {
                return StatusCode(422, new ValidationError(new List<ValidationExceptions>(validationResult)));
            }

            //Загрузка связанных данных и фильтрация
            var clients = _context.Clients
                .Include(p => p.Children)
                .Include(p => p.LivingAddress)
                .Include(p => p.RegAddress)
                .Include(p => p.Communications)
                .Include(p => p.DocumentIds)
                .Include(p => p.Passport)
                .Include(p => p.Jobs)
                    .ThenInclude(p => p.FactAddress)
                .Include(p => p.Jobs)
                    .ThenInclude(p => p.JurAddress)
                .Where(filter.FilterExpression)
                .AsEnumerable();

            int totalCount = clients.Count();
            if (filter.SortDir == SortDirEnum.ask)
            {
                clients = clients.OrderBy(p => p.GetProperty(filter.SortBy));
            }
            else
            {
                clients = clients.OrderByDescending(p => p.GetProperty(filter.SortBy));
            }
            //Выборка диапозона клиентов
            var resultClients = clients.Skip((filter.Page - 1) * filter.Limit).Take(filter.Limit);

            return Ok(new PaginationResponseBody<Client>(limit, page, totalCount, resultClients));
        }

        /// <summary>
        /// GET: Просмотр клиента
        /// </summary>
        /// <param name="id">Идентификатор клиента</param>
        /// <returns>Возврат клиента с этим идентификатором</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(Guid id)
        {
            try
            {
                var exeptions = new List<ValidationExceptions>();

                //Валидация Id
                if (!new GuidValidation().IsValid(id))
                {
                    var validationException = new ValidationExceptions("client.id", "not empty", "id is empty");
                    exeptions.Add(validationException);
                }

                if (exeptions.Count() > 0)
                {
                    return StatusCode(422, new ValidationError(new List<ValidationExceptions>(exeptions)));
                }

                var client = await _context.Clients.Include(p => p.Children)
                .Include(p => p.LivingAddress)
                .Include(p => p.RegAddress)
                .Include(p => p.Communications)
                .Include(p => p.DocumentIds)
                .Include(p => p.Passport)
                .Include(p => p.Jobs)
                    .ThenInclude(p => p.FactAddress)
                .Include(p => p.Jobs)
                    .ThenInclude(p => p.JurAddress)
                .FirstOrDefaultAsync(p => p.Id == id);

                var a = client.LivingAddress.ToString();

                if (client == null)
                {
                    return NotFound(new EntityNotFoundError());
                }

                return Ok(client);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ServerError(500));
            }
        }

        /// <summary>
        /// PATCH: Частичное обновление клиента
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchClient"></param>
        /// <returns></returns>
        [HttpPatch("id")]
        public async Task<ActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<Client> patchClient)
        {
            try
            {
                var exeptions = new List<ValidationExceptions>();

                //Валидация Id
                if (!new GuidValidation().IsValid(id))
                {
                    var validationException = new ValidationExceptions("id", "Поле не должно быть пустым", "Поле id пустое");
                    exeptions.Add(validationException);
                }

                if (exeptions.Count() > 0)
                {
                    return StatusCode(422, new ValidationError(new List<ValidationExceptions>(exeptions)));
                }

                var client = await _context.Clients.Include(p => p.Children)
                    .Include(p => p.LivingAddress)
                    .Include(p => p.RegAddress)
                    .Include(p => p.Communications)
                    .Include(p => p.DocumentIds)
                    .Include(p => p.Passport)
                    .Include(p => p.Jobs)
                        .ThenInclude(p => p.FactAddress)
                    .Include(p => p.Jobs)
                        .ThenInclude(p => p.JurAddress)
                    .FirstOrDefaultAsync(p => p.Id == id);
                if (client == null)
                {
                    return NotFound(new EntityNotFoundError());
                }

                patchClient.ApplyTo(client, ModelState);
              
                client.Update();

                //_context.Clients.Update(client);
                _context.Entry(client).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return StatusCode(204, "Клиент успешно обновлён");
            }
            catch
            {
                return StatusCode(500, new ServerError(500));
            }
        }

        /// <summary>
        /// POST: Добавление клиента
        /// </summary>
        /// <param name="client">Клиент, отправленный с другого приложения</param>
        /// <returns>Возврат id созданного клиента или ошибка</returns>
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(ClientWithSpouse client)
        {
            try
            {
                Client tempClient = client;
                var exeptions = new List<ValidationExceptions>();
                var clientValidationResult = new ClientValidation(tempClient).Validate();
                if (tempClient is ClientWithSpouse clWithCpouse)
                {
                    if (clWithCpouse.Spouse.DocumentIds.Any())
                    {
                        int i = 0;
                        foreach (var document in tempClient.DocumentIds)
                        {
                            if (_context.Documents.Find(document.Id) != null)
                            {
                                exeptions.Add(new ValidationExceptions($"spouse.document.{i}.id", "Уникальный идентификатор", "Такой идентификатор уже существует"));
                            }
                            i++;
                        }
                    }
                    if (clWithCpouse.Spouse == null)
                    {
                        tempClient = client.Copy();
                    }
                    else
                    {
                        var spouseValidationResult = new ClientValidation(clWithCpouse.Spouse, "spouse").Validate();
                        if (spouseValidationResult.Any())
                        {
                            exeptions.AddRange(spouseValidationResult);                           
                        }
                    }
                }
                if (tempClient.DocumentIds.Any())
                {
                    int i = 0;
                    foreach (var document in tempClient.DocumentIds)
                    {
                        if (_context.Documents.Find(document.Id) != null)
                        {
                            exeptions.Add(new ValidationExceptions($"document.{i}.id", "Уникальный идентификатор", "Такой идентификатор уже существует"));
                        }
                        i++;
                    }
                }
                if (clientValidationResult.Any())
                {
                    exeptions.AddRange(clientValidationResult);
                    return StatusCode(422, new ValidationError(new List<ValidationExceptions>(exeptions)));
                }
                _context.Clients.Add(tempClient);
                await _context.SaveChangesAsync();

                return StatusCode(201, tempClient.Id);
            }
            catch
            {
                return StatusCode(500, new ServerError(500));
            }
        }

        /// <summary>
        /// DELETE: Мягкое удаление
        /// </summary>
        /// <param name="id">Идентификатор клиента</param>
        /// <returns>Сообщени об успешной операции</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            //Ставим дату удаления как текущую дату
            client.Delete();
            await _context.SaveChangesAsync();

            return StatusCode(204, "Клиент мягко удалён");
        }

        private bool ClientExists(Guid id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
