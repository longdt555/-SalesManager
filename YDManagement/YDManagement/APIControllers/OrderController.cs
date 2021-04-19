using AutoMapper;
using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Lib.Service.Services.IServices;
using YDManagement.Helpers;

namespace YDManagement.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
            _mapper = mapper;
        }

        // GET: api/<ProductController>
        [AllowAnonymous]
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var data = _orderService.GetAll();
            return Ok(data);
        }

        // GET api/<ProductController>/5
        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            var data = _orderService.GetById(id);
            return Ok(data);
        }

        // POST api/<ProductController>
        [HttpPost("ClientCreate")]
        public IActionResult ClientCreate([FromBody] OrderDto model)
        {
            IActionResult response = Unauthorized();
            var result = new JResultHelper();
            try
            {
                var today = DateTime.Now;
                var currentUser = ClientCurrentUser.Id;
                var data = _mapper.Map<Order>(model);
                if (_productService.IsOutOfStock(data.ProductId, data.Quantity))
                    return Ok(new {StatusCode = StatusCodes.Status409Conflict, Message = AppCodeStatus.OutOfStock});

                data.CustomerId = currentUser;
                data.CreatedBy = currentUser;
                data.CreatedDate = today;
                _orderService.Create(data);
                var dataDto = _mapper.Map<OrderDto>(data);

                var productDto = _productService.GetById(dataDto.ProductId);
                if (productDto == null) return Ok(dataDto);
                var product = _mapper.Map<Product>(productDto);
                product.Quantity -= dataDto.Quantity;
                _productService.Update(product);
                return Ok(dataDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} {ex.StackTrace}");
                return response;
            }
        }

        // POST api/<ProductController>

        [HttpPost("AdminCreate")]
        public IActionResult AdminCreate([FromBody] OrderDto model)
        {
            try
            {
                var today = DateTime.Now;
                var currentUser = AdminCurrentUser.Id;
                var data = _mapper.Map<Order>(model);
                data.CreatedBy = currentUser;
                data.CreatedDate = today;
                _orderService.Create(data);
                var dataDto = _mapper.Map<OrderDto>(data);
                return Ok(dataDto);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] OrderDto model)
        {
            var data = _mapper.Map<Order>(model);
            try
            {
                _orderService.Update(data);
                return Ok();
            }
            catch (AppException ex)
            {
                Console.WriteLine($"{ex.Message} {ex.StackTrace}");
                return BadRequest();
            }
        }

        // DELETE api/<CategoryController>/5

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _orderService.Delete(id);
            return Ok();
        }
    }
}