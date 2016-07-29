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
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using BizOneShot.Light.Models.WebModels;
using System.Threading;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;

namespace BizOneShot.Light.Dao.WebConfiguration
{
    // JIBUN_POST_CD__D
    internal partial class JibunPostCdDConfiguration : EntityTypeConfiguration<JibunPostCdD>
    {
        public JibunPostCdDConfiguration()
            : this("dbo")
        {
        }
 
        public JibunPostCdDConfiguration(string schema)
        {
            ToTable(schema + ".JIBUN_POST_CD__D");
            HasKey(x => new { x.ZipCd, x.Seq });

            Property(x => x.ZipCd).HasColumnName("ZIP_CD").IsRequired().IsFixedLength().IsUnicode(false).HasColumnType("char").HasMaxLength(6);
            Property(x => x.Seq).HasColumnName("SEQ").IsRequired().IsFixedLength().IsUnicode(false).HasColumnType("char").HasMaxLength(3);
            Property(x => x.Sido).HasColumnName("SIDO").IsOptional().HasColumnType("nvarchar").HasMaxLength(30);
            Property(x => x.Gungu).HasColumnName("GUNGU").IsOptional().HasColumnType("nvarchar").HasMaxLength(30);
            Property(x => x.Dong).HasColumnName("DONG").IsOptional().HasColumnType("nvarchar").HasMaxLength(30);
            Property(x => x.Ri).HasColumnName("RI").IsOptional().HasColumnType("nvarchar").HasMaxLength(30);
            Property(x => x.Do).HasColumnName("DO").IsOptional().HasColumnType("nvarchar").HasMaxLength(30);
            Property(x => x.MtBunji).HasColumnName("MT_BUNJI").IsOptional().HasColumnType("nvarchar").HasMaxLength(20);
            Property(x => x.StMnBunji).HasColumnName("ST_MN_BUNJI").IsOptional().HasColumnType("nvarchar").HasMaxLength(20);
            Property(x => x.StSubBunji).HasColumnName("ST_SUB_BUNJI").IsOptional().HasColumnType("nvarchar").HasMaxLength(20);
            Property(x => x.EdMnBunji).HasColumnName("ED_MN_BUNJI").IsOptional().HasColumnType("nvarchar").HasMaxLength(20);
            Property(x => x.EdSubBunji).HasColumnName("ED_SUB_BUNJI").IsOptional().HasColumnType("nvarchar").HasMaxLength(20);
            Property(x => x.BldNm).HasColumnName("BLD_NM").IsOptional().HasColumnType("nvarchar").HasMaxLength(30);
            Property(x => x.StDong).HasColumnName("ST_DONG").IsOptional().HasColumnType("nvarchar").HasMaxLength(20);
            Property(x => x.EdDong).HasColumnName("ED_DONG").IsOptional().HasColumnType("nvarchar").HasMaxLength(20);
            Property(x => x.UpdDt).HasColumnName("UPD_DT").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(8);
            Property(x => x.Addr).HasColumnName("ADDR").IsOptional().HasColumnType("nvarchar").HasMaxLength(150);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
