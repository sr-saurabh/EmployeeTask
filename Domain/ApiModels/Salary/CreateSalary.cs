namespace Domain.ApiModels.Salary
{
    public class CreateSalary
    {
        public int EmployeeId { get; set; }
        public string ItemType { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
