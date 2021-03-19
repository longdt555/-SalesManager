using AutoMapper;
using Lib.Common;
using Lib.Service.Dtos;
using Lib.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YDManagement.Authorization;
using Lib.Data.Entity;
using Lib.Common.Helpers;

namespace YDManagement.APIControllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class BackendUserController : BaseController
    {
        private readonly IBackendUserService _backendUserService;
        private readonly IMapper _mapper;
        public BackendUserController(IBackendUserService backendUserService, IMapper mapper)
        {
            _backendUserService = backendUserService;
            _mapper = mapper;
        }
        [Permission(Roles.Administrator)]
        [HttpPost]
        public IActionResult Create([FromBody] BackendUserDto model)
        {
            var data = _mapper.Map<BackendUser>(model);
            try
            {
                data.CreatedDate = DateTime.Now;
                data.CreatedBy = AdminCurrentUser.Id;
                _backendUserService.Create(data);
                var dataDto = _mapper.Map<BackendUserDto>(data);
                return Ok(dataDto);
            }
            catch (AppException ex)
            {

               return BadRequest(new { message = ex.Message });
                
            }
        }
        [Permission(Roles.Administrator)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _backendUserService.GetAll();
            return Ok(data);
        }

        [Permission(Roles.Administrator)]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _backendUserService.GetById(id);
            var dataDto = _mapper.Map<BackendUserDto>(data);
            return Ok(dataDto);
        }

        [Permission(Roles.Administrator)]
        [HttpPut("{id}")]
        public IActionResult Update([FromBody] BackendUserDto model)
        {
            // map dataDto to entity and set id
            var data = _mapper.Map<BackendUser>(model);
            try
            {
                data.UpdatedDate = DateTime.Now;
                data.UpdatedBy = AdminCurrentUser.Id;
                _backendUserService.Update(data);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [Permission(Roles.Administrator)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _backendUserService.Delete(id);
            return Ok();
        }

    }
}
