using AutoMapper;
using SIMS.Core.Model.SetupModule;
using SIMS.Core.ViewModel.SetupModule;
using SIMS.Core.ViewModel.OperationModule;
using SIMS.Persistance.DatabaseFile;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Core.Model.OperationModule;

namespace SIMS.ServiceManager.ServiceManager.OperationModule
{
    public class StudentEntriesServiceManager
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentEntriesServiceManager()
        {
            _dbContext = new ApplicationDbContext();
        }
        // single data tolar jonne ata kora
        public StudentEntryViewModel Get(int id)
        {
            var entity = _dbContext.StudentEntries.SingleOrDefault(c => c.Id == id);

            return (Mapper.Map<StudentEntry, StudentEntryViewModel>(entity));
        }
        public IEnumerable<StudentEntryViewModel> GetAll()
        {
            var entities = _dbContext.StudentEntries
                .Include("Department")
                .ToList().Select(Mapper.Map<StudentEntry, StudentEntryViewModel>);
            return entities;
        }

        public int Add(StudentEntryViewModel vm)
        {
            var entity   = Mapper.Map<StudentEntryViewModel, StudentEntry>(vm);
            entity.CreateBy = "User";
            entity.CreateDate = DateTime.Now;
            _dbContext.StudentEntries.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }
        // individuals data update save change return database
        public int AddWindows(StudentEntry vm)
        {
            // var entity = Mapper.Map<DepartmentViewModel, Department>(vm);

            _dbContext.StudentEntries.Add(vm);
            return _dbContext.SaveChanges();
        }

        // data update
        public int Update(int id, StudentEntryViewModel vm)
        {
            var entity = _dbContext.StudentEntries.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            _dbContext.SaveChanges();

            return entity.Id;
        }

        // remove data of database

        public int Remove(int id)
        {
            var entity = _dbContext.StudentEntries.SingleOrDefault(c => c.Id == id);
            _dbContext.StudentEntries.Remove(entity);

            return _dbContext.SaveChanges();
        }

        // auto Student id generate code
        public string GenerateStudentId()
        {
            int parsonalNo = 0;

            var list = _dbContext.StudentEntries.ToList()
                .OrderByDescending(c => c.Id).FirstOrDefault();

            if (list == null)
            {
                var code = "SIMS - " + " 0001";
                return code;
            }

            {
                string[] parts = list.StudentId.Split('-');
                parsonalNo = Convert.ToInt32(parts[1]);
            }

            var traineeParsonalNo = "SIMS - " + (parsonalNo + 1).ToString().PadLeft(4, '0');
            return traineeParsonalNo;
        }

    }
}
