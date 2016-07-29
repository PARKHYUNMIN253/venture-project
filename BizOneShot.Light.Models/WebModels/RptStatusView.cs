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
    // RPT_STATUS_VIEW
    public class RptStatusView
    {
        public string BizWorkNm { get; set; } // BIZ_WORK_NM
        public int CompSn { get; set; } // COMP_SN
        public int BizWorkSn { get; set; } // BIZ_WORK_SN
        public string MentorId { get; set; } // MENTOR_ID
        public string MappingStatus { get; set; } // MAPPING_STATUS
        public string UpdId { get; set; } // UPD_ID
        public string QuesStatus { get; set; } // QUES_STATUS
        public string LoginId { get; set; } // LOGIN_ID
        public string Name { get; set; } // NAME
        public string TelNo { get; set; } // TEL_NO
        public string Email { get; set; } // EMAIL
        public string CompNm { get; set; } // COMP_NM
        public string OwnNm { get; set; } // OWN_NM
    }

}
