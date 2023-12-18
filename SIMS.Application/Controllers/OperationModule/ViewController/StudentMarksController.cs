using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIMS.Core.Model.OperationModule;
using SIMS.Core.Model.SetupModule;

namespace SIMS.Application.Controllers.OperationModule.ViewController
{
    public class StudentMarksController : Controller
    {
        // GET: StudentMarks
        public ActionResult StudentResultMarks()
        {
            ViewBag.DepartmentId = new SelectList(new List<Department>(), "Id", "Name");
            return View();
        }
    }
}