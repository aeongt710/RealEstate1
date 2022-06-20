using RealEstate1.Models;
using RealEstate1.Models.ViewModels;
using System.Collections.Generic;

namespace RealEstate1.Services.IService
{
    public interface IAdminService
    {
        public bool CreateNewSociety(SocietyCreateVM societyCreateVM);
        public List<Society> GetScoieties();
    }
}
