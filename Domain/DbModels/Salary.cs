namespace Domain.DbModels
{
    public class Salary
    {
        public int EmployeeId { get; set; }
        public int SalaryId { get; set; }
        public string ItemType { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public Employee Employee { get; set; }
    }
}
