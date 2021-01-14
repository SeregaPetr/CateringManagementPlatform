using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.DTO.TableDtos;
using CateringManagementPlatform.BLL.Infrastructure;
using CateringManagementPlatform.BLL.Interfaces;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.BLL.Services
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
            var table = _mapper.Map<Table>(tableCreateDto);

            _repository.Tables.Create(table);
            await _repository.SaveAsync();

            return table.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var table = await _repository.Tables.GetByIdAsync(id);
            if (table == null)
            {
                throw new ValidationException("Стол не найден", "");
            }
            _repository.Tables.Delete(table);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<TableReadDto>> GetAllAsync()
        {
            var tables = await _repository.Tables.GetAllAsync();
            return _mapper.Map<IEnumerable<TableReadDto>>(tables);
        }

        public async Task<TableReadDto> GetByIdAsync(int id)
        {
            var table = await _repository.Tables.GetByIdAsync(id);
            if (table == null)
            {
                throw new ValidationException("Стол не найден", "");
            }
            return _mapper.Map<TableReadDto>(table);
        }

        public async Task UpdateAsync(TableUpdateDto tableUpdateDto)
        {
            var table = await _repository.Tables.GetByIdAsync(tableUpdateDto.Id);
            if (table == null)
            {
                throw new ValidationException("Стол не найден", "");
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
