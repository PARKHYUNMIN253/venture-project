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
    public interface IScUsrRepository : IRepository<ScUsr>
    {
        Task<IList<ScUsr>> GetScUsrById(string loginId);
        ScUsr Insert(ScUsr scUsr);
        Task<ScUsr> GetMentorInfoById(Expression<Func<ScUsr, bool>> where);
        Task<ScUsr> getScUsrByCompSn(Expression<Func<ScUsr, bool>> where);
        int UserPasswordReset(ScUsr scUsr);
    }


    public class ScUsrRepository : RepositoryBase<ScUsr>, IScUsrRepository
    {
        public ScUsrRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<IList<ScUsr>> GetScUsrById(string loginId)
        {
            var usrInfo = await DbContext.ScUsrs.Where(ci => ci.LoginId == loginId).ToListAsync();
            return usrInfo;
        }

        public ScUsr Insert(ScUsr scUsr)
        {

            return DbContext.ScUsrs.Add(scUsr);

        }

        //public async Task<ScUsr> GetMentorInfoById(string loginId)
        //{
        //    var scusr = await this.DbContext.ScUsrs
        //        .Include(i => i.ScUsrResume)
        //        //.Include(i => i.ScUsrResume.ScFileInfo)
        //        .Include(i => i.ScMentorMappiings.Select(s => s.ScBizWork))
        //        .Where(ci => ci.LoginId == loginId && ci.Status == "N").FirstOrDefaultAsync();
        //    return scusr;
        //}

        /// <summary>
        ///     맨토정보 가져오기(Eager 로딩, include ScUsrResume, ScMentorMappiings.Select(s => s.ScBizWork)
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        
        public async Task<ScUsr> GetMentorInfoById(Expression<Func<ScUsr, bool>> where)
        {
            var scusr = await DbContext.ScUsrs
                .Include(i => i.ScUsrResume)
                //.Include(i => i.ScUsrResume.ScFileInfo)
                .Include(i => i.ScMentorMappiings.Select(s => s.ScBizWork))
                .Where(where).FirstOrDefaultAsync();
            return scusr;
        }

        // PW를 디폴트 값으로 초기화 시키는 부분
        public int UserPasswordReset(ScUsr scUsr) 
        {
            // pw 초기화
            var commandString =
                string.Format("UPDATE SC_USR SET LOGIN_PW='9FCEFC0080D894E83CA7D360CE5CCD9EAD2C5D8A80A10F9FA9698510AABA865A' WHERE LOGIN_ID ='mentorL'");

            //string.Format("SELECT LOGIN_PW FROM SC_USR WHERE SC_USR.LOGIN_ID");

            // update SC_USR set LOGIN_PW='[sha256을 통해 암호화된 pw]' where LOGIN_ID='[변경하고자 하는 user의 ID]';

            return DbContext.Database.ExecuteSqlCommand(commandString);

        }

        public async Task<ScUsr> getScUsrByCompSn(Expression<Func<ScUsr, bool>> where)
        {
            return await DbContext.ScUsrs.Where(where).SingleOrDefaultAsync();
        }
    }
}