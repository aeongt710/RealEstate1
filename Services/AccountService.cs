using Microsoft.AspNetCore.Identity;
using RealEstate1.Models;
using RealEstate1.Models.ViewModels;
using RealEstate1.Services.IService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate1.Services
{
    public class AccountService : IAccountService
    {
        public readonly ApplicationDBContext _dbContext;
        UserManager<ApplicationUser> _userManager;
        SignInManager<ApplicationUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;

        public AccountService(ApplicationDBContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager
            , RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _dbContext = db;
        }

        public async Task<bool> Login(LoginViewModel vm)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, vm.RememberMe, false);
            if (signInResult.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<string> RegisterNewUser(RegisterVM registerVM)
        {
            var _user = new ApplicationUser
            {
                Email = registerVM.Email,
                Name = registerVM.Name,
                UserName = registerVM.Email
            };
            var result = _userManager.CreateAsync(_user, registerVM.Password).Result;
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(_user, isPersistent: false);
            }
            else
            {
                string output = string.Empty;
                foreach (var item in result.Errors)
                {
                    output = output + item.Description;
                }
                return output;
            }
            return null;
        }
        public List<IdentityRole> GetRoles()
        {
            return _roleManager.Roles.ToList();
        }
        public async Task<string> CreateRole(string name)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(name));
            if (result.Succeeded)
            {
                await _signInManager.SignOutAsync();
            }
            else
            {
                string output = string.Empty;
                foreach (var item in result.Errors)
                {
                    output = output + item.Description;
                }
                return output;
            }
            return null;
        }
        public IdentityRole GetRoleById(string roleId)
        {
            return _roleManager.Roles.Where(a => a.Id == roleId).FirstOrDefault();
        }
    }
}
