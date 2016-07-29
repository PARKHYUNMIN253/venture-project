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
    // SY_DARE_DB_INFO
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public class SyDareDbInfo
    {
        public string DbType { get; set; } // DB_TYPE (Primary key)
        public string DbIp { get; set; } // DB_IP
        public string DbName { get; set; } // DB_NAME
        public string DbState { get; set; } // DB_STATE
        public string NotifyMsg { get; set; } // NOTIFY_MSG
        public string DefaultType { get; set; } // DEFAULT_TYPE
        public string Ect { get; set; } // ECT

        // Reverse navigation
        public virtual ICollection<ScUsr> ScUsrs { get; set; } // SC_USR.FK_SY_DARE_DB_INFO_TO_SC_USR
        
        public SyDareDbInfo()
        {
            ScUsrs = new List<ScUsr>();
        }
    }

}
