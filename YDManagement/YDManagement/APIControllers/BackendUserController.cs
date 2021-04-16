using AutoMapper;
using Lib.Common;
using Lib.Service.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using Lib.Data.Entity;
using Lib.Common.Helpers;
using Lib.Service.Services.IServices;
using Microsoft.AspNetCore.Authorization;

namespace YDManagement.APIControllers
<<<<<<< HEAD
{
    [Authorize]
=======
{    
>>>>>>> ddf41198ba9c8954c5468c9e3c0d4a6c33c7fbe7
    [Route("api/backend-user")]
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
<<<<<<< HEAD
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("get-all")]
=======

               return BadRequest(new { message = ex.Message });
                
            }
        }
        [Permission(Roles.Administrator)]
        [HttpGet]
>>>>>>> ddf41198ba9c8954c5468c9e3c0d4a6c33c7fbe7
        public IActionResult GetAll()
        {
            var data = _backendUserService.GetAll();
            return Ok(data);
        }

<<<<<<< HEAD

        [HttpGet("get-by-id/{id}")]
=======
        [Permission(Roles.Administrator)]
        [HttpGet("{id}")]
>>>>>>> ddf41198ba9c8954c5468c9e3c0d4a6c33c7fbe7
        public IActionResult GetById(int id)
        {
            var data = _backendUserService.GetById(id);
            var dataDto = _mapper.Map<BackendUserDto>(data);
            return Ok(dataDto);
        }

<<<<<<< HEAD

        [HttpPut("update/{id}")]
=======
        [Permission(Roles.Administrator)]
        [HttpPut("{id}")]
>>>>>>> ddf41198ba9c8954c5468c9e3c0d4a6c33c7fbe7
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

<<<<<<< HEAD

        [HttpDelete("delete/{id}")]
=======
        [Permission(Roles.Administrator)]
        [HttpDelete("{id}")]
>>>>>>> ddf41198ba9c8954c5468c9e3c0d4a6c33c7fbe7
        public IActionResult Delete(int id)
        {
            _backendUserService.Delete(id);
            return Ok();
        }

    }
}
