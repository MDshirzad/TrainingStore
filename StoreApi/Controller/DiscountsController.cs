using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApi.Model;
using StoreApi.Repo;

namespace StoreApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        List<DiscountCode> discountCodes;
        public DiscountsController() {

            discountCodes= DbContext.DiscountCodes();
        }

        [HttpGet]
        public async Task<IEnumerable<DiscountCode>>   DiscountCodes() =>  discountCodes ;

        [HttpGet("{id}")]
        public async Task<DiscountCode>? DiscountCode(int id) => discountCodes.Where(_ => _.Id == id).FirstOrDefault();

        [HttpPost]
        public async Task<IEnumerable<DiscountCode>> DiscountCodes(DiscountCode dc) { 
             discountCodes.Add(dc);
            return discountCodes;
        }

    }
}
