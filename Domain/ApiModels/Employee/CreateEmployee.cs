namespace Domain.ApiModels.Employee
{
    public class CreateEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Location { get; set; }

        public DateTime DateOfBirth { get; set; }

    }
}
