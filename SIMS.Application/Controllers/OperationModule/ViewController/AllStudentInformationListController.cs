using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIMS.Application.Controllers.OperationModule.ViewController
{
    public class AllStudentInformationListController : Controller
    {
        // GET: AllStudentInformationList
        public ActionResult StudentList()
        {
            return View();
        }
    }
}