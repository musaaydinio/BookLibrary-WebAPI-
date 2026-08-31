using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface ICategoryRepositroy : IRepositoryBase<Category>
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
        Task<Category> GETOneCategoryById(int id, bool trackChanges);
        void CreateOneCteagory(Category category);
        void DeleteOneCteagory(Category category);
        void UpdateCteagory(Category category);

    }
}
