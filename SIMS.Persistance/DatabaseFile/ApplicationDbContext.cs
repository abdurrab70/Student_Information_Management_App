using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Core.Model.OperationModule;
using SIMS.Core.Model.SetupModule;
using SIMS.Core.ViewModel.OperationModule;

namespace SIMS.Persistance.DatabaseFile
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentEntry> StudentEntries { get; set; }
        public DbSet<ResultInformation> ResultInformations { get; set; }
        public DbSet<Marks> SubjectMarks { get; set; }
    }
}
