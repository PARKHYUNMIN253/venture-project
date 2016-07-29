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
    // RPT_CHECK_LIST
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public class RptCheckList
    {
        public string DetailCd { get; set; } // DETAIL_CD (Primary key)
        public string LagreClassCd { get; set; } // LAGRE_CLASS_CD
        public string MidiumClassCd { get; set; } // MIDIUM_CLASS_CD
        public string SmallClassCd { get; set; } // SMALL_CLASS_CD
        public string Title { get; set; } // TITLE
        public string Content1 { get; set; } // CONTENT1
        public string Content2 { get; set; } // CONTENT2
        public string Type { get; set; } // TYPE
        public string Status { get; set; } // STATUS

        // Reverse navigation
        public virtual ICollection<RptMentorCheck> RptMentorChecks { get; set; } // Many to many mapping
        public virtual ICollection<RptMentorComment> RptMentorComments { get; set; } // Many to many mapping
        public virtual ICollection<RptMentorRadio> RptMentorRadios { get; set; } // Many to many mapping
        
        public RptCheckList()
        {
            RptMentorChecks = new List<RptMentorCheck>();
            RptMentorComments = new List<RptMentorComment>();
            RptMentorRadios = new List<RptMentorRadio>();
        }
    }

}
