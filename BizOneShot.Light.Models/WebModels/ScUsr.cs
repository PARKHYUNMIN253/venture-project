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
    // SC_USR
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public class ScUsr
    {
        public string LoginId { get; set; } // LOGIN_ID (Primary key)
        public int CompSn { get; set; } // COMP_SN
        public string LoginPw { get; set; } // LOGIN_PW
        public string Status { get; set; } // STATUS
        public string AgreeYn { get; set; } // AGREE_YN
        public string UsrType { get; set; } // USR_TYPE
        public string UsrTypeDetail { get; set; } // USR_TYPE_DETAIL
        public string DbType { get; set; } // DB_TYPE
        public string Name { get; set; } // Name
        public string FaxNo { get; set; } // FAX_NO
        public string TelNo { get; set; } // TEL_NO
        public string MbNo { get; set; } // MB_NO
        public string Email { get; set; } // EMAIL
        public string PostNo { get; set; } // POST_NO
        public string Addr1 { get; set; } // ADDR_1
        public string Addr2 { get; set; } // ADDR_2
        public string AccountNo { get; set; } // ACCOUNT_NO
        public string BankNm { get; set; } // BANK_NM
        public string DeptNm { get; set; } // DEPT_NM
        public string RegId { get; set; } // REG_ID
        public DateTime? RegDt { get; set; } // REG_DT
        public string UpdId { get; set; } // UPD_ID
        public DateTime? UpdDt { get; set; } // UPD_DT
        public string UseErp { get; set; } // USE_ERP

        // Reverse navigation
        public virtual ICollection<RptFinanceComment> RptFinanceComments { get; set; } // Many to many mapping
        public virtual ICollection<RptMaster> RptMasters { get; set; } // RPT_MASTER.FK_SC_USR_TO_RPT_MASTER
        public virtual ICollection<ScBizWork> ScBizWorks { get; set; } // SC_BIZ_WORK.FK_SC_USR_TO_SC_BIZ_WORK
        public virtual ICollection<ScCompMapping> ScCompMappings { get; set; } // SC_COMP_MAPPING.FK_SC_MENTOR_MAPPIING_TO_SC_COMP_MAPPING
        public virtual ICollection<ScExpertMapping> ScExpertMappings { get; set; } // Many to many mapping
        public virtual ICollection<ScMentoringReport> ScMentoringReports { get; set; } // SC_MENTORING_REPORT.FK_SC_USR_TO_SC_MENTORING_REPORT
        public virtual ICollection<ScMentoringTotalReport> ScMentoringTotalReports { get; set; } // SC_MENTORING_TOTAL_REPORT.FK_SC_USR_TO_MENTORING_TOTAL_REPORT
        public virtual ICollection<ScMentorMappiing> ScMentorMappiings { get; set; } // Many to many mapping
        public virtual ICollection<ScQa> ScQas_AnswerId { get; set; } // SC_QA.FK_SC_USR_TO_SC_QA2
        public virtual ICollection<ScQa> ScQas_QuestionId { get; set; } // SC_QA.FK_SC_USR_TO_SC_QA
        public virtual ICollection<ScReqDoc> ScReqDocs_ReceiverId { get; set; } // SC_REQ_DOC.FK_SC_USR_TO_SC_REQ_DOC2
        public virtual ICollection<ScReqDoc> ScReqDocs_SenderId { get; set; } // SC_REQ_DOC.FK_SC_USR_TO_SC_REQ_DOC
        public virtual ScUsrResume ScUsrResume { get; set; } // SC_USR_RESUME.FK_SC_USR_TO_SC_USR_RESUME

        // Foreign keys
        public virtual ScCompInfo ScCompInfo { get; set; } // FK_SC_COMP_INFO_TO_SC_USR
        public virtual SyDareDbInfo SyDareDbInfo { get; set; } // FK_SY_DARE_DB_INFO_TO_SC_USR
        
        public ScUsr()
        {
            AgreeYn = "N";
            UseErp = "Y";
            RptFinanceComments = new List<RptFinanceComment>();
            RptMasters = new List<RptMaster>();
            ScBizWorks = new List<ScBizWork>();
            ScCompMappings = new List<ScCompMapping>();
            ScExpertMappings = new List<ScExpertMapping>();
            ScMentorMappiings = new List<ScMentorMappiing>();
            ScMentoringReports = new List<ScMentoringReport>();
            ScMentoringTotalReports = new List<ScMentoringTotalReport>();
            ScQas_AnswerId = new List<ScQa>();
            ScQas_QuestionId = new List<ScQa>();
            ScReqDocs_ReceiverId = new List<ScReqDoc>();
            ScReqDocs_SenderId = new List<ScReqDoc>();
        }
    }

}
