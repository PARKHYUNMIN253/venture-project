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
    // SC_COMP_INFO
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public class ScCompInfo
    {
        public int CompSn { get; set; } // COMP_SN (Primary key)
        public string Status { get; set; } // STATUS
        public string CompType { get; set; } // COMP_TYPE
        public string RegistrationNo { get; set; } // REGISTRATION_NO
        public string CompNm { get; set; } // COMP_NM
        public string Email { get; set; } // EMAIL
        public string TelNo { get; set; } // TEL_NO
        public string PostNo { get; set; } // POST_NO
        public string Addr1 { get; set; } // ADDR_1
        public string Addr2 { get; set; } // ADDR_2
        public string OwnNm { get; set; } // OWN_NM
        public string RegId { get; set; } // REG_ID
        public DateTime? RegDt { get; set; } // REG_DT
        public string UpdId { get; set; } // UPD_ID
        public DateTime? UpdDt { get; set; } // UPD_DT

        // Reverse navigation
        public virtual ICollection<RptFinanceComment> RptFinanceComments { get; set; } // Many to many mapping
        public virtual ICollection<RptMaster> RptMasters { get; set; } // RPT_MASTER.FK_SC_COMP_INFO_TO_RPT_MASTER
        public virtual ICollection<RptMngComment> RptMngComments { get; set; } // Many to many mapping
        public virtual ICollection<ScBizType> ScBizTypes { get; set; } // Many to many mapping
        public virtual ICollection<ScBizWork> ScBizWorks { get; set; } // SC_BIZ_WORK.FK_SC_COMP_INFO_TO_SC_BIZ_WORK
        public virtual ICollection<ScCompMapping> ScCompMappings { get; set; } // Many to many mapping
        public virtual ICollection<ScMentoringReport> ScMentoringReports { get; set; } // SC_MENTORING_REPORT.FK_SC_COMP_INFO_TO_SC_MENTORING_REPORT
        public virtual ICollection<ScMentoringTotalReport> ScMentoringTotalReports { get; set; } // SC_MENTORING_TOTAL_REPORT.FK_SC_COMP_INFO_TO_MENTORING_TOTAL_REPORT
        public virtual ICollection<ScMentorMappiing> ScMentorMappiings { get; set; } // SC_MENTOR_MAPPIING.FK_SC_COMP_INFO_TO_SC_MENTOR_MAPPIING
        public virtual ICollection<ScUsr> ScUsrs { get; set; } // SC_USR.FK_SC_COMP_INFO_TO_SC_USR
        
        public ScCompInfo()
        {
            RptFinanceComments = new List<RptFinanceComment>();
            RptMasters = new List<RptMaster>();
            RptMngComments = new List<RptMngComment>();
            ScBizTypes = new List<ScBizType>();
            ScBizWorks = new List<ScBizWork>();
            ScCompMappings = new List<ScCompMapping>();
            ScMentorMappiings = new List<ScMentorMappiing>();
            ScMentoringReports = new List<ScMentoringReport>();
            ScMentoringTotalReports = new List<ScMentoringTotalReport>();
            ScUsrs = new List<ScUsr>();
        }
    }

}
