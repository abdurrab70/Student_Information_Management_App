using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIMS.Core.Model.SetupModule;
using SIMS.Core.ViewModel.OperationModule;

namespace SIMS.Application.Controllers.OperationModule.ViewController
{
    public class StudentEntriesController : Controller
    {
        // GET: StudentEntries
        public ActionResult StudentEntry(int? id)
        {
            ViewBag.DepartmentId = new SelectList(new List<Department>(), "Id", "Name");
            var isActive = new StudentEntryViewModel() { IsActive = true };
            return View(isActive);
        }
    }
}
