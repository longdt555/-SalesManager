using AutoMapper;
using Lib.Common;
using Lib.Common.Global;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
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
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _orderService.GetAll();
            return Ok(data);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _orderService.GetById(id);
            return Ok(data);
        }

        // POST api/<ProductController>
        [AllowAnonymous]
        [HttpPost("ClientCreate")]
        public IActionResult ClientCreate([FromBody] OrderDto model)
        {
            IActionResult response = Unauthorized();
            try
            {
                #region token checking
                if (!HasPermission()) return response;
                #endregion
                var today = DateTime.Now;
                var currentUser = LoggedOnClientUser.UserId;
                var data = _mapper.Map<Order>(model);
                if (_productService.IsOutOfStock(data.ProductId, data.Quantity))
                    return Ok(new { StatusCode = StatusCodes.Status409Conflict, Message = AppCodeStatus.ErrorOutOfStock });

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
        [Authorization.Authorize]
        [HttpPost("AdminCreate")]
        public IActionResult AdminCreate([FromBody] OrderDto model)
        {
            try
            {
                var today = DateTime.Now;
                var currentUser = LoggedOnAdminUser.UserId;
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

        #region private funtions helper
        // client token checking
        private bool HasPermission()
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString(); // get token from the client
            return AppHelpers.ValidToken(accessToken);
        }
        #endregion
    }
}
