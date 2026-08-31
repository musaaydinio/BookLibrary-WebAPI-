using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EF_Core
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoriesContex _contex;
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepositroy _categoryRepository;

        public RepositoryManager(RepositoriesContex contex, IBookRepository bookRepository, 
            ICategoryRepositroy categoryRepository)
        {
            _contex = contex;
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        public IBookRepository Book => _bookRepository;

        public ICategoryRepositroy Category => _categoryRepository;

        public async Task SaveAsync()
        {
            await _contex.SaveChangesAsync();
        }
    }
}

   
 
 
   

