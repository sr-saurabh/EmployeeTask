using AutoMapper;
using Domain.ApiModels.Salary;
using Domain.DbModels;

namespace Domain.Mapper
{
    public class SalaryMapperProfile:Profile
    {
        public SalaryMapperProfile()
        {
            CreateMap<Salary, ApiSalary>().ReverseMap();
            CreateMap<Salary, CreateSalary>().ReverseMap();
            CreateMap<Salary, UpdateSalary>().ReverseMap();
        }
    }
}
