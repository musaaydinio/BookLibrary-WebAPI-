using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoryiesAsync(bool trackChanges);
        Task<Category> GetOneCategoryByIdAsync(int id,bool trackChanges);
    }
}
