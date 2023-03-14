using AutoMapper;
using BlazorFullStackCrud.Server.Common;
using BlazorFullStackCrud.Shared.DTO;
using Core.Interfaces.Service;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IWindowService _windowService;
        private readonly ISubElementService _subElementService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper, IWindowService windowService, ISubElementService subElementService)
        {
            _orderService = orderService;
            _windowService = windowService;
            _subElementService = subElementService;
            _mapper = mapper;   
        }

        #region Order 

        [HttpGet("orders")]
        public async Task<ActionResult<List<OrderDTO>>> GetOrdersData()
        {
            var orders = await _orderService.GetOrders();
            List<OrderDTO> orderDTO = _mapper.Map<List<OrderDTO>>(orders);
            return Ok(orderDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetSingleOrder(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound("Sorry, no order found. :/");
            }

            var orderDTO = _mapper.Map<OrderDTO>(order);
            return Ok(orderDTO);
        }

        [HttpPost]
        public async Task<ActionResult<List<Order>>> PostOrder(Order order)
        {

            try
            {
                await _orderService.AddOrder(order);

            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine(ex.Message);

            }

            return Ok(await GetOrdersData());
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<Order>>> UpdateOrder(Order order, int id)
        {
            await _orderService.UpdateOrder(order);

            return Ok(await GetOrdersData());
        }

        [HttpDelete("{id}")]
        public async Task DeleteOrder(int id)
        {
            await _orderService.DeleteOrder(id);
        }


        #endregion

        #region Window

        [HttpDelete("window-delete/{id}")]
        public async Task DeleteWindow(int id)
        {
            await _windowService.DeleteWindow(id);
        }

        #endregion

        #region Sub-Element

        [HttpDelete("subelement-delete/{id}")]
        public async Task DeleteSubElement(int id)
        {
            await _subElementService.DeleteSubElement(id);
        }
        #endregion
    }
}
