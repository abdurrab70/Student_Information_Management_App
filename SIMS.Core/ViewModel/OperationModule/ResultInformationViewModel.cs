using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Core.Model.OperationModule;
using SIMS.Core.Model.SetupModule;

namespace SIMS.Core.ViewModel.OperationModule
{
    public class ResultInformationViewModel
    {
        public int Id { get; set; }
        public int StudentEntryId { get; set; }
        public StudentEntry StudentEntry { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string BoardRoll { get; set; }
        public string RegistrationNo { get; set; }
        public string Section { get; set; }
        public string Result { get; set; }
        public string ActiveStatus { get; set; }
        public bool IsActive { get; set; }
        public string Session { get; set; }
        public string SubjectId { get; set; }
        public string Remark { get; set; }

        public string Name { get; set; }
        public string PhoneNo { get; set; }
    }
}
