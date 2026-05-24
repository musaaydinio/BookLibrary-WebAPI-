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
        private readonly Lazy<IBookRepository> _bookRepository;

        public RepositoryManager(RepositoriesContex contex)
        {
            _contex = contex;
            _bookRepository=new Lazy<IBookRepository>(()=>new BookRepository(_contex));
        }

        public IBookRepository Book => _bookRepository.Value;

        public async Task SaveAsync()
        {
            await _contex.SaveChangesAsync();
        }
    }
}

   
 
 
   

