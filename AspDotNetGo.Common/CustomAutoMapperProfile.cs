using AspDotNetGo.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLogin.WebApi.Utility.AutoMapper
{
    public class CustomAutoMapperProfile<TSEntity, TDEntity> : Profile
    {
        public CustomAutoMapperProfile()
        {
            base.CreateMap<TSEntity, TDEntity>();
        }
    }
    //public class CustomAutoMapperProfile: Profile
    //{
    //    public CustomAutoMapperProfile()
    //    {
    //    base.CreateMap<Student, StudentDto>();
    //    }
    //}
}
