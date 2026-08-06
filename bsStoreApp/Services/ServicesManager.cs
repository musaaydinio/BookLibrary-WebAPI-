using AutoMapper;
using Entities.DataTranferObjcets;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServicesManager(IRepositoryManager respositoryManager, ILoggerService logger,
            IMapper mapper,UserManager<User> userManager,
            IBookLinks links,IConfiguration configuration)
        {
            _bookServices = new Lazy<IBookServices>(() => new BookManager(respositoryManager, 
                logger, mapper,links));
            _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationManager(logger, mapper, userManager, configuration));
        }
        public IBookServices BookServices => _bookServices.Value;

        public IAuthenticationService AuthenticationService => AuthenticationService;
    }
}
