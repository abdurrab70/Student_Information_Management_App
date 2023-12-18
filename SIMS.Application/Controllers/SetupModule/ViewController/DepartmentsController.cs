using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIMS.Core.ViewModel.SetupModule;

namespace SIMS.Application.Controllers.SetupModule.ViewController
{
    public class DepartmentsController : Controller
    {
        // GET: Departments
        public ActionResult ClassCreate(int? id)
        {
            var isActive = new DepartmentViewModel() { IsActive = true };
            return View(isActive);
        }
    }
}