using AutoMapper;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using Lib.Common.Helpers;
using Lib.Service.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using YDManagement.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YDManagement.APIControllers
{
    [Route("api/product")]
    [ApiController]
    [Authorize] // The request must be contains jwt
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

<<<<<<< HEAD
        [HttpGet("get-all")]
=======
        [AllowAnonymous]
        [HttpGet]
>>>>>>> ddf41198ba9c8954c5468c9e3c0d4a6c33c7fbe7
        public IActionResult GetAll()
        {
            var result = new JResultHelper();
            result.SetStatusSuccess();
            var data = _productService.GetAll();
            result.SetData(data);
            return Ok(result);
        }


        // GET api/<ProductController>/5

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            var data = _productService.GetById(id);
            return Ok(data);
        }

        // POST api/<ProductController>

        [HttpPost("create")]
        public IActionResult Create([FromBody] ProductDto model)
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


        [HttpPut("update/{id}")]
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
                Console.WriteLine($"{ex.Message} {ex.StackTrace}");
                return BadRequest();
            }
        }

        // DELETE api/<CategoryController>/5


        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }
    }
}
