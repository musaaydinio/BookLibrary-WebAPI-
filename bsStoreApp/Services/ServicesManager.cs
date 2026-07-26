using AutoMapper;
using Entities.DataTranferObjcets;
using Repository.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServicesManager : IServiceManager
    {
        private readonly Lazy<IBookServices> _bookServices;
        public ServicesManager(IRepositoryManager respositoryManager, ILoggerService logger, IMapper mapper,IBookLinks links)
        {
            _bookServices = new Lazy<IBookServices>(() => new BookManager(respositoryManager, logger, mapper,links));
        }
        public IBookServices BookServices => _bookServices.Value;
    }
}
