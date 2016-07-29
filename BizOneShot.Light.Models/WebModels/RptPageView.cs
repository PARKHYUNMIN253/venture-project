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
    // RPT_PAGE_VIEW
    public class RptPageView
    {
        public int QuestionSn { get; set; } // QUESTION_SN
        public int BizWorkSn { get; set; } // BIZ_WORK_SN
        public int BasicYear { get; set; } // BASIC_YEAR
        public int? PageNum { get; set; } // PAGE_NUM
        public string PageName { get; set; } // PAGE_NAME
        public string DetailCd { get; set; } // DETAIL_CD
        public string Comment { get; set; } // COMMENT
        public string RequireField { get; set; }
    }

}
