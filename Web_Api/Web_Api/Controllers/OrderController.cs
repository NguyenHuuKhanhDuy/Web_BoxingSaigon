using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly manager_sellerContext dbContext;
        public OrderController(manager_sellerContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Route("GetAll")]

        public async Task<IActionResult> GetAll()
        {
            List<Order> orders = new List<Order>();

            orders = await dbContext.Orders.ToListAsync();
            return Ok(orders);
        }

        [HttpGet]
        [Route("GetById/{id}")]

        public async Task<IActionResult> GetById(String id)
        {
            var order = await dbContext.Orders.FindAsync(id);
            if (order != null)
            {
                return Ok(order);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> AddOrder(Order order)
        {
            await dbContext.Orders.AddAsync(order);
            await dbContext.SaveChangesAsync();
            return Ok(order);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateOrder(Order order_temp)
        {
            var order = await dbContext.Orders.FindAsync(order_temp.OrderId);
            if (order != null)
            {
                order.OrderDate = order_temp.OrderDate;
                order.SoldById = order_temp.SoldById;
                order.SoldByName = order_temp.SoldByName;
                order.Total = order_temp.Total;
                order.Discount = order_temp.Discount;
                order.TotalPayment = order_temp.TotalPayment;
                order.CustomerId = order_temp.CustomerId;
                order.CustomerName = order_temp.CustomerName;
                await dbContext.SaveChangesAsync();
                return Ok(order);
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DaleteOrder(Order order_temp)
        {
            var order = await dbContext.Orders.FindAsync(order_temp.OrderId);
            if (order != null)
            {
                dbContext.Remove(order);
                dbContext.SaveChangesAsync();
                return Ok(order);
            }

            return NotFound();
        }
    }
}
