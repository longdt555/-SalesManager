using AutoMapper;
using Lib.Common;
using Lib.Common.Global;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
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
        public CategoryController(ICategoryService categoryService,IMapper mapper,IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _mapper = mapper;
        }

        // GET api/<CategoryController>/5
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _categoryService.GetAll();
                return Ok(data);
        }
        [AllowAnonymous]
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var data = _categoryService.GetById(id);
            return Ok(data);
        }
        [Authorization.Authorize]
        [HttpPost("AdminCreate")]
        public IActionResult AdminCreate([FromBody] CategoryDto model)
        {
            try
            {
                var today = DateTime.Now;
                var currentUser = LoggedOnAdminUser.UserId;
                var data = _mapper.Map<Category>(model);
                data.CreatedBy = currentUser;
                data.CreatedDate = today;
                _categoryService.Create(data);
                var dataDto = _mapper.Map<CategoryDto>(data);
                return Ok(dataDto);
            }
            catch
            {
                return BadRequest();
            }
        }
        // POST api/<CategoryController>
        [HttpPut("id")]
        public IActionResult Put( int id,[FromBody] CategoryDto model)
        {
           CategoryDto updatecate = _categoryService.GetById(id);
            var data = _mapper.Map<Category>(model);       
            _categoryService.Update(data);
            return NoContent();
        }


        // DELETE api/<CategoryController>/5       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = _categoryService.GetById(id);
            _categoryService.Delete(data);

            return NoContent();
        }
        #region private funtions helper
        // client token checking
        private bool HasPermission()
        {
            var accessToken = Request.Headers[HeaderNames.Authorization].ToString(); // get token from the client
            return Lib.Common.Helpers.AppHelpers.ValidToken(accessToken);
        }
        #endregion
    }
}
