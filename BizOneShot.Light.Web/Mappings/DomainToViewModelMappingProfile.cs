using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;
using BizOneShot.Light.Models.ViewModels;
using BizOneShot.Light.Models.WebModels;
using BizOneShot.Light.Models.DareModels;
using BizOneShot.Light.Util.Helper;

namespace BizOneShot.Light.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {

        protected override void Configure()
        {
            //여기에 Object-To-Object 매핑정의를 생성(필요할때 계속 추가)
            Mapper.CreateMap<ScFaq, FaqViewModel>()
                   .ForMember(d => d.QclNm, map => map.MapFrom(s => s.ScQcl.QclNm));

            Mapper.CreateMap<ScQcl, QclDropDownModel>();

            //공지사항 Notice 매핑
            Mapper.CreateMap<ScNtc, NoticeViewModel>();

            Mapper.CreateMap<ScNtc, NoticeDetailViewModel>()
                .ForMember(d => d.PreNoticeSn, map => map.UseValue(0))
                .ForMember(d => d.NextNoticeSn, map => map.UseValue(0));

            //매뉴얼 Manual 매핑
            Mapper.CreateMap<ScForm, ManualViewModel>();

            Mapper.CreateMap<ScForm, ManualDetailViewModel>()
                .ForMember(d => d.Manual, map => map.MapFrom(s => s))
                .ForMember(d => d.PreFormSn, map => map.UseValue(0))
                .ForMember(d => d.NextFormSn, map => map.UseValue(0));

            //파일 FileInfo 매핑
            Mapper.CreateMap<ScFileInfo, FileInfoViewModel>();

            Mapper.CreateMap<ScFileInfo, FileContent>();

            //Company MyInfo 매핑;
            Mapper.CreateMap<ScUsr, CompanyMyInfoViewModel>()
                .ForMember(d => d.TelNo1, map => map.MapFrom(s => s.TelNo.Split('-').GetValue(0).ToString()))
                .ForMember(d => d.TelNo2, map => map.MapFrom(s => s.TelNo.Split('-').GetValue(1).ToString()))
                .ForMember(d => d.TelNo3, map => map.MapFrom(s => s.TelNo.Split('-').GetValue(2).ToString()))
                .ForMember(d => d.MbNo1, map => map.MapFrom(s => s.MbNo.Split('-').GetValue(0).ToString()))
                .ForMember(d => d.MbNo2, map => map.MapFrom(s => s.MbNo.Split('-').GetValue(1).ToString()))
                .ForMember(d => d.MbNo3, map => map.MapFrom(s => s.MbNo.Split('-').GetValue(2).ToString()))
                .ForMember(d => d.Email1, map => map.MapFrom(s => s.Email.Split('@').GetValue(0).ToString()))
                .ForMember(d => d.Email2, map => map.MapFrom(s => s.Email.Split('@').GetValue(1).ToString()))

                .ForMember(d => d.ComTelNo1, map => map.MapFrom(s => s.ScCompInfo.TelNo.Split('-').GetValue(0).ToString()))
                .ForMember(d => d.ComTelNo2, map => map.MapFrom(s => s.ScCompInfo.TelNo.Split('-').GetValue(1).ToString()))
                .ForMember(d => d.ComTelNo3, map => map.MapFrom(s => s.ScCompInfo.TelNo.Split('-').GetValue(2).ToString()))
                .ForMember(d => d.ComAddr, map => map.MapFrom(s => "(" + s.ScCompInfo.PostNo + ") " + s.ScCompInfo.Addr1 + " " + s.ScCompInfo.Addr2))
                .ForMember(d => d.ComPostNo, map => map.MapFrom(s => s.ScCompInfo.PostNo))
                .ForMember(d => d.ComAddr1, map => map.MapFrom(s => s.ScCompInfo.Addr1))
                .ForMember(d => d.ComAddr2, map => map.MapFrom(s => s.ScCompInfo.Addr2))
                .ForMember(d => d.ComOwnNm, map => map.MapFrom(s => s.ScCompInfo.OwnNm))
                .ForMember(d => d.CompNm, map => map.MapFrom(s => s.ScCompInfo.CompNm))
                .ForMember(d => d.ComRegistrationNo, map => map.MapFrom(s => s.ScCompInfo.RegistrationNo))
                .ForMember(d => d.ComTelNo, map => map.MapFrom(s => s.ScCompInfo.TelNo));


            //회원가입 매핑
            Mapper.CreateMap<ScUsr, JoinCompanyViewModel>()
                .ForMember(d => d.TelNo1, map => map.MapFrom(s => s.TelNo.Split('-').GetValue(0).ToString()))
                .ForMember(d => d.TelNo2, map => map.MapFrom(s => s.TelNo.Split('-').GetValue(1).ToString()))
                .ForMember(d => d.TelNo3, map => map.MapFrom(s => s.TelNo.Split('-').GetValue(2).ToString()))
                .ForMember(d => d.FaxNo1, map => map.MapFrom(s => s.FaxNo.Split('-').GetValue(0).ToString()))
                .ForMember(d => d.FaxNo2, map => map.MapFrom(s => s.FaxNo.Split('-').GetValue(1).ToString()))
                .ForMember(d => d.FaxNo3, map => map.MapFrom(s => s.FaxNo.Split('-').GetValue(2).ToString()))
                .ForMember(d => d.MbNo1, map => map.MapFrom(s => s.MbNo.Split('-').GetValue(0).ToString()))
                .ForMember(d => d.MbNo2, map => map.MapFrom(s => s.MbNo.Split('-').GetValue(1).ToString()))
                .ForMember(d => d.MbNo3, map => map.MapFrom(s => s.MbNo.Split('-').GetValue(2).ToString()))
                .ForMember(d => d.Email1, map => map.MapFrom(s => s.Email.Split('@').GetValue(0).ToString()))
                .ForMember(d => d.Email2, map => map.MapFrom(s => s.Email.Split('@').GetValue(1).ToString()))
                .ForMember(d => d.CompNm, map => map.MapFrom(s => s.ScCompInfo.CompNm))
                .ForMember(d => d.UseErp, map => map.MapFrom(s => s.UseErp == "0" ? false : true));

            //사업관리자 뷰 매핑
            Mapper.CreateMap<ScUsr, BizMngDropDownModel>()
                .ForMember(d => d.CompSn, map => map.MapFrom(s => s.ScCompInfo.CompSn))
                .ForMember(d => d.CompNm, map => map.MapFrom(s => s.ScCompInfo.CompNm));

            Mapper.CreateMap<ScCompInfo, BizMngDropDownModel>()
                .ForMember(d => d.CompSn, map => map.MapFrom(s => s.CompSn))
                .ForMember(d => d.CompNm, map => map.MapFrom(s => s.CompNm));

            //사업 뷰 매핑
            Mapper.CreateMap<ScBizWork, BizWorkDropDownModel>();

            Mapper.CreateMap<ScExpertMapping, BizWorkDropDownModel>()
                .ForMember(d => d.BizWorkSn, map => map.MapFrom(s => s.ScBizWork.BizWorkSn))
                .ForMember(d => d.BizWorkNm, map => map.MapFrom(s => s.ScBizWork.BizWorkNm));

            //전문가 회원 뷰 매핑
            Mapper.CreateMap<ScUsr, JoinExpertViewModel>()
                .ForMember(d => d.BizMagComName, map => map.MapFrom(s => s.ScExpertMappings.ElementAt(0).ScBizWork.ScCompInfo.CompNm))
                .ForMember(d => d.BizMngCompSn, map => map.MapFrom(s => s.ScExpertMappings.ElementAt(0).ScBizWork.ScCompInfo.CompSn))
                .ForMember(d => d.ResumeName, map => map.MapFrom(s => s.ScUsrResume.ScFileInfo.Status == "N" ? s.ScUsrResume.ScFileInfo.FileNm : ""))
                .ForMember(d => d.ResumePath, map => map.MapFrom(s => s.ScUsrResume.ScFileInfo.Status == "N" ? s.ScUsrResume.ScFileInfo.FilePath : ""))
                .ForMember(d => d.FileSn, map => map.MapFrom(s => s.ScUsrResume.ScFileInfo.FileSn))
                .ForMember(d => d.ComPostNo, map => map.MapFrom(s => s.ScCompInfo.PostNo))
                .ForMember(d => d.ComAddr1, map => map.MapFrom(s => s.ScCompInfo.Addr1))
                .ForMember(d => d.ComAddr2, map => map.MapFrom(s => s.ScCompInfo.Addr2))
                .ForMember(d => d.ComOwnNm, map => map.MapFrom(s => s.ScCompInfo.OwnNm))
                .ForMember(d => d.CompNm, map => map.MapFrom(s => s.ScCompInfo.CompNm))
                .ForMember(d => d.ComRegistrationNo, map => map.MapFrom(s => s.ScCompInfo.RegistrationNo))
                .ForMember(d => d.TelNo1, map => map.MapFrom(s => s.TelNo.Split('-').GetValue(0).ToString()))
                .ForMember(d => d.TelNo2, map => map.MapFrom(s => s.TelNo.Split('-').GetValue(1).ToString()))
                .ForMember(d => d.TelNo3, map => map.MapFrom(s => s.TelNo.Split('-').GetValue(2).ToString()))
                .ForMember(d => d.MbNo1, map => map.MapFrom(s => s.MbNo.Split('-').GetValue(0).ToString()))
                .ForMember(d => d.MbNo2, map => map.MapFrom(s => s.MbNo.Split('-').GetValue(1).ToString()))
                .ForMember(d => d.MbNo3, map => map.MapFrom(s => s.MbNo.Split('-').GetValue(2).ToString()))
                .ForMember(d => d.Email1, map => map.MapFrom(s => s.Email.Split('@').GetValue(0).ToString()))
                .ForMember(d => d.Email2, map => map.MapFrom(s => s.Email.Split('@').GetValue(1).ToString()));

            Mapper.CreateMap<ScExpertMapping, JoinExpertViewModel>()
                .ForMember(d => d.BizMagComName, map => map.MapFrom(s => s.ScBizWork.ScCompInfo.CompNm))
                .ForMember(d => d.BizMngCompSn, map => map.MapFrom(s => s.ScBizWork.ScCompInfo.CompSn))
                .ForMember(d => d.BizWorkNm, map => map.MapFrom(s => s.ScBizWork.BizWorkNm))


                .ForMember(d => d.ResumeName, map => map.MapFrom(s => s.ScUsr.ScUsrResume.ScFileInfo.Status == "N" ? s.ScUsr.ScUsrResume.ScFileInfo.FileNm : ""))
                .ForMember(d => d.ResumePath, map => map.MapFrom(s => s.ScUsr.ScUsrResume.ScFileInfo.Status == "N" ? s.ScUsr.ScUsrResume.ScFileInfo.FilePath : ""))

                .ForMember(d => d.FileSn, map => map.MapFrom(s => s.ScUsr.ScUsrResume.ScFileInfo.FileSn))
                .ForMember(d => d.ComPostNo, map => map.MapFrom(s => s.ScUsr.ScCompInfo.PostNo))
                .ForMember(d => d.ComAddr1, map => map.MapFrom(s => s.ScUsr.ScCompInfo.Addr1))
                .ForMember(d => d.ComAddr2, map => map.MapFrom(s => s.ScUsr.ScCompInfo.Addr2))
                .ForMember(d => d.ComOwnNm, map => map.MapFrom(s => s.ScUsr.ScCompInfo.OwnNm))
                .ForMember(d => d.CompNm, map => map.MapFrom(s => s.ScUsr.ScCompInfo.CompNm))
                .ForMember(d => d.ComTelNo, map => map.MapFrom(s => s.ScUsr.ScCompInfo.TelNo))
                .ForMember(d => d.ComRegistrationNo, map => map.MapFrom(s => s.ScUsr.ScCompInfo.RegistrationNo))
                .ForMember(d => d.TelNo1, map => map.MapFrom(s => s.ScUsr.TelNo.Split('-').GetValue(0).ToString()))
                .ForMember(d => d.TelNo2, map => map.MapFrom(s => s.ScUsr.TelNo.Split('-').GetValue(1).ToString()))
                .ForMember(d => d.TelNo3, map => map.MapFrom(s => s.ScUsr.TelNo.Split('-').GetValue(2).ToString()))
                .ForMember(d => d.TelNo, map => map.MapFrom(s => s.ScUsr.TelNo))
                .ForMember(d => d.MbNo1, map => map.MapFrom(s => s.ScUsr.MbNo.Split('-').GetValue(0).ToString()))
                .ForMember(d => d.MbNo2, map => map.MapFrom(s => s.ScUsr.MbNo.Split('-').GetValue(1).ToString()))
                .ForMember(d => d.MbNo3, map => map.MapFrom(s => s.ScUsr.MbNo.Split('-').GetValue(2).ToString()))
                .ForMember(d => d.MbNo, map => map.MapFrom(s => s.ScUsr.MbNo))
                .ForMember(d => d.Email1, map => map.MapFrom(s => s.ScUsr.Email.Split('@').GetValue(0).ToString()))
                .ForMember(d => d.Email2, map => map.MapFrom(s => s.ScUsr.Email.Split('@').GetValue(1).ToString()))
                .ForMember(d => d.Email, map => map.MapFrom(s => s.ScUsr.Email))
                .ForMember(d => d.Name, map => map.MapFrom(s => s.ScUsr.Name))
                .ForMember(d => d.LoginId, map => map.MapFrom(s => s.ScUsr.LoginId))
                .ForMember(d => d.UsrTypeDetail, map => map.MapFrom(s => s.ScUsr.UsrTypeDetail));


            Mapper.CreateMap<ScBizWork, BizWorkViewModel>()
                .ForMember(d => d.ComCount, map => map.MapFrom(s => s.ScCompMappings.Count))
                .ForMember(d => d.Name, map => map.MapFrom(s => s.ScUsr.Name))
                .ForMember(d => d.TelNo1, map => map.MapFrom(s => s.ScUsr.TelNo.Split('-').GetValue(0).ToString()))
                .ForMember(d => d.TelNo2, map => map.MapFrom(s => s.ScUsr.TelNo.Split('-').GetValue(1).ToString()))
                .ForMember(d => d.TelNo3, map => map.MapFrom(s => s.ScUsr.TelNo.Split('-').GetValue(2).ToString()))
                .ForMember(d => d.TelNo, map => map.MapFrom(s => s.ScUsr.TelNo))
                .ForMember(d => d.MbNo1, map => map.MapFrom(s => s.ScUsr.MbNo.Split('-').GetValue(0).ToString()))
                .ForMember(d => d.MbNo2, map => map.MapFrom(s => s.ScUsr.MbNo.Split('-').GetValue(1).ToString()))
                .ForMember(d => d.MbNo3, map => map.MapFrom(s => s.ScUsr.MbNo.Split('-').GetValue(2).ToString()))
                .ForMember(d => d.MbNo, map => map.MapFrom(s => s.ScUsr.MbNo))
                .ForMember(d => d.FaxNo1, map => map.MapFrom(s => s.ScUsr.FaxNo.Split('-').GetValue(0).ToString()))
                .ForMember(d => d.FaxNo2, map => map.MapFrom(s => s.ScUsr.FaxNo.Split('-').GetValue(1).ToString()))
                .ForMember(d => d.FaxNo3, map => map.MapFrom(s => s.ScUsr.FaxNo.Split('-').GetValue(2).ToString()))
                .ForMember(d => d.FaxNo, map => map.MapFrom(s => s.ScUsr.FaxNo))
                .ForMember(d => d.Email1, map => map.MapFrom(s => s.ScUsr.Email.Split('@').GetValue(0).ToString()))
                .ForMember(d => d.Email2, map => map.MapFrom(s => s.ScUsr.Email.Split('@').GetValue(1).ToString()))
                .ForMember(d => d.Email, map => map.MapFrom(s => s.ScUsr.Email))
                .ForMember(d => d.LoginId, map => map.MapFrom(s => s.ScUsr.LoginId))
                .ForMember(d => d.DeptNm, map => map.MapFrom(s => s.ScUsr.DeptNm));


            Mapper.CreateMap<ScCompInfo, JoinCompanyViewModel>()
                .ForMember(d => d.TelNo1, map => map.MapFrom(s => s.ScUsrs.ElementAt(0).TelNo.Split('-').GetValue(0).ToString()))
                .ForMember(d => d.TelNo2, map => map.MapFrom(s => s.ScUsrs.ElementAt(0).TelNo.Split('-').GetValue(1).ToString()))
                .ForMember(d => d.TelNo3, map => map.MapFrom(s => s.ScUsrs.ElementAt(0).TelNo.Split('-').GetValue(2).ToString()))
                .ForMember(d => d.Email1, map => map.MapFrom(s => s.ScUsrs.ElementAt(0).Email.Split('@').GetValue(0).ToString()))
                .ForMember(d => d.Email2, map => map.MapFrom(s => s.ScUsrs.ElementAt(0).Email.Split('@').GetValue(1).ToString()))
                .ForMember(d => d.Name, map => map.MapFrom(s => s.ScUsrs.ElementAt(0).Name))
                .ForMember(d => d.CompNm, map => map.MapFrom(s => s.CompNm))
                .ForMember(d => d.ComOwnNm, map => map.MapFrom(s => s.OwnNm))
                .ForMember(d => d.ComRegistrationNo, map => map.MapFrom(s => s.RegistrationNo));

            //멘토 회원 등록 매핑
            Mapper.CreateMap<ScMentorMappiing, JoinMentorViewModel>()
                .ForMember(d => d.BizWorkNm, map => map.MapFrom(s => s.ScBizWork.BizWorkNm))
                .ForMember(d => d.LoginId, map => map.MapFrom(s => s.ScUsr.LoginId))
                .ForMember(d => d.Email, map => map.MapFrom(s => s.ScUsr.Email))
                .ForMember(d => d.TelNo, map => map.MapFrom(s => s.ScUsr.TelNo))

                .ForMember(d => d.MbNo, map => map.MapFrom(s => s.ScUsr.MbNo))
                .ForMember(d => d.FaxNo, map => map.MapFrom(s => s.ScUsr.FaxNo))
                .ForMember(d => d.PostNo, map => map.MapFrom(s => s.ScUsr.PostNo))
                .ForMember(d => d.Addr1, map => map.MapFrom(s => s.ScUsr.Addr1))
                .ForMember(d => d.Addr2, map => map.MapFrom(s => s.ScUsr.Addr2))

                .ForMember(d => d.Name, map => map.MapFrom(s => s.ScUsr.Name))
                .ForMember(d => d.UsrTypeDetail, map => map.MapFrom(s => s.ScUsr.UsrTypeDetail))
                .ForMember(d => d.BankNm, map => map.MapFrom(s => s.ScUsr.BankNm))
                .ForMember(d => d.AccountNo, map => map.MapFrom(s => s.ScUsr.AccountNo))
                .ForMember(d => d.ResumeName, map => map.MapFrom(s => s.ScUsr.ScUsrResume.ScFileInfo.Status == "N" ? s.ScUsr.ScUsrResume.ScFileInfo.FileNm : ""))
                .ForMember(d => d.ResumePath, map => map.MapFrom(s => s.ScUsr.ScUsrResume.ScFileInfo.Status == "N" ? s.ScUsr.ScUsrResume.ScFileInfo.FilePath : ""));

            Mapper.CreateMap<ScUsr, JoinMentorViewModel>();

            //맨토 회원 뷰 매핑
            Mapper.CreateMap<ScUsr, MentorMyInfoViewModel>()
                .ForMember(d => d.TelNo1, map => map.MapFrom(s => s.TelNo.Split('-').GetValue(0).ToString()))
                .ForMember(d => d.TelNo2, map => map.MapFrom(s => s.TelNo.Split('-').GetValue(1).ToString()))
                .ForMember(d => d.TelNo3, map => map.MapFrom(s => s.TelNo.Split('-').GetValue(2).ToString()))
                .ForMember(d => d.FaxNo1, map => map.MapFrom(s => s.FaxNo.Split('-').GetValue(0).ToString()))
                .ForMember(d => d.FaxNo2, map => map.MapFrom(s => s.FaxNo.Split('-').GetValue(1).ToString()))
                .ForMember(d => d.FaxNo3, map => map.MapFrom(s => s.MbNo.Split('-').GetValue(2).ToString()))
                .ForMember(d => d.MbNo1, map => map.MapFrom(s => s.MbNo.Split('-').GetValue(0).ToString()))
                .ForMember(d => d.MbNo2, map => map.MapFrom(s => s.MbNo.Split('-').GetValue(1).ToString()))
                .ForMember(d => d.MbNo3, map => map.MapFrom(s => s.MbNo.Split('-').GetValue(2).ToString()))
                .ForMember(d => d.Email1, map => map.MapFrom(s => s.Email.Split('@').GetValue(0).ToString()))
                .ForMember(d => d.Email2, map => map.MapFrom(s => s.Email.Split('@').GetValue(1).ToString()))
                .ForMember(d => d.FileSn, map => map.MapFrom(s => s.ScUsrResume.ScFileInfo.FileSn))
                .ForMember(d => d.ResumeName, map => map.MapFrom(s => s.ScUsrResume.ScFileInfo.Status == "N" ? s.ScUsrResume.ScFileInfo.FileNm : ""))
                .ForMember(d => d.ResumePath, map => map.MapFrom(s => s.ScUsrResume.ScFileInfo.Status == "N" ? s.ScUsrResume.ScFileInfo.FilePath : ""))
                .ForMember(d => d.Addr, map => map.MapFrom(s => "(" + s.PostNo + ") " + s.Addr1 + " " + s.Addr2))
                .ForMember(d => d.BizWorkNm, map => map.MapFrom(s => s.ScMentorMappiings.FirstOrDefault().ScBizWork.BizWorkNm ?? ""));

            //맨토 토탈 레포트 뷰
            Mapper.CreateMap<ScMentoringTotalReport, MentoringTotalReportViewModel>()
                .ForMember(d => d.BizWorkNm, map => map.MapFrom(s => s.ScBizWork.BizWorkNm))
                .ForMember(d => d.BizWorkStDt, map => map.MapFrom(s => s.ScBizWork.BizWorkStDt))
                .ForMember(d => d.BizWorkEdDt, map => map.MapFrom(s => s.ScBizWork.BizWorkEdDt))
                .ForMember(d => d.CompNm, map => map.MapFrom(s => s.ScCompInfo.CompNm))
                .ForMember(d => d.MentorNm, map => map.MapFrom(s => s.ScUsr.Name))
                .ForMember(d => d.FileContents, map => map.MapFrom(s => s.ScMentoringTrFileInfoes.Select(mtfi => mtfi.ScFileInfo)));

            //멘토 일지 뷰
            Mapper.CreateMap<ScMentoringReport, MentoringReportViewModel>()
                .ForMember(d => d.BizWorkNm, map => map.MapFrom(s => s.ScBizWork.BizWorkNm))
                .ForMember(d => d.BizWorkStDt, map => map.MapFrom(s => s.ScBizWork.BizWorkStDt))
                .ForMember(d => d.BizWorkEdDt, map => map.MapFrom(s => s.ScBizWork.BizWorkEdDt))
                .ForMember(d => d.CompNm, map => map.MapFrom(s => s.ScCompInfo.CompNm))
                .ForMember(d => d.MentorAreaNm, map => map.MapFrom(s => s.MentorAreaCd == "" ? "" : new BizHelper().getMentorAreaNm(s.MentorAreaCd)))
                .ForMember(d => d.MentorNm, map => map.MapFrom(s => s.ScUsr.Name))
                .ForMember(d => d.FileContents, map => map.MapFrom(s => s.ScMentoringFileInfoes.Select(mtfi => mtfi.ScFileInfo)));

            //기업 뷰 매핑
            Mapper.CreateMap<ScCompInfo, CompInfoDropDownModel>();

            //기업 회원 관리(사업관리자) 뷰 매핑
            Mapper.CreateMap<ScCompMapping, CompanyMngViewModel>()
                .ForMember(d => d.ApproveRequestDate, map => map.MapFrom(s => s.RegDt.GetValueOrDefault().ToShortDateString()))
                .ForMember(d => d.CompNm, map => map.MapFrom(s => s.ScCompInfo.CompNm))
                .ForMember(d => d.RegistrationNo, map => map.MapFrom(s => s.ScCompInfo.RegistrationNo))
                .ForMember(d => d.OwnNm, map => map.MapFrom(s => s.ScCompInfo.OwnNm))
                .ForMember(d => d.BizWorkNm, map => map.MapFrom(s => s.ScBizWork.BizWorkNm))
                .ForMember(d => d.MngCompSn, map => map.MapFrom(s => s.ScBizWork.ScCompInfo.CompSn))
                .ForMember(d => d.PostNo, map => map.MapFrom(s => s.ScCompInfo.PostNo))
                .ForMember(d => d.Addr1, map => map.MapFrom(s => s.ScCompInfo.Addr1))
                .ForMember(d => d.Addr2, map => map.MapFrom(s => s.ScCompInfo.Addr2))
                .ForMember(d => d.Name, map => map.MapFrom(s => s.ScBizWork.ScUsr.Name))
                .ForMember(d => d.TelNo, map => map.MapFrom(s => s.ScBizWork.ScUsr.TelNo))
                .ForMember(d => d.MbNo, map => map.MapFrom(s => s.ScBizWork.ScUsr.MbNo))
                .ForMember(d => d.Email, map => map.MapFrom(s => s.ScBizWork.ScUsr.Email))
                .ForMember(d => d.MentorLoginId, map => map.MapFrom(s => s.MentorId))
                .ForMember(d => d.MentorName, map => map.MapFrom(s => s.ScUsr.Name))
                .ForMember(d => d.MentorTelNo, map => map.MapFrom(s => s.ScUsr.TelNo))
                .ForMember(d => d.MentorMbNo, map => map.MapFrom(s => s.ScUsr.MbNo))
                .ForMember(d => d.MentorEmail, map => map.MapFrom(s => s.ScUsr.Email));

            Mapper.CreateMap<ScMentorMappiing, MentorDropDownModel>()
                .ForMember(d => d.LoginId, map => map.MapFrom(s => s.ScUsr.LoginId))
                .ForMember(d => d.Name, map => map.MapFrom(s => s.ScUsr.Name));

            Mapper.CreateMap<ScUsr, MentorDropDownModel>();

            //기업 회원 관리(사업관리자) 뷰 매핑
            Mapper.CreateMap<ScCompMapping, ExpertCompanyViewModel>()
                .ForMember(d => d.CompNm, map => map.MapFrom(s => s.ScCompInfo.CompNm))
                .ForMember(d => d.ComRegistrationNo, map => map.MapFrom(s => s.ScCompInfo.RegistrationNo))
                .ForMember(d => d.ComOwnNm, map => map.MapFrom(s => s.ScCompInfo.OwnNm))
                .ForMember(d => d.CompSn, map => map.MapFrom(s => s.ScCompInfo.CompSn))
                .ForMember(d => d.Name, map => map.MapFrom(s => s.ScCompInfo.ScUsrs.ElementAt(0).Name))
                .ForMember(d => d.TelNo, map => map.MapFrom(s => s.ScCompInfo.ScUsrs.ElementAt(0).TelNo))
                .ForMember(d => d.Email, map => map.MapFrom(s => s.ScCompInfo.ScUsrs.ElementAt(0).Email))
                .ForMember(d => d.LoginId, map => map.MapFrom(s => s.ScCompInfo.ScUsrs.ElementAt(0).LoginId));

            Mapper.CreateMap<ScReqDoc, DataRequstViewModels>()
                .ForMember(d => d.SenderName, map => map.MapFrom(s => s.ScUsr_SenderId.Name))
                .ForMember(d => d.SenderComNm, map => map.MapFrom(s => s.ScUsr_SenderId.ScCompInfo.CompNm))
                .ForMember(d => d.SenderRegistrationNo, map => map.MapFrom(s => s.ScUsr_SenderId.ScCompInfo.RegistrationNo))
                .ForMember(d => d.ReceiverName, map => map.MapFrom(s => s.ScUsr_ReceiverId.Name))
                .ForMember(d => d.ReceiverComNm, map => map.MapFrom(s => s.ScUsr_ReceiverId.ScCompInfo.CompNm))
                .ForMember(d => d.ReceiverRegistrationNo, map => map.MapFrom(s => s.ScUsr_ReceiverId.ScCompInfo.RegistrationNo));

            Mapper.CreateMap<ScQa, QaRequstViewModels>()
                .ForMember(d => d.QuestionComNm, map => map.MapFrom(s => s.ScUsr_QuestionId.ScCompInfo.CompNm))
                .ForMember(d => d.QuestionRegistrationNo, map => map.MapFrom(s => s.ScUsr_QuestionId.ScCompInfo.RegistrationNo))
                .ForMember(d => d.AnswerComNm, map => map.MapFrom(s => s.ScUsr_AnswerId.ScCompInfo.CompNm))
                .ForMember(d => d.AnswerRegistrationNo, map => map.MapFrom(s => s.ScUsr_AnswerId.ScCompInfo.RegistrationNo));

            Mapper.CreateMap<ScQa, QaRequstDetailViewModel>()
               .ForMember(d => d.QuestionComNm, map => map.MapFrom(s => s.ScUsr_QuestionId.ScCompInfo.CompNm))
               .ForMember(d => d.QuestionRegistrationNo, map => map.MapFrom(s => s.ScUsr_QuestionId.ScCompInfo.RegistrationNo))
               .ForMember(d => d.AnswerComNm, map => map.MapFrom(s => s.ScUsr_AnswerId.ScCompInfo.CompNm))
               .ForMember(d => d.AnswerRegistrationNo, map => map.MapFrom(s => s.ScUsr_AnswerId.ScCompInfo.RegistrationNo))
               .ForMember(d => d.PreUsrQaSn, map => map.UseValue(0))
               .ForMember(d => d.NextUsrQaSn, map => map.UseValue(0));

            Mapper.CreateMap<UspSelectSidoForWebListReturnModel, SelectAddressListViewModel>();
            Mapper.CreateMap<UspSelectGunguForWebListReturnModel, SelectGunguListViewModel>();
            Mapper.CreateMap<UspSelectAddressByBuildingSearchForWebListReturnModel, SelectAddressListViewModel>();
            Mapper.CreateMap<UspSelectAddressByDongSearchForWebListReturnModel, SelectAddressListViewModel>();
            Mapper.CreateMap<UspSelectAddressByStreetSearchForWebListReturnModel, SelectAddressListViewModel>();


            Mapper.CreateMap<ScUsr, LoginViewModel>()
                .ForMember(d => d.ID, map => map.MapFrom(s => s.LoginId));

            //문진표 맵퍼
            Mapper.CreateMap<QuesMaster, QuesMasterViewModel>();
            Mapper.CreateMap<QuesWriter, QuesWriterViewModel>();

            Mapper.CreateMap<QuesMaster, QuestionDropDownModel>()
                .ForMember(d => d.SnStatus, map => map.MapFrom(s => s.QuestionSn.ToString() + "#" + s.Status));

            Mapper.CreateMap<QuesCompInfo, QuesCompanyInfoViewModel>()
                .ForMember(d => d.PublishDt, map => map.MapFrom(s => s.PublishDt.GetValueOrDefault().ToShortDateString()));

            Mapper.CreateMap<QuesCompExtention, QuesCompExtentionViewModel>();
            Mapper.CreateMap<QuesCheckList, QuesCheckListViewModel>();
            Mapper.CreateMap<QuesResult1, QuesCheckListViewModel>()
                .ForMember(d => d.Title, map => map.MapFrom(s => s.QuesCheckList.Title))
                .ForMember(d => d.Content1, map => map.MapFrom(s => s.QuesCheckList.Content1))
                .ForMember(d => d.Content2, map => map.MapFrom(s => s.QuesCheckList.Content2));

            Mapper.CreateMap<QuesCheckList, QuesYearListViewModel>();
            Mapper.CreateMap<QuesResult2, QuesYearListViewModel>()
                .ForMember(d => d.DetailCd, map => map.MapFrom(s => s.QuesCheckList.DetailCd))
                .ForMember(d => d.SmallClassCd, map => map.MapFrom(s => s.QuesCheckList.SmallClassCd));

            Mapper.CreateMap<QuesOgranAnalysis, OrgCompositionViewModel>()
               .ForMember(d => d.PartialSum, map => map.MapFrom(s => s.ChiefCount + s.OfficerCount + s.BeginnerCount + s.StaffCount));

            //참여기업 통계
            Mapper.CreateMap<ScBizWork, BizInCompanyStatsViewModel>();
            Mapper.CreateMap<ScCompMapping, CompnayStatsViewModel>()
                .ForMember(d => d.CompNm, map => map.MapFrom(s => s.ScCompInfo.CompNm));

            //기업지원통계
            Mapper.CreateMap<ScBizWork, MentoringCompanyStatsViewModel>()
                .ForMember(d => d.AvgMentoringDays, map => map.UseValue(0))
                .ForMember(d => d.SumMentoringDays, map => map.UseValue(0))
                .ForMember(d => d.SumMentoring_D, map => map.UseValue(0))
                .ForMember(d => d.SumMentoring_F, map => map.UseValue(0))
                .ForMember(d => d.SumMentoring_L, map => map.UseValue(0))
                .ForMember(d => d.SumMentoring_M, map => map.UseValue(0))
                .ForMember(d => d.SumMentoring_P, map => map.UseValue(0))
                .ForMember(d => d.SumMentoring_T, map => map.UseValue(0))
                .ForMember(d => d.SumMentoring_W, map => map.UseValue(0))
                .ForMember(d => d.SumMentoring_E, map => map.UseValue(0));
            Mapper.CreateMap<ScCompMapping, MentoringStatByCompanyViewModel>()
                .ForMember(d => d.ComSn, map => map.MapFrom(s => s.ScCompInfo.CompSn))
                .ForMember(d => d.CompNm, map => map.MapFrom(s => s.ScCompInfo.CompNm))
                .ForMember(d => d.AvgMentoringDays, map => map.UseValue(0))
                .ForMember(d => d.SumMentoringDays, map => map.UseValue(0))
                .ForMember(d => d.SumMentoring_D, map => map.UseValue(0))
                .ForMember(d => d.SumMentoring_F, map => map.UseValue(0))
                .ForMember(d => d.SumMentoring_L, map => map.UseValue(0))
                .ForMember(d => d.SumMentoring_M, map => map.UseValue(0))
                .ForMember(d => d.SumMentoring_P, map => map.UseValue(0))
                .ForMember(d => d.SumMentoring_T, map => map.UseValue(0))
                .ForMember(d => d.SumMentoring_W, map => map.UseValue(0))
                .ForMember(d => d.SumMentoring_E, map => map.UseValue(0));

            Mapper.CreateMap<ScBizWork, MentoringMentorStatsViewModel>();
            Mapper.CreateMap<ScUsr, MentoringStatByMentorViewModel>()
                .ForMember(d => d.UsrTypeDetailName, map => map.MapFrom(s => s.UsrTypeDetail == "" ? "" : new BizHelper().getMentorAreaNm(s.UsrTypeDetail)));

            Mapper.CreateMap<ScBizWork, MentoringAreaStatsViewModel>();

            //기초역량 보고서 기업리스트
            Mapper.CreateMap<RptMaster, BasicSurveyReportViewModel>()
               .ForMember(d => d.BizWorkNm, map => map.MapFrom(s => s.ScBizWork.BizWorkNm))
               .ForMember(d => d.CompNm, map => map.MapFrom(s => s.ScCompInfo.CompNm))
               .ForMember(d => d.BizWorkYear, map => map.MapFrom(s => s.BasicYear))
               .ForMember(d => d.BizWorkMngrNm, map => map.MapFrom(s => s.ScBizWork.ScCompInfo.CompNm))
               .ForMember(d => d.QuestionCompleteDt, map => map.MapFrom(s => s.RegDt))
               .ForMember(d => d.RegistrationNo, map => map.MapFrom(s => s.ScCompInfo.RegistrationNo))
               .ForMember(d => d.OwnNm, map => map.MapFrom(s => s.ScCompInfo.OwnNm))
            ;

            //재무보고서 기업 리스트
            Mapper.CreateMap<ScCompMapping, BasicSurveyReportViewModel>()
               .ForMember(d => d.BizWorkNm, map => map.MapFrom(s => s.ScBizWork.BizWorkNm))
               .ForMember(d => d.CompNm, map => map.MapFrom(s => s.ScCompInfo.CompNm))
               .ForMember(d => d.BizWorkMngrNm, map => map.MapFrom(s => s.ScBizWork.ScCompInfo.CompNm))
               .ForMember(d => d.RegistrationNo, map => map.MapFrom(s => s.ScCompInfo.RegistrationNo))
               .ForMember(d => d.OwnNm, map => map.MapFrom(s => s.ScCompInfo.OwnNm))
               .ForMember(d => d.BizWorkYear, map => map.MapFrom(s => s.ScBizWork.BizWorkStDt.Value.Year))
            ;

            //기초역량보고서 커맨트 매핑
            Mapper.CreateMap<RptMentorComment, CommentViewModel>();

            //조직분화도
            Mapper.CreateMap<QuesOgranAnalysis, OrgEmpCompositionViewModel>()
               .ForMember(d => d.PartialSum, map => map.MapFrom(s => s.ChiefCount + s.OfficerCount + s.BeginnerCount + s.StaffCount));

            //재무 보고서 전문가 의견 조회
            Mapper.CreateMap<RptFinanceComment, RegCommentViewModel>()
                .ForMember(d => d.BizWorkNm, map => map.MapFrom(s => s.ScBizWork.BizWorkNm))
                .ForMember(d => d.ExpertNm, map => map.MapFrom(s => s.ScUsr.Name));


            //업태/업종 (다래테이블과)
            Mapper.CreateMap<SHUSER_AcStdIncmrateBseIdstT, BizTypeViewModel>()
                .ForMember(d => d.BizTypeCd, map => map.MapFrom(s => s.IdstCd))
                .ForMember(d => d.BizTypeNm, map => map.MapFrom(s => s.IdstDtlNm));

            Mapper.CreateMap<ScBizType, BizTypeViewModel>();

            //중소기업평균 등록
            Mapper.CreateMap<ScCav, RegCompanyAverageViewModel>();

            //상품화역량 시장현황 등록
            Mapper.CreateMap<ScMak, RegMarketStateViewModel>();

            // ScCompanyFinance에서 당기, 전기로...
            Mapper.CreateMap<ScCompanyFinance, FinanceCompositionViewModel>()
                .ForMember(d => d.FpACa, map => map.MapFrom(s => s.FpACa != null ? Math.Floor((decimal)s.FpACa) : 0))                          // 유동자산
                .ForMember(d => d.FpAQa, map => map.MapFrom(s => s.FpAQa != null ? Math.Floor((decimal)s.FpAQa) : 0))                           // 당좌자산
                .ForMember(d => d.FpATraderecv, map => map.MapFrom(s => s.FpATraderecv != null ? Math.Floor((decimal)s.FpATraderecv) : 0))             // 매출채권
                .ForMember(d => d.FpAIntent, map => map.MapFrom(s => s.FpAIntent != null ? Math.Floor((decimal)s.FpAIntent) : 0))                   // 재고자산
                .ForMember(d => d.FpAFixasset, map => map.MapFrom(s => s.FpAFixasset != null ? Math.Floor((decimal)s.FpAFixasset) : 0))               // 비유동자산
                .ForMember(d => d.FpATangible, map => map.MapFrom(s => s.FpATangible != null ? Math.Floor((decimal)s.FpATangible) : 0))               // 투자자산
                .ForMember(d => d.FpAInvest, map => map.MapFrom(s => s.FpAInvest != null ? Math.Floor((decimal)s.FpAInvest) : 0))                   // 유형자산
                .ForMember(d => d.FpAIntangible, map => map.MapFrom(s => s.FpAIntangible != null ? Math.Floor((decimal)s.FpAIntangible) : 0))           // 무형자산
                .ForMember(d => d.FpARndcost, map => map.MapFrom(s => s.FpARndcost != null ? Math.Floor((decimal)s.FpARndcost) : 0))                 // 개발비
                .ForMember(d => d.FpANoncurrentasset, map => map.MapFrom(s => s.FpANoncurrentasset != null ? Math.Floor((decimal)s.FpANoncurrentasset) : 0)) // 기타비유동자산
                .ForMember(d => d.FpASum, map => map.MapFrom(s => s.FpASum != null ? Math.Floor((decimal)s.FpASum) : 0))                         // 자산총계
                .ForMember(d => d.FpLCurrent, map => map.MapFrom(s => s.FpLCurrent != null ? Math.Floor((decimal)s.FpLCurrent) : 0))                 // 유동부채
                .ForMember(d => d.FpLLongterm, map => map.MapFrom(s => s.FpLLongterm != null ? Math.Floor((decimal)s.FpLLongterm) : 0))               // 비유동부채
                .ForMember(d => d.FpLSum, map => map.MapFrom(s => s.FpLSum != null ? Math.Floor((decimal)s.FpLSum) : 0))                         // 부채총계
                .ForMember(d => d.FpCStock, map => map.MapFrom(s => s.FpCStock != null ? Math.Floor((decimal)s.FpCStock) : 0))                     // 자본금
                .ForMember(d => d.FpCSurplus, map => map.MapFrom(s => s.FpCSurplus != null ? Math.Floor((decimal)s.FpCSurplus) : 0))                 // 자본잉여금
                .ForMember(d => d.FpCAdjust, map => map.MapFrom(s => s.FpCAdjust != null ? Math.Floor((decimal)s.FpCAdjust) : 0))                   // 자본조정
                .ForMember(d => d.FpCOthercomp, map => map.MapFrom(s => s.FpCOthercomp != null ? Math.Floor((decimal)s.FpCOthercomp) : 0))             // 기타포괄손익누계
                .ForMember(d => d.FpCRelatedearning, map => map.MapFrom(s => s.FpCRelatedearning != null ? Math.Floor((decimal)s.FpCRelatedearning) : 0))   // 이익잉여금
                .ForMember(d => d.FpCSum, map => map.MapFrom(s => s.FpCSum != null ? Math.Floor((decimal)s.FpCSum) : 0))                         // 자본총계
                .ForMember(d => d.CiSales, map => map.MapFrom(s => s.CiSales != null ? Math.Floor((decimal)s.CiSales) : 0))                       // 매출액
                .ForMember(d => d.CiCostofsales, map => map.MapFrom(s => s.CiCostofsales != null ? Math.Floor((decimal)s.CiCostofsales) : 0))           // 매출원가
                .ForMember(d => d.CiGrosspoint, map => map.MapFrom(s => s.CiGrosspoint != null ? Math.Floor((decimal)s.CiGrosspoint) : 0))             // 매출총이익
                .ForMember(d => d.CiAdminexpanses, map => map.MapFrom(s => s.CiAdminexpanses != null ? Math.Floor((decimal)s.CiAdminexpanses) : 0))       // 판매비와관리비
                .ForMember(d => d.CiWageBorder, map => map.MapFrom(s => s.CiWageBorder != null ? Math.Floor((decimal)s.CiWageBorder) : 0))             // 임원급여
                .ForMember(d => d.CiWageMain, map => map.MapFrom(s => s.CiWageMain != null ? Math.Floor((decimal)s.CiWageMain) : 0))                 // 급여
                .ForMember(d => d.CiWageBonus, map => map.MapFrom(s => s.CiWageBonus != null ? Math.Floor((decimal)s.CiWageBonus) : 0))               // 상여
                .ForMember(d => d.CiWageAllowances, map => map.MapFrom(s => s.CiWageAllowances != null ? Math.Floor((decimal)s.CiWageAllowances) : 0))     // 제수당
                .ForMember(d => d.CiWageOther, map => map.MapFrom(s => s.CiWageOther != null ? Math.Floor((decimal)s.CiWageOther) : 0))               // 잡급
                .ForMember(d => d.CiWageRetirepay, map => map.MapFrom(s => s.CiWageRetirepay != null ? Math.Floor((decimal)s.CiWageRetirepay) : 0))       // 퇴직급여
                .ForMember(d => d.CiRental, map => map.MapFrom(s => s.CiRental != null ? Math.Floor((decimal)s.CiRental) : 0))                     // 임차료
                .ForMember(d => d.CiDepexp, map => map.MapFrom(s => s.CiDepexp != null ? Math.Floor((decimal)s.CiDepexp) : 0))                     // 유형자산상각비
                .ForMember(d => d.CiAmoexp, map => map.MapFrom(s => s.CiAmoexp != null ? Math.Floor((decimal)s.CiAmoexp) : 0))                     // 무형자산상각비
                .ForMember(d => d.CiTax, map => map.MapFrom(s => s.CiTax != null ? Math.Floor((decimal)s.CiTax) : 0))                           // 세금과공과
                .ForMember(d => d.CiOrdevexp, map => map.MapFrom(s => s.CiOrdevexp != null ? Math.Floor((decimal)s.CiOrdevexp) : 0))                 // 경상개발비
                .ForMember(d => d.CiResearch, map => map.MapFrom(s => s.CiResearch != null ? Math.Floor((decimal)s.CiResearch) : 0))                 // 연구비
                .ForMember(d => d.CiDci, map => map.MapFrom(s => s.CiDci != null ? Math.Floor((decimal)s.CiDci) : 0))                           // 개발비상각액
                .ForMember(d => d.CiOpincome, map => map.MapFrom(s => s.CiOpincome != null ? Math.Floor((decimal)s.CiOpincome) : 0))                 // 영업이익
                .ForMember(d => d.CiOthergains, map => map.MapFrom(s => s.CiOthergains != null ? Math.Floor((decimal)s.CiOthergains) : 0))             // 영업외수익
                .ForMember(d => d.CiIntincome, map => map.MapFrom(s => s.CiIntincome != null ? Math.Floor((decimal)s.CiIntincome) : 0))               // 이자수익
                .ForMember(d => d.CiOtherloses, map => map.MapFrom(s => s.CiOtherloses != null ? Math.Floor((decimal)s.CiOtherloses) : 0))             // 영업외비용
                .ForMember(d => d.CiIntexpanses, map => map.MapFrom(s => s.CiIntexpanses != null ? Math.Floor((decimal)s.CiIntexpanses) : 0))           // 이자비용
                .ForMember(d => d.CiPlt, map => map.MapFrom(s => s.CiPlt != null ? Math.Floor((decimal)s.CiPlt) : 0))                           // 법인세비용차감전손익
                .ForMember(d => d.CiInctaxexp, map => map.MapFrom(s => s.CiInctaxexp != null ? Math.Floor((decimal)s.CiInctaxexp) : 0))               // 법인세비용
                .ForMember(d => d.CiProfit, map => map.MapFrom(s => s.CiProfit != null ? Math.Floor((decimal)s.CiProfit) : 0))                     // 당기순이익
                .ForMember(d => d.McRaw, map => map.MapFrom(s => s.McRaw != null ? Math.Floor((decimal)s.McRaw) : 0))                           // 원재료비
                .ForMember(d => d.McPart, map => map.MapFrom(s => s.McPart != null ? Math.Floor((decimal)s.McPart) : 0))                         // 부재료비
                .ForMember(d => d.McWages, map => map.MapFrom(s => s.McWages != null ? Math.Floor((decimal)s.McWages) : 0))                       // 노무비
                .ForMember(d => d.McOverhead, map => map.MapFrom(s => s.McOverhead != null ? Math.Floor((decimal)s.McOverhead) : 0))                 // 경비
                .ForMember(d => d.McRent, map => map.MapFrom(s => s.McRent != null ? Math.Floor((decimal)s.McRent) : 0))                         // 지급임차료
                .ForMember(d => d.McTax, map => map.MapFrom(s => s.McTax != null ? Math.Floor((decimal)s.McTax) : 0))                           // 세금과공과
                .ForMember(d => d.McRndexp, map => map.MapFrom(s => s.McRndexp != null ? Math.Floor((decimal)s.McRndexp) : 0))                     // 경상개발비
                .ForMember(d => d.McDepexp, map => map.MapFrom(s => s.McDepexp != null ? Math.Floor((decimal)s.McDepexp) : 0))                     // 감가상각비
                .ForMember(d => d.McYeartotal, map => map.MapFrom(s => s.McYeartotal != null ? Math.Floor((decimal)s.McYeartotal) : 0))               // 당기총제조비용
                .ForMember(d => d.McBegin, map => map.MapFrom(s => s.McBegin != null ? Math.Floor((decimal)s.McBegin) : 0))                       // 기초재공품재고액
                .ForMember(d => d.McFromother, map => map.MapFrom(s => s.McFromother != null ? Math.Floor((decimal)s.McFromother) : 0))               // 타계정에서대체액
                .ForMember(d => d.McTotal, map => map.MapFrom(s => s.McTotal != null ? Math.Floor((decimal)s.McTotal) : 0))                       // 합계
                .ForMember(d => d.McEnd, map => map.MapFrom(s => s.McEnd != null ? Math.Floor((decimal)s.McEnd) : 0))                           // 기말재공품재고액
                .ForMember(d => d.McToother, map => map.MapFrom(s => s.McToother != null ? Math.Floor((decimal)s.McToother) : 0))                   // 타계정으로대체액
                .ForMember(d => d.McFinishgoodscost, map => map.MapFrom(s => s.McFinishgoodscost != null ? Math.Floor((decimal)s.McFinishgoodscost) : 0));  // 당기제품제조원가

            //다른 멘토 의견 가져오기
            Mapper.CreateMap<RptMaster, SelectMentorCommentViewModel>();

            Mapper.CreateMap<RptMentorComment, SelectMentorCommentViewModel>()
                .ForMember(d => d.BizWorkNm, map => map.MapFrom(s => s.ScBizWork.BizWorkNm));

            Mapper.CreateMap<ScBizWork, SelectMentorCommentViewModel>();

            Mapper.CreateMap<QuesMaster, JoinCompanyViewModel>();

            // count가져오기 위한 mapping 
            Mapper.CreateMap<ScCompMapping, JoinCompanyViewModel>();



            Mapper.CreateMap<RptStatusView, JoinCompanyViewModel>()
               .ForMember(d => d.TelNo1, map => map.MapFrom(s => s.TelNo.Split('-').GetValue(0).ToString()))
               .ForMember(d => d.TelNo2, map => map.MapFrom(s => s.TelNo.Split('-').GetValue(1).ToString()))
               .ForMember(d => d.TelNo3, map => map.MapFrom(s => s.TelNo.Split('-').GetValue(2).ToString()))
               .ForMember(d => d.Email1, map => map.MapFrom(s => s.Email.Split('@').GetValue(0).ToString()))
               .ForMember(d => d.Email2, map => map.MapFrom(s => s.Email.Split('@').GetValue(1).ToString()))
               .ForMember(d => d.ComOwnNm, map => map.MapFrom(s => s.OwnNm))
               .ForMember(d => d.Status, map => map.MapFrom(s => s.QuesStatus))
               .ForMember(d => d.Name, map => map.MapFrom(s => s.MentorId));

            Mapper.CreateMap<RptStatusView, BasicSurveyReportViewModel>()
                .ForMember(d => d.Status, map => map.MapFrom(s => s.QuesStatus))
                .ForMember(d => d.CompNm, map => map.MapFrom(s => s.CompNm));

        }

    }
}