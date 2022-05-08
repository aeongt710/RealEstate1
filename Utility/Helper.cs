using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace RealEstate1.Utility
{
    public class Helper
    {

        public static string Admin = "Admin";
        public static string Buyer = "Buyer";
        public static List<SelectListItem> GetRolesDropDownList()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value=Helper.Admin, Text=Admin},
                new SelectListItem{Value=Helper.Buyer, Text=Buyer}
            };
        }
    }
}
