using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Business;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet("{idCliente}")]
        public TblCliente GetCliente(string idCliente)
        {
            return new Business.Cliente().GetClienteById(Convert.ToInt32(idCliente));
        }
    }
}