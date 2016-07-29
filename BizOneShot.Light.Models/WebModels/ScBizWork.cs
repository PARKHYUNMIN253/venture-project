// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
// TargetFrameworkVersion = 4.51
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading;

namespace BizOneShot.Light.Models.WebModels
{
    // SC_BIZ_WORK
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public class ScBizWork
    {
        public int BizWorkSn { get; set; } // BIZ_WORK_SN (Primary key)
        public string ExecutorId { get; set; } // EXECUTOR_ID
        public int MngCompSn { get; set; } // MNG_COMP_SN
        public string MngDept { get; set; } // MNG_DEPT
        public string BizWorkNm { get; set; } // BIZ_WORK_NM
        public string BizWorkSummary { get; set; } // BIZ_WORK_SUMMARY
        public DateTime? BizWorkStDt { get; set; } // BIZ_WORK_ST_DT
        public DateTime? BizWorkEdDt { get; set; } // BIZ_WORK_ED_DT
        public string Status { get; set; } // STATUS
        public string RegId { get; set; } // REG_ID
        public DateTime? RegDt { get; set; } // REG_DT
        public string UpdId { get; set; } // UPD_ID
        public DateTime? UpdDt { get; set; } // UPD_DT

        // Reverse navigation
        public virtual ICollection<RptFinanceComment> RptFinanceComments { get; set; } // RPT_FINANCE_COMMENT.FK_SC_BIZ_WORK_TO_RPT_FINANCE_COMMENT
        public virtual ICollection<RptMaster> RptMasters { get; set; } // Many to many mapping
        public virtual ICollection<ScCompMapping> ScCompMappings { get; set; } // Many to many mapping
        public virtual ICollection<ScExpertMapping> ScExpertMappings { get; set; } // Many to many mapping
        public virtual ICollection<ScMentoringReport> ScMentoringReports { get; set; } // SC_MENTORING_REPORT.FK_SC_BIZ_WORK_TO_SC_MENTORING_REPORT
        public virtual ICollection<ScMentoringTotalReport> ScMentoringTotalReports { get; set; } // SC_MENTORING_TOTAL_REPORT.FK_SC_BIZ_WORK_TO_MENTORING_TOTAL_REPORT
        public virtual ICollection<ScMentorMappiing> ScMentorMappiings { get; set; } // Many to many mapping

        // Foreign keys
        public virtual ScCompInfo ScCompInfo { get; set; } // FK_SC_COMP_INFO_TO_SC_BIZ_WORK
        public virtual ScUsr ScUsr { get; set; } // FK_SC_USR_TO_SC_BIZ_WORK
        
        public ScBizWork()
        {
            RptFinanceComments = new List<RptFinanceComment>();
            RptMasters = new List<RptMaster>();
            ScCompMappings = new List<ScCompMapping>();
            ScExpertMappings = new List<ScExpertMapping>();
            ScMentorMappiings = new List<ScMentorMappiing>();
            ScMentoringReports = new List<ScMentoringReport>();
            ScMentoringTotalReports = new List<ScMentoringTotalReport>();
        }
    }

}
