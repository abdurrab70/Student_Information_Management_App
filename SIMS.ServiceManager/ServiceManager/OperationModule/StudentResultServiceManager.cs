using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SIMS.Core.Model.OperationModule;
using SIMS.Core.Model.SetupModule;
using SIMS.Core.ViewModel.OperationModule;
using SIMS.Core.ViewModel.SetupModule;
using SIMS.Persistance.DatabaseFile;

namespace SIMS.ServiceManager.ServiceManager.OperationModule
{
    public class StudentResultServiceManager
    {
        private ApplicationDbContext _dbContext;

        public StudentResultServiceManager()
        {
            _dbContext = new ApplicationDbContext();
        }
        public MarksViewModel Get(int id)
        {
            var entity = _dbContext.SubjectMarks.SingleOrDefault(c => c.Id == id);


            return (Mapper.Map<Marks, MarksViewModel>(entity));

        }
        // all data tolar jonne
        public IEnumerable<MarksViewModel> GetAll()
        {
            var entities = _dbContext.SubjectMarks
                .Include("Department")
                .ToList().Select(Mapper.Map<Marks, MarksViewModel>);
            return entities;
        }
        public int Add(MarksViewModel vm)
        {
            var entity = Mapper.Map<MarksViewModel, Marks>(vm);

            _dbContext.SubjectMarks.Add(entity: entity);
            return _dbContext.SaveChanges();
        }

        // individuals data update
        public int AddWindows(Marks vm)
        {
            //var entity = Mapper.Map<DepartmentViewModel, Department>(vm);

            _dbContext.SubjectMarks.Add(vm);
            return _dbContext.SaveChanges();
        }

        public int Update(int id, MarksViewModel vm)
        {
            var entity = _dbContext.SubjectMarks.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            return _dbContext.SaveChanges();
        }

        public int Remove(int id)
        {
            var entity = _dbContext.SubjectMarks.SingleOrDefault(c => c.Id == id);
            _dbContext.SubjectMarks.Remove(entity);
            return _dbContext.SaveChanges();
        }

    }
}
