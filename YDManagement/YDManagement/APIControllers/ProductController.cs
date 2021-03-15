using AutoMapper;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Lib.Common.Helpers;
using YDManagement.Helpers;
using Lib.Common;
using YDManagement.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YDManagement.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize] // The request must be contains jwt
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // GET: api/<ProductController>
        [Permission(Roles.Administrator)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = new JResultHelper();
            result.SetStatusSuccess();
            var data = _productService.GetAll();
            result.SetData(data);
            return Ok(result);
        }


        // GET api/<ProductController>/5
        [Permission(Roles.Administrator)]
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var data = _productService.GetById(id);
            return Ok(data);
        }

        // POST api/<ProductController>
        [Permission(Roles.Administrator)]
        [HttpPost]
        public IActionResult Create([ FromBody] ProductDto model)
        {
            try
            {
                var today = DateTime.Now;
                var data = _mapper.Map<Product>(model);
                data.CreatedDate = today;
                _productService.Create(data);
                var dataDto = _mapper.Map<ProductDto>(data);
                return Ok(dataDto);
            }
            catch (AppException ex)
            {
                Console.WriteLine($"{ex.Message} {ex.StackTrace}");
                return BadRequest();
            }
        }

        // PUT api/<ProductController>/5
        [Authorization.Authorize]
        [Permission(Roles.Administrator)]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProductDto model)
        {

            var data = _mapper.Map<Product>(model);
            try
            {
                _productService.Update(data);
                return Ok();

            }
            catch (AppException ex)
            {
                Console.WriteLine($"{ex.Message} { ex.StackTrace}");
                return BadRequest();
            }
        }

        // DELETE api/<CategoryController>/5
        [Authorization.Authorize]
        [Permission(Roles.Administrator)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }
    }
}
