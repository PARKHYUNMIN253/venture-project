using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BizOneShot.Light.Models.ViewModels;
using BizOneShot.Light.Services;
using BizOneShot.Light.Web.ComLib;
using PagedList;
using BizOneShot.Light.Models.WebModels;

namespace BizOneShot.Light.Web.Areas.Mentor.Controllers
{
    [UserAuthorize(Order = 1)]
    [MenuAuthorize(Roles = UserType.Mentor, Order = 2)]
    public class ReportController : BaseController
    {

        private readonly IScCompMappingService scCompMappingService;
        private readonly IScMentorMappingService scMentorMappingService;
        private readonly IRptMasterService rptMasterService;

        private readonly IQuesMasterService quesMasterService;
        private readonly IScBizWorkService scBizWorkService;
        private readonly IScCompInfoService scCompInfoService;

        public ReportController(
            IScCompMappingService scCompMappingService,
            IScMentorMappingService scMentorMappingService,
            IRptMasterService rptMasterService,
            IQuesMasterService quesMasterService,
            IScBizWorkService scBizWorkService,
            IScCompInfoService scCompInfoService)
        {
            this.scCompMappingService = scCompMappingService;
            this.scMentorMappingService = scMentorMappingService;
            this.rptMasterService = rptMasterService;
            this.quesMasterService = quesMasterService;
            this.scBizWorkService = scBizWorkService;
            this.scCompInfoService = scCompInfoService;
        }


        // GET: Mentor/Report
        public ActionResult Index()
        {

            return View();
        }

        public async Task<ActionResult> BasicSurveyReport(string curPage, BasicSurveyReportViewModel paramModel)
        {
            ViewBag.LeftMenu = Global.Report;

            if (paramModel.BizWorkYear == 0)
                paramModel.BizWorkYear = 2016;

            var bizWorkYearDropDown = ReportHelper.MakeYear(2015);
            SelectList bizWorkYear = new SelectList(bizWorkYearDropDown, "Value", "Text");
            ViewBag.SelectBizWorkYearList = bizWorkYear;

            var mentorId = Session[Global.LoginID].ToString();
            if (string.IsNullOrEmpty(paramModel.Status))
                paramModel.Status = "";

            var listScMentorMapping = await scMentorMappingService.GetMentorMappingListByMentorId(mentorId, paramModel.BizWorkYear);
            var listScBizWork = listScMentorMapping.Select(mmp => mmp.ScBizWork).ToList();
            ViewBag.SelectBizWorkList = ReportHelper.MakeBizWorkList(null);

            var listScCompMapping = await scCompMappingService.GetCompMappingListByMentorId(mentorId, "A", paramModel.BizWorkSn, paramModel.BizWorkYear);
            var listScCompInfo = listScCompMapping.Select(cmp => cmp.ScCompInfo).ToList();
            ViewBag.SelectCompInfoList = ReportHelper.MakeCompanyList(null);
            ViewBag.SelectStatusList = ReportHelper.MakeReportStatusList();

            //기초역량 보고서 조회
            int pagingSize = int.Parse(ConfigurationManager.AppSettings["PagingSize"]);
            int pageSize = int.Parse(ConfigurationManager.AppSettings["PagingSize"]);

            // listScCompInfo -> RegistrationNo를 추출
            var compsRegistrationNo = listScCompInfo.Select(cmp => cmp.RegistrationNo).ToList();

            var rptMsters = await rptMasterService.GetRptMasterList(int.Parse(curPage ?? "1"), pagingSize, mentorId, paramModel.BizWorkYear, paramModel.BizWorkSn, paramModel.CompSn, paramModel.Status);

            //뷰모델 맵핑
            var rptMasterListView = Mapper.Map<List<BasicSurveyReportViewModel>>(rptMsters);

            // ---------------------
            //var listScCompInfoMapping = await scCompMappingService.GetCompMappingInfoPagedListByMentorId(paramModel.BizWorkSn, mentorId, "A", paramModel.BizWorkYear, int.Parse(curPage), pageSize);

            var comListViews =
                Mapper.Map<List<BasicSurveyReportViewModel>>(rptMasterListView);

            // pagedListScBizWork.subset.CompSn
            int allCompanyCount = 0;
            int completedCompanyCount = 0;

            foreach (BasicSurveyReportViewModel v in comListViews)
            {
                if (v.Status.Equals("C")) completedCompanyCount++;
                allCompanyCount++;
            }

            ViewBag.TotalCountForMember = allCompanyCount;
            ViewBag.CompleteCount = completedCompanyCount;

            // ---------------------

            return View(new StaticPagedList<BasicSurveyReportViewModel>(rptMasterListView, int.Parse(curPage ?? "1"), pagingSize, rptMsters.TotalItemCount));
        }

        [HttpPost]
        public async Task<ActionResult> BasicSurveyReport(BasicSurveyReportViewModel paramModel, string curPage)
        {

            ViewBag.LeftMenu = Global.Report;
            //사업년도 DownDown List Data
            //ViewBag.SelectBizWorkYearList = ReportHelper.MakeYear(2015);

            var bizWorkYearDropDown = ReportHelper.MakeYear(2015);
            SelectList bizWorkYear = new SelectList(bizWorkYearDropDown, "Value", "Text");
            ViewBag.SelectBizWorkYearList = bizWorkYear;

            var mentorId = Session[Global.LoginID].ToString();
            if (string.IsNullOrEmpty(paramModel.Status))
                paramModel.Status = "";

            //사업 DropDown List Data 
            var listScMentorMapping = await scMentorMappingService.GetMentorMappingListByMentorId(mentorId, paramModel.BizWorkYear);
            var listScBizWork = listScMentorMapping.Select(mmp => mmp.ScBizWork).ToList();
            ViewBag.SelectBizWorkList = ReportHelper.MakeBizWorkList(listScBizWork);

            var listScCompMapping = await scCompMappingService.GetCompMappingListByMentorId(mentorId, "A", paramModel.BizWorkSn, paramModel.BizWorkYear);
            var listScCompInfo = listScCompMapping.Select(cmp => cmp.ScCompInfo).ToList();
            ViewBag.SelectCompInfoList = ReportHelper.MakeCompanyList(listScCompInfo);
            ViewBag.SelectStatusList = ReportHelper.MakeReportStatusList();

            //기초역량 보고서 조회
            int pagingSize = int.Parse(ConfigurationManager.AppSettings["PagingSize"]);
            int pageSize = int.Parse(ConfigurationManager.AppSettings["PagingSize"]);

            // listScCompInfo -> RegistrationNo를 추출
            var compsRegistrationNo = listScCompInfo.Select(cmp => cmp.RegistrationNo).ToList();

            var rptMsters = await rptMasterService.GetRptMasterList(int.Parse(curPage ?? "1"), pagingSize, mentorId, paramModel.BizWorkYear, paramModel.BizWorkSn, paramModel.CompSn, paramModel.Status);

            //뷰모델 맵핑
            var rptMasterListView = Mapper.Map<List<BasicSurveyReportViewModel>>(rptMsters);

            // ---------------------
            //var listScCompInfoMapping = await scCompMappingService.GetCompMappingInfoPagedListByMentorId(paramModel.BizWorkSn, mentorId, "A", paramModel.BizWorkYear, int.Parse(curPage), pageSize);

            var comListViews =
                Mapper.Map<List<BasicSurveyReportViewModel>>(rptMasterListView);

            // pagedListScBizWork.subset.CompSn
            int allCompanyCount = 0;
            int completedCompanyCount = 0;

            foreach (BasicSurveyReportViewModel v in comListViews)
            {
                if (v.Status.Equals("C")) completedCompanyCount++;
                allCompanyCount++;
            }

            ViewBag.TotalCountForMember = allCompanyCount;
            ViewBag.CompleteCount = completedCompanyCount;
            
            // ---------------------

            return View(new StaticPagedList<BasicSurveyReportViewModel>(rptMasterListView, int.Parse(curPage ?? "1"), pagingSize, rptMsters.TotalItemCount));

        }

        #region 드롭다운박스 처리 controller
        [HttpPost]
        public async Task<JsonResult> GetBizWorkNm(int Year)
        {
            var compSn = Session[Global.CompSN].ToString();
            var mentorId = Session[Global.LoginID].ToString();

            // page처리
            int pagingSize = int.Parse(ConfigurationManager.AppSettings["PagingSize"]);
            int pageSize = int.Parse(ConfigurationManager.AppSettings["PagingSize"]);

            //사업 DropDown List Data
            var listScMentorMapping = scMentorMappingService.GetMentorMappingListByMentorIdSync(mentorId, Year);

            var listScBizWork = listScMentorMapping.Select(mmp => mmp.ScBizWork).ToList();
            var bizList = ReportHelper.MakeBizWorkList(listScBizWork);

            return Json(bizList);
        }

        [HttpPost]
        public async Task<JsonResult> GetCompanyNm(int BizWorkSn, int Year)
        {
            var compSn = Session[Global.CompSN].ToString();
            var mentorId = Session[Global.LoginID].ToString();

            var listScCompMapping = await scCompMappingService.GetCompMappingListByMentorId(mentorId, "A", BizWorkSn, Year);
            var listScCompInfo = listScCompMapping.Select(cmp => cmp.ScCompInfo).ToList();

            var bizList = ReportHelper.MakeCompanyList(listScCompInfo);

            return Json(bizList);
        }

        #endregion

        #region

        #endregion

        #region
        public async Task<ActionResult> TotalCompCount(string bizWorkSn, string bizWorkNm, int year, int curPage = 1)
        {
            ViewBag.LeftMenu = Global.Report;
            ViewBag.BizWorkNm = bizWorkNm;

            //int pagingSize = int.Parse(ConfigurationManager.AppSettings["PagingSize"]);
            //int pageSize = int.Parse(ConfigurationManager.AppSettings["PagingSize"]);

            int pagingSize = 100;
            int pageSize = 100;

            var mentorId = Session[Global.LoginID].ToString();

            // 멘토가 담당하는 기업 list를 PageList 형식으로 
            var listScCompInfoMapping = await scCompMappingService.GetCompMappingInfoPagedListByMentorId(int.Parse(bizWorkSn), mentorId, "A", curPage, pageSize);

            var comListViews =
                Mapper.Map<List<JoinCompanyViewModel>>(listScCompInfoMapping);

            ViewBag.BizWorkSN = bizWorkSn;
            // pagedListScBizWork.subset.CompSn
            int allCompanyCount = 0;
            int completedCompanyCount = 0;

            foreach (JoinCompanyViewModel v in comListViews)
            {
                if (v.Status.Equals("C")) completedCompanyCount++;
                allCompanyCount++;
            }

            ViewBag.TotalCountForMember = allCompanyCount;
            ViewBag.CompleteCount = completedCompanyCount;

            return View(new StaticPagedList<JoinCompanyViewModel>(comListViews, listScCompInfoMapping.PageNumber, pagingSize, listScCompInfoMapping.TotalItemCount));
        }
        #endregion

        public async Task<ActionResult> EditReport(int year, int questionSn, string status)
        {
            RptMaster rpt = await rptMasterService.SelectRpt(year, questionSn, status);

            rpt.Status = "P";

            await rptMasterService.SaveDbContextAsync();

            return RedirectToAction("BasicSurveyReport", "Report", new { area = "Mentor", });
        }

    }
}