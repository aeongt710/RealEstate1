using RealEstate1.Models;
using RealEstate1.Models.ViewModels;
using System.Collections.Generic;

namespace RealEstate1.Services.IService
{
    public interface IAdminService
    {
        public bool CreateNewSociety(SocietyCreateVM societyCreateVM);
        public List<Society> GetScoieties();
        public Society GetSocietyById(int id);
        public bool DeleteSocietyById(int id);
        public bool SaveEditedSociety(Society society);




        public List<Block> GetBlocksBySocietyId(int societyId);
        public bool AddNewBlock(Block block);
        public bool UpdateBlock(Block block);
        public Block GetBlockById(int id);
        public bool DeleteLockById(int id);
    }
}
