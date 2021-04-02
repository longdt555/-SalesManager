using AutoMapper;
using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace YDManagement.APIControllers
{
    [Route("api/customer-cart")]
    [ApiController]
    [Authorize]
    public class CustomerCartController : BaseController
    {
        private readonly ICustomerCartService _customerCartService;
        private readonly IMapper _mapper;

        public CustomerCartController(ICustomerCartService customerCartService, IMapper mapper)
        {
            _customerCartService = customerCartService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CustomerCartDto model)
        {
            IActionResult response = Unauthorized();
            var data = _mapper.Map<CustomerCart>(model);
            try
            {
                var today = DateTime.Now;
                data.CreatedDate = DateTime.Now;
                _customerCartService.Create(data);
                var dataDto = _mapper.Map<CustomerCartDto>(data);
                return Ok(dataDto);
            }
            catch (AppException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [AllowAnonymous]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CustomerCartDto model)
        {
            IActionResult response = Unauthorized();
            // map dto to entity and set id
            var data = _mapper.Map<CustomerCart>(model);
            try
            {
                data.UpdatedDate = DateTime.Now;
                _customerCartService.Update(data, 1);
                return Ok();
            }
            catch (AppException ex)
            {
                switch (ex.Message)
                {
                    case AppCodeStatus.ObjectNotFound:
                        return Ok(new
                        {
                            StatusCode = StatusCodes.Status404NotFound,
                            ex.Message
                        });
                    default:
                        // return error message if there was an exception
                        return BadRequest(new {message = ex.Message});
                }
            }
        }

        [AllowAnonymous]
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            _customerCartService.Delete(id);
            return Ok();
        }
    }
}