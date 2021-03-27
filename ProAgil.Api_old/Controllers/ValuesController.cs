using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProAgil.Api.Model;

namespace ProAgil.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Event>> Get()
        {
            return new Event[]
            {
                new Event()
                {
                    IdEvent = 1,
                    Subject = "Angular & .Net Core",
                    Local = "EAD",
                    Lot = "1st Lot",
                    GuestsQty = 250,
                    EventDate = DateTime.Now.AddDays(10).ToString("dd/MM/yyyy")
                },
                  new Event()
                {
                    IdEvent = 2,
                    Subject = "Angular and news",
                    Local = "EAD",
                    Lot = "2nd Lot",
                    GuestsQty = 350,
                    EventDate = DateTime.Now.AddDays(12).ToString("dd/MM/yyyy")
                }             
            };
        }
        [HttpGet("{id}")]
        public ActionResult<Event> Get(int id)
        {
            return new Event[]
            {
                new Event()
                {
                    IdEvent = 1,
                    Subject = "Angular & .Net Core",
                    Local = "EAD",
                    Lot = "1st Lot",
                    GuestsQty = 250,
                    EventDate = DateTime.Now.AddDays(10).ToString("dd/MM/yyyy")
                },
                new Event()
                {
                    IdEvent = 2,
                    Subject = "Angular and news",
                    Local = "EAD",
                    Lot = "2nd Lot",
                    GuestsQty = 350,
                    EventDate = DateTime.Now.AddDays(12).ToString("dd/MM/yyyy")
                }             
            }.FirstOrDefault(x=>x.IdEvent == id);
        }
    }
}
