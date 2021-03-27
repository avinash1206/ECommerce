using ECommerce.Services.Models;
using ECommerce.Services.Repository.EntityFramework.Models;
using ECommerce.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class OrderController : Controller
    {
        private readonly ICustomerService _customerService;

        public OrderController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<string> OrderDetails(List<OrderDetails> orderDetails)
        {
            return await _customerService.CreateorderDetails(orderDetails);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(List<OrderDetail>), StatusCodes.Status200OK)]
        public async Task<List<OrderDetail>> GetOrderDeatails([FromQuery] string customerEmail)
        {
            return await _customerService.GetOrderDeatails(customerEmail);
        }
    }
}
