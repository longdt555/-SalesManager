using System;
using AutoMapper;
using Lib.Common.Helpers;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YDManagement.Helpers;

namespace YDManagement.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var result = new JResultHelper();
            result.SetStatusSuccess();
            var data = _customerService.GetAll();
            result.SetData(data);
            return Ok(result);
        }

        // GET api/<CategoryController>/5
        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            var result = new JResultHelper();
            var data = _customerService.GetById(id);
            result.SetData(data);
            return Ok(result);
        }

        // POST api/<CategoryController>

        [HttpPost("create")]
        public IActionResult Create([FromBody] CustomerDto model)
        {
            try
            {
                var today = DateTime.Now;
                var data = _mapper.Map<Customer>(model);
                data.CreatedDate = today;
                _customerService.Create(data);
                var dataDto = _mapper.Map<CustomerDto>(data);
                return Ok(dataDto);
            }
            catch (AppException ex)
            {
                Console.WriteLine($"{ex.Message} {ex.StackTrace}");
                return BadRequest();
            }
        }


        // PUT api/<CategoryController>/5

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] CustomerDto model)
        {
            var data = _mapper.Map<Customer>(model);
            try
            {
                _customerService.Update(data);
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
            _customerService.Delete(id);
            return Ok();
        }
    }
}