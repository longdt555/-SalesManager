using AutoMapper;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using YDManagement.Helpers;

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
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = new JResultHelper();
            result.SetStatusSuccess();
            var data = _customerService.GetAll();
            result.SetData(data);
            return Ok(result);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _customerService.GetById(id);
            return Ok(data);
        }

        // POST api/<CategoryController>
        

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