using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Core.Model.CommonModel;
using SIMS.Core.Model.SetupModule;
using SIMS.Core.Model.OperationModule;

namespace SIMS.Core.Model.OperationModule
{
    public class ResultInformation : BaseDomainDateTime
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
    }
}
