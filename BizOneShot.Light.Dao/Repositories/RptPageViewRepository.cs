using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BizOneShot.Light.Dao.Infrastructure;
using BizOneShot.Light.Models.WebModels;

namespace BizOneShot.Light.Dao.Repositories
{
    public interface IRptPageListRepository : IRepository<RptPageView>
    {
        Task<IList<RptPageView>> GetRptPageListsAsync(int questionSn, int bizworkSn, int? basicyear);
    }
    public class RptPageListRepository : RepositoryBase<RptPageView>, IRptPageListRepository
    {
        public RptPageListRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<IList<RptPageView>> GetRptPageListsAsync(int questionSn, int bizworkSn, int? basicyear)
        {
            return await DbContext.RptPageViews.Where(bw => bw.QuestionSn == questionSn)
                .Where(bw => bw.BizWorkSn == bizworkSn)
                .Where(bw => bw.BasicYear == basicyear)
                .Where(bw => bw.RequireField=="Y") 
                //.AsNoTracking()
                .ToListAsync();
        }
    }

}
