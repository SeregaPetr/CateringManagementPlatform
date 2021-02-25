using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.AdminPanel.DTO.TableDtos;
using CateringManagementPlatform.BLL.AdminPanel.Interfaces;
using CateringManagementPlatform.DAL.Entities;
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

            return table.Id;
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
            _repository.Tables.Update(table);
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
            table = _mapper.Map<Table>(tableUpdateDto);

            _repository.Tables.Update(table);
            await _repository.SaveAsync();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
