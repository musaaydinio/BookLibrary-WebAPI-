using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EF_Core
{
    public class CateagoryRespository : RepositoryBase<Category> ,ICategoryRepositroy
    {
        public CateagoryRespository(RepositoriesContex contex) : base(contex)
        {

        }

        public void CreateOneCteagory(Category category) => Create(category);

        public void DeleteOneCteagory(Category category)=>Delete(category);
       
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(n => n.CategoryName)
                .ToListAsync();
        }

        public async Task<Category> GETOneCategoryById(int id, bool trackChanges)
        {
            return await FindByCondition(n=>n.CategoryId.Equals(id),trackChanges)
                .SingleOrDefaultAsync();
        }

        public void UpdateCteagory(Category category)=>Update(category);
    }
}
