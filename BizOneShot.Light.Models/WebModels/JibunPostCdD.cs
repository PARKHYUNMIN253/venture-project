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
    // JIBUN_POST_CD__D
    public class JibunPostCdD
    {
        public string ZipCd { get; set; } // ZIP_CD
        public string Seq { get; set; } // SEQ
        public string Sido { get; set; } // SIDO
        public string Gungu { get; set; } // GUNGU
        public string Dong { get; set; } // DONG
        public string Ri { get; set; } // RI
        public string Do { get; set; } // DO
        public string MtBunji { get; set; } // MT_BUNJI
        public string StMnBunji { get; set; } // ST_MN_BUNJI
        public string StSubBunji { get; set; } // ST_SUB_BUNJI
        public string EdMnBunji { get; set; } // ED_MN_BUNJI
        public string EdSubBunji { get; set; } // ED_SUB_BUNJI
        public string BldNm { get; set; } // BLD_NM
        public string StDong { get; set; } // ST_DONG
        public string EdDong { get; set; } // ED_DONG
        public string UpdDt { get; set; } // UPD_DT
        public string Addr { get; set; } // ADDR
    }

}
