using Microsoft.AspNetCore.Mvc.Formatters;
using shoppingSite.Models;

namespace shoppingSite.Data
{
    public static class ApplicationCntx
    {
        public static List<Shopping> Computer { get; set; }
        static ApplicationCntx()
        {
            Computer = new List<Shopping>()
            {
                new Shopping() { Id=1,Title="MSI RTX 5090",Price=1000},
                new Shopping() { Id=2,Title="ASUS ANAKART",Price=500},
                new Shopping() { Id=3,Title="Monster Laptop",Price=2000},
            };
            
        }
        
    }
}
