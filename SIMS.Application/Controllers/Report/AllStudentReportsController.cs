using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using SIMS.ServiceManager.ServiceManager.ReportModule;

namespace SIMS.Application.Controllers.Report
{
    public class AllStudentReportsController : Controller
    {
        // GET: AllStudentReports
        private StudentReportService _service = new StudentReportService();

        // GET: AllReport
        public ActionResult SimsReport()
        {
            return View();
        }

        //Get GetAllStudent
        [HttpPost]
        [Route("AllStudentReports/GetAllStudent")]
        public JsonResult GetAllStudent()
        {
            try
            {
                CultureInfo cInfo = new CultureInfo("en-IN");
                ReportViewer viewer = new ReportViewer();

                string path = Path.Combine(Server.MapPath("/Report"), "StudentInfoReport.rdlc ");
                viewer.LocalReport.ReportPath = path;

                var StudentInformation = _service.GetAllStudent();
                var gi = new ReportDataSource("AllStudentDataSet", StudentInformation);
                viewer.LocalReport.DataSources.Add(gi);


                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension,
                    out var streamIds, out var warnings);

                string fileName = DateTime.Now.ToString("dd_MM_yyyy");
                string outputPath = "~/Report";
                //var di = new DirectoryInfo(Server.MapPath(outputPath));
                if (System.IO.File.Exists(Server.MapPath(outputPath + fileName + ".pdf")))
                {
                    try
                    {
                        System.IO.File.Delete(Server.MapPath(outputPath + fileName + ".pdf"));
                    }
                    catch (Exception)
                    {
                        fileName = DateTime.Now.ToString("dd_MM_yyyy");
                    }

                }

                using (var stream = System.IO.File.Create(Path.Combine(Server.MapPath(outputPath), fileName + ".pdf")))
                {
                    stream.Write(bytes, 0, bytes.Length);
                }

                var pdfHref = "/Report/" + fileName + ".pdf";

                return Json(pdfHref, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}