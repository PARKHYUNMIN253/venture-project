using BizOneShot.Light.Dao.Infrastructure;
using BizOneShot.Light.Dao.Repositories;
using BizOneShot.Light.Models.WebModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace BizOneShot.Light.Services
{
    public interface IRptPageService : IBaseService
    {
        Task<IList<RptPageView>> GetRptPageViewListAsync(int questionSn, int bizworkSn, int? basicyear);
    }

    public class RptPageViewService : IRptPageService
    {
        private readonly IRptPageListRepository _rptpageListRepository;
        private readonly IUnitOfWork unitOfWork;

        public RptPageViewService(IRptPageListRepository _rptpageListRepository, IUnitOfWork unitOfWork)
        {
            this._rptpageListRepository = _rptpageListRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<RptPageView>> GetRptPageViewListAsync(int questionSn, int bizworkSn, int? basicyear)
        {
            return await _rptpageListRepository.GetRptPageListsAsync(questionSn, bizworkSn, basicyear);
        }

        public void SaveDbContext()
        {
            unitOfWork.Commit();
        }

        public async Task<int> SaveDbContextAsync()
        {
            return await unitOfWork.CommitAsync();
        }
    }
}
