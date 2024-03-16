using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApi.MessageHandler;
using StoreApi.Model;
using StoreApi.Repo;

namespace StoreApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {

        List<Invoice> invoices;
        IConfiguration _configuration;
        public InvoicesController(IConfiguration ic) {
            _configuration = ic;
            invoices = DbContext.Invoices();
        }
        [HttpGet]
        public async Task<IEnumerable<Invoice>> Invoices( )=>   invoices;

        [HttpGet("{id}")]
        public async Task< Invoice> Invoices(int id) =>  invoices.Where(_=>_.Id==id).FirstOrDefault();

        [HttpPost]
        public async Task<IEnumerable<Invoice>> Invoices(Invoice inv) { 
            invoices.Add(inv);
            MessageBrokerHandler msg = new(_configuration);
            msg.ConnectMq();
            return invoices;
        }

    }
}
