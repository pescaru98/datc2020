using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using L02.Entities;
using L02.Repositories;

namespace L02.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    { 
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {        

            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Student> Get(){
            return StudentRepo.GetStudents();
        }

    }
}
