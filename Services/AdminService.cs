using Microsoft.AspNetCore.Hosting;
using RealEstate1.Models;
using RealEstate1.Models.ViewModels;
using RealEstate1.Services.IService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RealEstate1.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDBContext _dbContext;
        private IHostingEnvironment _environment;

        public AdminService(ApplicationDBContext dBContext, IHostingEnvironment environment)
        {
            _dbContext = dBContext;
            _environment= environment;
        }

        public bool CreateNewSociety(SocietyCreateVM societyCreateVM)
        {
            Society society = new Society()
            {
                SocietyName = societyCreateVM.Society.SocietyName,
                Latitude = societyCreateVM.Society.Latitude,
                Longitude = societyCreateVM.Society.Longitude,
                City = societyCreateVM.Society.City,
                Description = societyCreateVM.Society.Description

            };
            var img = societyCreateVM.Image;
            if (img != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "img/society");

                var imgId=Guid.NewGuid().ToString();
                var extension = img.FileName.Substring(img.FileName.IndexOf(".") +1);
                
                string filePath = Path.Combine(uploadsFolder, imgId +"."+ extension);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    img.CopyTo(fileStream);
                }
                society.ImgSrc = imgId +"." + extension;
                _dbContext.Add(society);
                var result = _dbContext.SaveChanges();
                if(result>0)
                    return true;
            }
            return false;
        }



        public bool DeleteSocietyById(int id)
        {
            _dbContext.Societies.Remove(new Society { Id = id });
            var result = _dbContext.SaveChanges();
            if (result > 0)
                return true;
            return false;
        }

        public List<Society> GetScoieties()
        {
            return _dbContext.Societies.Include(a=>a.SocietyBlocks).ToList();
        }

        public Society GetSocietyById(int id)
        {
            return _dbContext.Societies.FirstOrDefault(a => a.Id == id);
        }

        public bool SaveEditedSociety(Society society)
        {
            _dbContext.Update(society);
            var result=_dbContext.SaveChanges();
            if (result > 0)
                return true;
            return false;
        }



        public List<Block> GetBlocksBySocietyId(int societyId)
        {
            return _dbContext.Blocks
                        .Include(a => a.Society)
                            .Where(a => a.SocietyId == societyId)
                                .ToList();
        }

        public bool AddNewBlock(Block block)
        {
            _dbContext.Add(block);
            var result = _dbContext.SaveChanges();
            if (result > 0)
                return true;
            return false;
        }

        public bool UpdateBlock(Block block)
        {
            _dbContext.Update(block);
            var result=_dbContext.SaveChanges();
            if (result > 0)
                return true;
            return false;
        }

        public Block GetBlockById(int id)
        {
            return _dbContext.Blocks.FirstOrDefault(a => a.Id == id);
        }

        public bool DeleteLockById(int id)
        {
            _dbContext.Blocks.Remove(new Block() { Id= id });
            var result = _dbContext.SaveChanges();
            if (result > 0)
                return true;
            return false;
        }

    }
}
