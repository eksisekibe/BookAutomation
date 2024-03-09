using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAutomation.Business.Abstract
{
    public interface IService<TRO, DTO>
    {
        Task<TRO> GetByIdAsync(int id);
        Task<List<TRO>> GetAllAsync();
        Task<bool> CreateAsync(DTO dto);
        Task<bool> UpdateAsync(int id, DTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
