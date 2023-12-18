using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Core.ReportModule;
using SIMS.Persistance.DatabaseFile;

namespace SIMS.ServiceManager.ServiceManager.ReportModule
{
    public class StudentReportService
    {
        private ApplicationDbContext _dbContext;
        public StudentReportService()
        {
            _dbContext = new ApplicationDbContext();
        }
        //method create list all student return
        public IEnumerable<AllStudentReportsViewModel> GetAllStudent()
        {
            var Students = _dbContext.StudentEntries.ToList();
            var entities = new List<AllStudentReportsViewModel>();

            foreach (var Student in Students)
            {
                var model = new AllStudentReportsViewModel()
                {
                    StudentId = Student.StudentId,
                    Name = Student.Name,
                    PhoneNo = Student.PhoneNo,
                    Email = Student.Email,
                    FatherName = Student.FatherName,
                    MotherName = Student.MotherName
                };
            }

            return entities;
        }
    }
}
