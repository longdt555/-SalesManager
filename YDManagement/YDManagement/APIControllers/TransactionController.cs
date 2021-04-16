using AutoMapper;
using Lib.Common;
using Lib.Common.Helpers;
using Lib.Data.Entity;
using Lib.Service.Dtos;
using Lib.Service.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using YDManagement.Authorization;

namespace YDManagement.APIControllers
{
    //[Route("api/transaction")]
    //[ApiController]
    //[Permission(Roles.Administrator)]
    /*[Authorize]*/ // The request must be contains jwt
    public class TransactionController : BaseController
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public TransactionController(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }

        public IActionResult Create([FromBody] TransactionDto model)
        {
            IActionResult response = Unauthorized();
            try
            {
                var today = DateTime.Now;
                var currentUser = ClientCurrentUser.Id;
                var data = _mapper.Map<Transaction>(model);
                data.CreatedBy = currentUser;
                data.CreatedDate = today;
                data.Id = currentUser;
                _transactionService.Create(data);
                var dataDto = _mapper.Map<TransactionDto>(data);
                return Ok(dataDto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return response;
            }
        }

        [Permission(Roles.Administrator + ", " + Roles.Client)]
        //[Authorization.Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data = _transactionService.GetById(id);
            return Ok(data);
        }

        [Permission(Roles.Administrator + ", " + Roles.Client)]
        //[Authorization.Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _transactionService.GetAll();
            return Ok(data);
        }

        [Permission(Roles.Administrator + ", " + Roles.Client)]
        //[Authorization.Authorize]
        [HttpPut]
        public IActionResult Update([FromBody] Transaction model)
        {
            try
            {
                model.UpdatedDate = DateTime.Now;
                model.UpdatedBy = AdminCurrentUser.Id;
                _transactionService.Update(model);
                return Ok(new {StatusCode = StatusCodes.Status200OK, Message = AppCodeStatus.SuccessUpdate});
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new {message = ex.Message});
            }
        }
    }
}
