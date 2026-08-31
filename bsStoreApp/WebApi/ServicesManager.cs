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
        private readonly IBookServices _bookServices;
        private readonly ICategoryService _categoryService;
        private readonly IAuthenticationService _authenticationService;

        public ServicesManager(IBookServices bookServices, ICategoryService categoryService, 
            IAuthenticationService authenticationService)
        {
            _bookServices = bookServices;
            _categoryService = categoryService;
            _authenticationService = authenticationService;
        }

        public IBookServices BookServices => _bookServices;

        public IAuthenticationService AuthenticationService => _authenticationService;

        public ICategoryService CategoryService => _categoryService;
    }
}
