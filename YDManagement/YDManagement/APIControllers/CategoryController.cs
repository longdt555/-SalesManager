using AutoMapper;
using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using YDManagement.Authorization;
using YDManagement.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YDManagement.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _mapper = mapper;
        }
        // GET: api/<CategoryController>
        [Permission(Roles.Administrator)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = new JResultHelper();
            result.SetStatusSuccess();
            var data = _categoryService.GetAll();
            result.SetData(data);
            return Ok(result);
        }
        // GET api/<CategoryController>/5
        [Permission(Roles.Administrator)]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _categoryService.GetById(id);
            return Ok(data);
        }
        [Permission(Roles.Administrator)]
        [HttpPost()]
        public IActionResult Create([FromBody] CategoryDto model)
        {
            Unauthorized();
            try
            {
                var data = _mapper.Map<Category>(model);
                _categoryService.Create(data);
                var dataDto = _mapper.Map<OrderDto>(data);
                return Ok(dataDto);

            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/<CategoryController>
        [Permission(Roles.Administrator)]
        [Authorization.Authorize]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CategoryDto model)
        {

            var data = _mapper.Map<Category>(model);
            try
            {
                _categoryService.Update(data);
                return Ok();

            }
            catch (AppException ex)
            {
                Console.WriteLine($"{ex.Message} { ex.StackTrace}");
                return BadRequest();
            }
        }

        // DELETE api/<CategoryController>/5
        [Permission(Roles.Administrator)]
        [Authorization.Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }
    }
}