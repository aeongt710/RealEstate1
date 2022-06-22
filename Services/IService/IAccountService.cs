using Microsoft.AspNetCore.Identity;
using RealEstate1.Models;
using RealEstate1.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate1.Services.IService
{
    public interface IAccountService
    {
        public Task<string> RegisterNewUser(RegisterVM registerVM);
        public Task<bool> Login(LoginViewModel loginVM);
        public Task Logout();

        public List<IdentityRole> GetRoles();
        public Task<string> CreateRole(string Name);
        public IdentityRole GetRoleById(string roleId);

    }
}
