using AutoMapper;
using Lib.Common.Global;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace YDManagement.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }


        // GET: api/<CategoryController>
     
        [AllowAnonymous]
        // GET api/<CategoryController>/5
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _customerService.GetAll();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _customerService.GetById(id);
            return Ok(data);
        }

        // POST api/<CategoryController>
        [AllowAnonymous]
        [HttpPost("ClientCreate")]
        public IActionResult ClientCreate([FromBody] CustomerDto model)
        {
            IActionResult response = Unauthorized();
            try
            {
                #region token checking
                //if (!HasPermission()) return response;
                #endregion
                var today = DateTime.Now;
                var currentUser = LoggedOnClientUser.UserId;
                var data = _mapper.Map<Customer>(model);              
                data.CreatedBy = currentUser;
                data.CreatedDate = today;
                _customerService.Create(data);
                var dataDto = _mapper.Map<CustomerDto>(data);
                return Ok(dataDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} {ex.StackTrace}");
                return response;
            }

        }
        [Authorization.Authorize]
        [HttpPost("AdminCreate")]
        public IActionResult AdminCreate([FromBody] CustomerDto model)
        {
            try
            {
                var today = DateTime.Now;
                var currentUser = LoggedOnAdminUser.UserId;
                var data = _mapper.Map<Customer>(model);
                data.CreatedBy = currentUser;
                data.CreatedDate = today;
                _customerService.Create(data);
                var dataDto = _mapper.Map<CustomerDto>(data);
                return Ok(dataDto);
            }
            catch
            {
                return BadRequest();
            }
        }
        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
