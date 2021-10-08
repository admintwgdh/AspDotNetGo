using AspDotNetGo.Common;
using AspDotNetGo.Model.ApiResultHelper;
using AspDotNetGo.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyLogin.WebApi.Utility.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetGo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController:Controller
    {
        private readonly IFreeSql _freesql;
        private readonly EFCoreContext _efContext;
        private readonly IMapper _mapper;

        public StudentController(IFreeSql freeSql, EFCoreContext efContext, IMapper mapper)
        {
            _freesql = freeSql;
            _efContext = efContext;
            _mapper = mapper;
        }


        [HttpGet]
        public Task<IActionResult> GetList()
        {
            return Task.Factory.StartNew<IActionResult>(() =>
            {
                var resEF = _efContext.Student.ToList();
                var resFreesql = _freesql.Select<Student>().ToList();
                List<StudentDto> studentDto = _mapper.Map<List<Student>, List<StudentDto>>(resEF);

                //var qq = new CustomAutoMapperProfile<Student, StudentDto>(resEF);
                studentDto.ForEach(x => x.type = "after mapper");
                return Ok(ApiResultHelper.Success(resEF));
            });
        }
    }
}
