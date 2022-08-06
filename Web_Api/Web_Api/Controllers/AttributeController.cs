

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttributeController : Controller
    {
        private readonly manager_sellerContext dbContext;
        public AttributeController(manager_sellerContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetAll")]

        public async Task<IActionResult> GetAll()
        {   AttributeModel AttributeModel1 = new AttributeModel();
            List<AttributeModel> attributeModels = new List<AttributeModel>();

            attributeModels = await dbContext.Attributes.ToListAsync();
            return Ok(attributeModels);
        }

        [HttpGet]
        [Route("GetById/{id}")]

        public async Task<IActionResult> GetById(String id)
        {
            var AttributeModel = await dbContext.Attributes.FindAsync(id);
            if (AttributeModel != null)
            {
                return Ok(AttributeModel);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> AddAttributeModel(AttributeModel AttributeModel)
        {
            await dbContext.Attributes.AddAsync(AttributeModel);
            await dbContext.SaveChangesAsync();
            return Ok(AttributeModel);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateAttributeModel(AttributeModel attributeModel_temp)
        {
            var attributeModel = await dbContext.Attributes.FindAsync(attributeModel_temp.AttributesId);
            if (attributeModel != null)
            {
                attributeModel.AttributesName = attributeModel_temp.AttributesName;
                attributeModel.AttributesValue = attributeModel_temp.AttributesValue;
                await dbContext.SaveChangesAsync();
                return Ok(attributeModel);
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DaleteAttributeModel(AttributeModel attributeModel_temp)
        {
            var attributeModel = await dbContext.Attributes.FindAsync(attributeModel_temp.AttributesId);
            if (attributeModel != null)
            {
                dbContext.Remove(attributeModel);
                dbContext.SaveChangesAsync();
                return Ok(attributeModel);
            }

            return NotFound();
        }
    }
}
