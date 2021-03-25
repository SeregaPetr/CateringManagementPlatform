using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.AdminPanel.DTO.TableDtos;
using CateringManagementPlatform.BLL.AdminPanel.Interfaces;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Entities.People;
using CateringManagementPlatform.DAL.Interfaces;
using MyValidationException;

namespace CateringManagementPlatform.BLL.AdminPanel.Services
{
    public class TableService : ITableService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public TableService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(TableCreateDto tableCreateDto)
        {
            if (tableCreateDto == null)
            {
                throw new ValidationException("Введите данные", "");
            }

            await TestForTableExistence(tableCreateDto.NumberTable);

            var table = _mapper.Map<Table>(tableCreateDto);

            _repository.Tables.Create(table);
            await _repository.SaveAsync();

            await CreateAccout(table);

            return table.Id;
        }

        private async Task CreateAccout(Table table)
        {
            var accaunt = new Account()
            {
                Email = $"table{table.NumberTable}@mail.com",
                Password = new PasswordLib.Passwor().Creare(5),
                TableId = table.Id,
            };

            var userRoles = await _repository.UserRoles.GetAllAsync();
            var userRoleId = userRoles.FirstOrDefault(u => u.RoleName == "User").Id;
            var userRole = await _repository.UserRoles.GetByIdAsync(userRoleId);
            userRole.Accounts.Add(accaunt);
            await _repository.SaveAsync();
        }

        private async Task TestForTableExistence(int numberTable)
        {
            var tables = await _repository.Tables.GetAllAsync();
            var tableExists = tables.Any(t => t.NumberTable == numberTable && t.IsArchive == false);

            if (tableExists)
            {
                throw new ValidationException("Стол уже существует", "");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var table = await _repository.Tables.GetByIdAsync(id);
            if (table == null || table.IsArchive == true)
            {
                throw new ValidationException("Стол не найден", "");
            }
            table.IsArchive = true;

            //TODO: акаунт не удаляется
            //var account = await _repository.Accounts.GetByIdAsync(table.Account.Id);
            //_repository.Accounts.Delete(account);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<TableReadDto>> GetAllAsync()
        {
            var allTables = await _repository.Tables.GetAllAsync();
            var tables = allTables.Where(t => t.IsArchive == false);
            return _mapper.Map<IEnumerable<TableReadDto>>(tables);
        }

        public async Task<TableReadDto> GetByIdAsync(int id)
        {
            var table = await _repository.Tables.GetByIdAsync(id);
            if (table == null || table.IsArchive == true)
            {
                throw new ValidationException("Стол не найден", "");
            }
            return _mapper.Map<TableReadDto>(table);
        }

        public async Task UpdateAsync(TableUpdateDto tableUpdateDto)
        {
            var table = await _repository.Tables.GetByIdAsync(tableUpdateDto.Id);
            if (table == null || table.IsArchive == true)
            {
                throw new ValidationException("Стол не найден", "");
            }

            if (table.NumberTable != tableUpdateDto.NumberTable)
            {
                await TestForTableExistence(tableUpdateDto.NumberTable);
            }

            table.Account.Email = $"table{tableUpdateDto.NumberTable}@mail.com";
            table.NumberTable = tableUpdateDto.NumberTable;
            table.NumberGuests = tableUpdateDto.NumberGuests;
            table.IsReservation = tableUpdateDto.IsReservation;
            table.CapacityTable = tableUpdateDto.CapacityTable;

            await _repository.SaveAsync();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
