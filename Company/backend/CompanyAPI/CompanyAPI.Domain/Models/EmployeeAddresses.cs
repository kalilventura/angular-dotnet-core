namespace CompanyAPI.Domain.Models
{
    public class EmployeeAddresses
    {
        public int AddressId { get; private set; }
        public virtual Address Addresses { get; private set; }
        public int EmployeeId { get; private set; }
        public virtual Employee Employees { get; private set; }
    }
}
