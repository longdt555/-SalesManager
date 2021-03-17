using Lib.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Service.Dtos
{
    public class TransactionDetailDto : BaseDto
    {
        public string Village { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentityCard { get; set; }
        public string IdentityCardValidDate { get; set; }
        public string IdentityCardPlace { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
        public string Address1 { get; set; }
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
    }
}
