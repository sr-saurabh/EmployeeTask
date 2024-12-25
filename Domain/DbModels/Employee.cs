namespace Domain.DbModels
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Location { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<Salary> Salaries { get; set; }
    }
}
