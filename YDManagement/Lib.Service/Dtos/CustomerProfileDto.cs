using Lib.Data.Entity;
using System;

namespace Lib.Service.Dtos
{
    public class CustomerProfileDto : BaseDto
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Avatar { get; set; }
        public string IdentityCard { get; set; }
        public string IdentityCardValidDate { get; set; }
        public string IdentityCardPlace { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
