using AutoMapper;
using Domain.ApiModels.Employee;
using Domain.DbModels;

namespace Domain.Mapper
{
    public class EmployeeMapperProfile:Profile
    {
        public EmployeeMapperProfile()
        {
            CreateMap<Employee, ApiEmployee>().ReverseMap();
            CreateMap<Employee, CreateEmployee>().ReverseMap();
            CreateMap<Employee, UpdateEmployee>().ReverseMap();
        }
    }
}
