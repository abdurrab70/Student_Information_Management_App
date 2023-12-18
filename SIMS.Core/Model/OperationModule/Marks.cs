using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Core.Model.CommonModel;
using SIMS.Core.Model.SetupModule;

namespace SIMS.Core.Model.OperationModule
{
    public class Marks
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string Section { get; set; }
        public string Session { get; set; }
        public string Grade { get; set; }
        
        public string CheckFailure { get; set; }
        public string TotalMarks { get; set; }
        public string Average { get; set; }
        public string PointResult { get; set; }
        
        public string Bangla { get; set; }
        public string Bangla2 { get; set; }
        public string Math { get; set; }
        public string English { get; set; }
        public string English2 { get; set; }
        public string GeneralScience { get; set; }
        public string SocialScience { get; set; }
        public string BnagladeshWorld { get; set; }
        public string IslamicStudies { get; set; }
        public string ICT { get; set; }
        public string AgricultureStudies { get; set; }
        public string Science { get; set; }
        public string Physics { get; set; }
        public string Chemistry { get; set; }
        public string Biology { get; set; }
        public string HigherMath { get; set; }
        public string BusinessStudies { get; set; }
        public string Accountiong { get; set; }
        public string MathematicsStatistics { get; set; }
        public string FinanceBanking { get; set; }
        public string History { get; set; }
        public string Geography { get; set; }
        public string PoliticalScience { get; set; }
        public string Economics { get; set; }
        public string Sociology { get; set; }
        public string OptionalSubject { get; set; }

    }
}
