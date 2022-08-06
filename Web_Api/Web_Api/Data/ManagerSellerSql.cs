using Microsoft.EntityFrameworkCore;
using Web_Api.Models;

namespace Web_Api.Data
{
    public class ManagerSellerSql : IManagerSeller
    {
        private manager_sellerContext Manager_SellerContext { get; }
        public ManagerSellerSql(manager_sellerContext _manager_SellerContext)
        {
            Manager_SellerContext = _manager_SellerContext;
        }


        public List<User> GetUser()
        {
           return Manager_SellerContext.Users.ToList();
        }
    }
}
