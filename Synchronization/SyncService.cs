using System.Net;
using System.IO;
using Synchronization.Models;
using DAL.Interfaces;
using Core.Models;
using Core.Helpers;
using DAL.Infrastructure;
using Core.Abstract;
using Core.Enums;
using System.Web;
using Core.Sorces;

namespace Synchronization
{
    public class SyncService : Disposable
    {
        private IRepository<TeamStatistic> _repositoryTeamStat;
        private IRepository<TeamDetailStatistic> _repositoryTeamDetailStat;
        private IUnitOfWork _unitOfWork;
        private IDbFactory _dbFactory;
        SeasonHelper _seasonHelper = new SeasonHelper();
        public SyncService()
        {
            _dbFactory = new DbFactory();
            _unitOfWork = new UnitOfWork(_dbFactory);
            _repositoryTeamStat = _unitOfWork.GetRepository<TeamStatistic>();
            _repositoryTeamDetailStat = _unitOfWork.GetRepository<TeamDetailStatistic>();
        }

        public void UpdateTeamStat()
        {
            //hnl api url

            // string url = ApiUrls.TeamStatistic;
            //url += _seasonHelper.SeasonId.ToString();
            //url = HttpUtility.UrlEncode(url);

            //string url = @"http://www.nhl.com/stats/rest/grouped/teams/season/teamsummary?cayenneExp=seasonId=";
            string url = ApiUrls.TeamStatistic;
            url += _seasonHelper.SeasonId.ToString();
            url += @"%20and%20gameTypeId=";
            url += ((int)GameType.RegularSeason).ToString();

            TeamStatisticModel teamStatisticsModel;

            using (WebClient client = new WebClient())
            using (Stream stream = client.OpenRead(url))
            using (StreamReader reader = new StreamReader(stream))
            {
                teamStatisticsModel = Newtonsoft.Json.JsonConvert.DeserializeObject<TeamStatisticModel>(reader.ReadToEnd().ToString());
            }

            if (teamStatisticsModel != null && teamStatisticsModel.Total > 0)
            {
                //delete old stat from db
                int seasonId = _seasonHelper.SeasonId;
                _repositoryTeamStat.Delete(x => x.SeasonId == seasonId);
                _unitOfWork.Commit();

                //Save new data
                _repositoryTeamStat.AddRange(teamStatisticsModel.Data);
                _unitOfWork.Commit();
            }
        }

        public void UpdateDetailStatistics()
        {
            string url = string.Format(ApiUrls.TeamDetailStatistic, _seasonHelper.SeasonId.ToString(), ((int)GameType.RegularSeason));

            TeamDetailStatisticModel teamDetailStatisticsModel;

            using (WebClient client = new WebClient())
            using (Stream stream = client.OpenRead(url))
            using (StreamReader reader = new StreamReader(stream))
            {
                teamDetailStatisticsModel = Newtonsoft.Json.JsonConvert.DeserializeObject<TeamDetailStatisticModel>(reader.ReadToEnd().ToString());
            }

            if (teamDetailStatisticsModel != null && teamDetailStatisticsModel.Total > 0)
            {
                //delete old stat from db
                int seasonId = _seasonHelper.SeasonId;
                _repositoryTeamDetailStat.Delete(x => x.SeasonId == seasonId);
                _unitOfWork.Commit();

                //Save new data
                _repositoryTeamDetailStat.AddRange(teamDetailStatisticsModel.Data);
                _unitOfWork.Commit();
            }
        }

        protected override void DisposeCore()
        {
            if (_dbFactory != null)
                _dbFactory.Dispose();

            if (_unitOfWork != null)
                _unitOfWork.Dispose();

            if (_repositoryTeamStat != null)
                _repositoryTeamStat.Dispose();

            if (_repositoryTeamDetailStat != null)
                _repositoryTeamDetailStat.Dispose();
        }
    }
}
