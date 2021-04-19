using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YDManagement.Authorization;

namespace YDManagement.APIControllers
{
    public class SystemSettingsController : BaseController
    {
        private readonly ISystemSettingsService _systemSettingsService;
        public SystemSettingsController(ISystemSettingsService systemSettingsService)
        {
            _systemSettingsService = systemSettingsService;
        }
        // GET: api/<SystemSettingsController>
        [Permission(Roles.Administrator + ", " + Roles.Editor)]  
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _systemSettingsService.GetAll();
            return Ok(data);
        }

        // GET api/<SystemSettingsController>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _systemSettingsService.GetById(id);
            return Ok(data);
        }
        [Permission(Roles.Administrator)]
        
        [HttpPost]
        public IActionResult Create([FromBody] SystemSettings model)
        {
            try
            {
                _systemSettingsService.Create(model);
                return Ok(model);
            }
            catch (AppException ex)
            {              
                        // return error message if there was an exception
                        return BadRequest(new { message = ex.Message });               
            }
        }
        [Permission(Roles.Administrator + ", " + Roles.Editor)]
      
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SystemSettings model)
        {
            try
            {
                _systemSettingsService.Update(model);
                return Ok();
            }
            catch (AppException ex)
            {
                switch (ex.Message)
                {
                    
                    case AppCodeStatus.ObjectNotFound:
                        return Ok(new
                        {
                            StatusCode = StatusCodes.Status404NotFound,
                            ex.Message
                        });
                    default:
                        // return error message if there was an exception
                        return BadRequest(new { message = ex.Message });
                }
            }
        }

        // DELETE api/<SystemSettingsController>/5
        [Permission(Roles.Administrator)]
       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _systemSettingsService.Delete(id);
            return Ok();
        }
      
    }
}
