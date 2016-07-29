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
    // RPT_PAGE_VIEW
    internal partial class RptPageViewConfiguration : EntityTypeConfiguration<RptPageView>
    {
        public RptPageViewConfiguration()
            : this("dbo")
        {
        }
 
        public RptPageViewConfiguration(string schema)
        {
            ToTable(schema + ".RPT_PAGE_VIEW");
            HasKey(x => new { x.QuestionSn, x.BizWorkSn, x.BasicYear, x.DetailCd });

            Property(x => x.QuestionSn).HasColumnName("QUESTION_SN").IsRequired().HasColumnType("int");
            Property(x => x.BizWorkSn).HasColumnName("BIZ_WORK_SN").IsRequired().HasColumnType("int");
            Property(x => x.BasicYear).HasColumnName("BASIC_YEAR").IsRequired().HasColumnType("int");
            Property(x => x.PageNum).HasColumnName("PAGE_NUM").IsOptional().HasColumnType("int");
            Property(x => x.PageName).HasColumnName("PAGE_NAME").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.DetailCd).HasColumnName("DETAIL_CD").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(8);
            Property(x => x.Comment).HasColumnName("COMMENT").IsOptional().HasColumnType("nvarchar").HasMaxLength(1300);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
