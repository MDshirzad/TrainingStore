using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApi.Model;
using StoreApi.Repo;

namespace StoreApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {

        List<Invoice> invoices;
        public InvoicesController() {
            invoices = DbContext.Invoices();
        }
        [HttpGet]
        public async Task<IEnumerable<Invoice>> Invoices( )=>   invoices;

        [HttpGet("{id}")]
        public async Task< Invoice> Invoices(int id) =>  invoices.Where(_=>_.Id==id).FirstOrDefault();

        [HttpPost]
        public async Task<IEnumerable<Invoice>> Invoices(Invoice inv) { 
            invoices.Add(inv);
            return invoices;
        }

    }
}
