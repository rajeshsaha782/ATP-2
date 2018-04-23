using Aiub.Ums.Core.Entities;
using Aiub.Ums.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aiub.Ums.Web.Mvc.Controllers
{
    public class StudentController : Controller
    {
        public IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View(_service.GetAll());
        }

        public ActionResult GetByName(string name)
        {
            return View(_service.GetByName(name));
        }
    }
}