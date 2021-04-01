using AutoMapper;
using Lib.Common.Helpers;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace YDManagement.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class CustomerProfileController : BaseController
    {
        private readonly ICustomerProfileService _customerProfileService;
        private readonly IMapper _mapper;
        public CustomerProfileController(ICustomerProfileService customerProfileService, IMapper mapper)
        {
            _customerProfileService = customerProfileService;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Create([FromBody] CustomerProfileDto model)
        {
            var data = _mapper.Map<CustomerProfile>(model);
            try
            {
                data.CreatedBy = AdminCurrentUser.Id;
                _customerProfileService.Create(data);
                return Ok();

            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [AllowAnonymous]
        [HttpPut]
        public IActionResult Update([FromBody] CustomerProfileDto model)
        {
            IActionResult response = Unauthorized();
            // map dto to entity and set id
            var data = _mapper.Map<CustomerProfile>(model);
            try
            {              
                var currentUser = AdminCurrentUser.Id; ;
                var today = DateTime.Now;
                if (currentUser != model.Id) return response;
                data.UpdatedDate = today;
                data.UpdatedBy = currentUser;
                _customerProfileService.Update(data);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _customerProfileService.Delete(id);
            return Ok();
        }
    }
}
