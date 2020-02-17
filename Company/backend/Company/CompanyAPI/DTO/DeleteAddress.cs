using System;

namespace CompanyAPI.DTO
{
    public class DeleteAddress
    {
        public Guid? EmployeeId { get; set; }
        public Guid? AddressId { get; set; }
    }
}
