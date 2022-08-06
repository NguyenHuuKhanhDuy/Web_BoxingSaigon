using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : Controller
    {

        private readonly manager_sellerContext dbContext;
        public SupplierController(manager_sellerContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Route("GetAll")]

        public async Task<IActionResult> GetAll()
        {
            List<Supplier> suppliers = new List<Supplier>();

            suppliers = await dbContext.Suppliers.ToListAsync();
            return Ok(suppliers);
        }

        [HttpGet]
        [Route("GetById/{id}")]

        public async Task<IActionResult> GetById(String id)
        {
            var Supplier = await dbContext.Suppliers.FindAsync(id);
            if (Supplier != null)
            {
                return Ok(Supplier);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> AddSupplier(Supplier supplier)
        {
            await dbContext.Suppliers.AddAsync(supplier);
            await dbContext.SaveChangesAsync();
            return Ok(supplier);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateSupplier(Supplier supplier_temp)
        {
            var supplier = await dbContext.Suppliers.FindAsync(supplier_temp.SupplierId);
            if (supplier != null)
            {
                supplier.Name = supplier_temp.Name;
                supplier.ContactSup = supplier_temp.ContactSup;
                supplier.Address = supplier_temp.Address;
                await dbContext.SaveChangesAsync();
                return Ok(supplier);
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DaleteSupplier(Supplier Supplier_temp)
        {
            var Supplier = await dbContext.Suppliers.FindAsync(Supplier_temp.SupplierId);
            if (Supplier != null)
            {
                dbContext.Remove(Supplier);
                dbContext.SaveChangesAsync();
                return Ok(Supplier);
            }

            return NotFound();
        }
    }
}
