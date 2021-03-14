using AutoMapper;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YDManagement.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YDManagement.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _categoryService.GetById(id);
            return Ok(data);
        }
        [AllowAnonymous]
        [HttpPost()]
        public IActionResult Create([FromBody] CategoryDto model)
        {
            IActionResult response = Unauthorized();
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
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}