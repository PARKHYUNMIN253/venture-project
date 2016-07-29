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
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.15.1.0")]
    public class FakeWebDbContext : IWebDbContext
    {
        public DbSet<CtWebLog> CtWebLogs { get; set; }
        public DbSet<JibunPostCdD> JibunPostCdDs { get; set; }
        public DbSet<MServiceDomain> MServiceDomains { get; set; }
        public DbSet<NPsGungu> NPsGungus { get; set; }
        public DbSet<QuesCheckList> QuesCheckLists { get; set; }
        public DbSet<QuesCompExtention> QuesCompExtentions { get; set; }
        public DbSet<QuesCompHistory> QuesCompHistories { get; set; }
        public DbSet<QuesCompInfo> QuesCompInfoes { get; set; }
        public DbSet<QuesMaster> QuesMasters { get; set; }
        public DbSet<QuesOgranAnalysis> QuesOgranAnalysis { get; set; }
        public DbSet<QuesResult1> QuesResult1 { get; set; }
        public DbSet<QuesResult2> QuesResult2 { get; set; }
        public DbSet<QuesWriter> QuesWriters { get; set; }
        public DbSet<RptCheckList> RptCheckLists { get; set; }
        public DbSet<RptFinanceComment> RptFinanceComments { get; set; }
        public DbSet<RptMaster> RptMasters { get; set; }
        public DbSet<RptMentorCheck> RptMentorChecks { get; set; }
        public DbSet<RptMentorComment> RptMentorComments { get; set; }
        public DbSet<RptMentorRadio> RptMentorRadios { get; set; }
        public DbSet<RptMngCode> RptMngCodes { get; set; }
        public DbSet<RptMngComment> RptMngComments { get; set; }
        public DbSet<RptPageView> RptPageViews { get; set; }
        public DbSet<RptStatusView> RptStatusViews { get; set; }
        public DbSet<ScBizType> ScBizTypes { get; set; }
        public DbSet<ScBizWork> ScBizWorks { get; set; }
        public DbSet<ScCav> ScCavs { get; set; }
        public DbSet<ScCompanyFinance> ScCompanyFinances { get; set; }
        public DbSet<ScCompInfo> ScCompInfoes { get; set; }
        public DbSet<ScCompMapping> ScCompMappings { get; set; }
        public DbSet<ScExpertMapping> ScExpertMappings { get; set; }
        public DbSet<ScFaq> ScFaqs { get; set; }
        public DbSet<ScFileInfo> ScFileInfoes { get; set; }
        public DbSet<ScFinancialIndexT> ScFinancialIndexTs { get; set; }
        public DbSet<ScForm> ScForms { get; set; }
        public DbSet<ScFormFile> ScFormFiles { get; set; }
        public DbSet<ScMak> ScMaks { get; set; }
        public DbSet<ScMentoringFileInfo> ScMentoringFileInfoes { get; set; }
        public DbSet<ScMentoringReport> ScMentoringReports { get; set; }
        public DbSet<ScMentoringTotalReport> ScMentoringTotalReports { get; set; }
        public DbSet<ScMentoringTrFileInfo> ScMentoringTrFileInfoes { get; set; }
        public DbSet<ScMentorMappiing> ScMentorMappiings { get; set; }
        public DbSet<ScNtc> ScNtcs { get; set; }
        public DbSet<ScQa> ScQas { get; set; }
        public DbSet<ScQcl> ScQcls { get; set; }
        public DbSet<ScReqDoc> ScReqDocs { get; set; }
        public DbSet<ScReqDocFile> ScReqDocFiles { get; set; }
        public DbSet<ScUsr> ScUsrs { get; set; }
        public DbSet<ScUsrResume> ScUsrResumes { get; set; }
        public DbSet<SyDareDbInfo> SyDareDbInfoes { get; set; }

        public FakeWebDbContext()
        {
            CtWebLogs = new FakeDbSet<CtWebLog>();
            JibunPostCdDs = new FakeDbSet<JibunPostCdD>();
            MServiceDomains = new FakeDbSet<MServiceDomain>();
            NPsGungus = new FakeDbSet<NPsGungu>();
            QuesCheckLists = new FakeDbSet<QuesCheckList>();
            QuesCompExtentions = new FakeDbSet<QuesCompExtention>();
            QuesCompHistories = new FakeDbSet<QuesCompHistory>();
            QuesCompInfoes = new FakeDbSet<QuesCompInfo>();
            QuesMasters = new FakeDbSet<QuesMaster>();
            QuesOgranAnalysis = new FakeDbSet<QuesOgranAnalysis>();
            QuesResult1 = new FakeDbSet<QuesResult1>();
            QuesResult2 = new FakeDbSet<QuesResult2>();
            QuesWriters = new FakeDbSet<QuesWriter>();
            RptCheckLists = new FakeDbSet<RptCheckList>();
            RptFinanceComments = new FakeDbSet<RptFinanceComment>();
            RptMasters = new FakeDbSet<RptMaster>();
            RptMentorChecks = new FakeDbSet<RptMentorCheck>();
            RptMentorComments = new FakeDbSet<RptMentorComment>();
            RptMentorRadios = new FakeDbSet<RptMentorRadio>();
            RptMngCodes = new FakeDbSet<RptMngCode>();
            RptMngComments = new FakeDbSet<RptMngComment>();
            RptPageViews = new FakeDbSet<RptPageView>();
            RptStatusViews = new FakeDbSet<RptStatusView>();
            ScBizTypes = new FakeDbSet<ScBizType>();
            ScBizWorks = new FakeDbSet<ScBizWork>();
            ScCavs = new FakeDbSet<ScCav>();
            ScCompanyFinances = new FakeDbSet<ScCompanyFinance>();
            ScCompInfoes = new FakeDbSet<ScCompInfo>();
            ScCompMappings = new FakeDbSet<ScCompMapping>();
            ScExpertMappings = new FakeDbSet<ScExpertMapping>();
            ScFaqs = new FakeDbSet<ScFaq>();
            ScFileInfoes = new FakeDbSet<ScFileInfo>();
            ScFinancialIndexTs = new FakeDbSet<ScFinancialIndexT>();
            ScForms = new FakeDbSet<ScForm>();
            ScFormFiles = new FakeDbSet<ScFormFile>();
            ScMaks = new FakeDbSet<ScMak>();
            ScMentoringFileInfoes = new FakeDbSet<ScMentoringFileInfo>();
            ScMentoringReports = new FakeDbSet<ScMentoringReport>();
            ScMentoringTotalReports = new FakeDbSet<ScMentoringTotalReport>();
            ScMentoringTrFileInfoes = new FakeDbSet<ScMentoringTrFileInfo>();
            ScMentorMappiings = new FakeDbSet<ScMentorMappiing>();
            ScNtcs = new FakeDbSet<ScNtc>();
            ScQas = new FakeDbSet<ScQa>();
            ScQcls = new FakeDbSet<ScQcl>();
            ScReqDocs = new FakeDbSet<ScReqDoc>();
            ScReqDocFiles = new FakeDbSet<ScReqDocFile>();
            ScUsrs = new FakeDbSet<ScUsr>();
            ScUsrResumes = new FakeDbSet<ScUsrResume>();
            SyDareDbInfoes = new FakeDbSet<SyDareDbInfo>();
        }
        
        public int SaveChangesCount { get; private set; } 
        public int SaveChanges()
        {
            ++SaveChangesCount;
            return 1;
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
        }
        
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
