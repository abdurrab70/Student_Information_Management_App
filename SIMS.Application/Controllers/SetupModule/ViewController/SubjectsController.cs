using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIMS.Core.ViewModel.SetupModule;

namespace SIMS.Application.Controllers.SetupModule.ViewController
{
    public class SubjectsController : Controller
    {
        // GET: Subjects
        public ActionResult SubjectView(int? id)
        {
            var isActive = new SubjectViewModel() { IsActive = true };
            return View(isActive);
        }
    }
}