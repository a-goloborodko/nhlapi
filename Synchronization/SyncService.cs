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
using Core.Sources;
using System;
using System.Linq;
using Synchronization.Models.PlayerProfile;

namespace Synchronization
{
    public class SyncService : Disposable
    {
        private IRepository<TeamStatistic> _repositoryTeamStat;
        private IRepository<TeamDetailStatistic> _repositoryTeamDetailStat;
        private IRepository<PlayerStatistic> _repositoryPlayerStatistics;
        private IRepository<Player> _repositoryPlayers;
        private IUnitOfWork _unitOfWork;
        private IDbFactory _dbFactory;
        SeasonHelper _seasonHelper = new SeasonHelper();
        public SyncService()
        {
            _dbFactory = new DbFactory();
            _unitOfWork = new UnitOfWork(_dbFactory);
            _repositoryTeamStat = _unitOfWork.GetRepository<TeamStatistic>();
            _repositoryTeamDetailStat = _unitOfWork.GetRepository<TeamDetailStatistic>();
            _repositoryPlayerStatistics = _unitOfWork.GetRepository<PlayerStatistic>();
            _repositoryPlayers = _unitOfWork.GetRepository<Player>();
        }

        public void UpdateTeamStat()
        {
            //hnl api url

            // string url = ApiUrls.TeamStatistic;
            //url += _seasonHelper.SeasonId.ToString();
            //url = HttpUtility.UrlEncode(url);

            //string url = @"http://www.nhl.com/stats/rest/grouped/teams/season/teamsummary?cayenneExp=seasonId=";
            string url = ApiUrls.TeamStatistic;
            url += _seasonHelper.CurrentSeasonId.ToString();
            url += @"%20and%20gameTypeId=";
            url += ((int)GameType.RegularSeason).ToString();

            ImportDataModel<TeamStatistic> teamStatisticsModel;

            using (WebClient client = new WebClient())
            using (Stream stream = client.OpenRead(url))
            using (StreamReader reader = new StreamReader(stream))
            {
                teamStatisticsModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ImportDataModel<TeamStatistic>>(reader.ReadToEnd().ToString());
            }

            if (teamStatisticsModel != null && teamStatisticsModel.Total > 0)
            {
                //delete old stat from db
                int seasonId = _seasonHelper.CurrentSeasonId;
                _repositoryTeamStat.Delete(x => x.SeasonId == seasonId);
                _unitOfWork.Commit();

                //Save new data
                _repositoryTeamStat.AddRange(teamStatisticsModel.Data);
                _unitOfWork.Commit();
            }
        }

        public void UpdateDetailStatistics()
        {
            string url = string.Format(ApiUrls.TeamDetailStatistic, _seasonHelper.CurrentSeasonId.ToString(), ((int)GameType.RegularSeason));

            ImportDataModel<TeamDetailStatistic> teamDetailStatisticsModel;

            using (WebClient client = new WebClient())
            using (Stream stream = client.OpenRead(url))
            using (StreamReader reader = new StreamReader(stream))
            {
                teamDetailStatisticsModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ImportDataModel<TeamDetailStatistic>>(reader.ReadToEnd().ToString());
            }

            if (teamDetailStatisticsModel != null && teamDetailStatisticsModel.Total > 0)
            {
                //delete old stat from db
                int seasonId = _seasonHelper.CurrentSeasonId;
                _repositoryTeamDetailStat.Delete(x => x.SeasonId == seasonId);
                _unitOfWork.Commit();

                //Save new data
                _repositoryTeamDetailStat.AddRange(teamDetailStatisticsModel.Data);
                _unitOfWork.Commit();
            }
        }

        public void UpdatePlayerStatistics()
        {
            string url = string.Format(ApiUrls.PlayerStatistics, _seasonHelper.CurrentSeasonId.ToString(), ((int)GameType.RegularSeason));

            ImportDataModel<PlayerStatistic> playerStatisticsModel;

            using (WebClient client = new WebClient())
            using (Stream stream = client.OpenRead(url))
            using (StreamReader reader = new StreamReader(stream))
            {
                playerStatisticsModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ImportDataModel<PlayerStatistic>>(reader.ReadToEnd().ToString());
            }

            if (playerStatisticsModel != null && playerStatisticsModel.Total > 0)
            {
                //delete old stat from db
                int seasonId = _seasonHelper.CurrentSeasonId;
                _repositoryPlayerStatistics.Delete(x => x.SeasonId == seasonId);
                _unitOfWork.Commit();

                //Save new data
                //Add player profile if not exist
                int currentSeasonId = _seasonHelper.CurrentSeasonId;

                foreach (var playerStat in playerStatisticsModel.Data.ToList())
                {
                    playerStat.SeasonId = currentSeasonId;

                    Player player = _repositoryPlayers.GetById(playerStat.PlayerId);

                    //create player profile
                    if (player == null)
                    {
                        string playerUrl = string.Format(ApiUrls.PlayerProfile, playerStat.PlayerId);
                        PlayerProfileModel playerProfileModel;


                        using (WebClient client = new WebClient())
                        using (Stream stream = client.OpenRead(playerUrl))
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            playerProfileModel = Newtonsoft.Json.JsonConvert.DeserializeObject<PlayerProfileModel>(reader.ReadToEnd().ToString());

                            Player playerToInsert = GetPlayerFromModel(playerProfileModel);

                            if (playerToInsert != null)
                            {
                                _repositoryPlayers.Add(playerToInsert);
                                playerStat.Player = playerToInsert;
                            }
                            //don't save player without team 
                            else
                            {
                                playerStatisticsModel.Data.Remove(playerStat);
                            }
                        }
                    }
                }

                _repositoryPlayerStatistics.AddRange(playerStatisticsModel.Data);
                _unitOfWork.Commit();
            }
        }

        private Player GetPlayerFromModel(PlayerProfileModel people)
        {
            PlayerModel playerModel = people.People.First();
            if (people.People.First().CurrentTeam == null)
                return null;

            return new Player
            {
                Id = playerModel.Id,
                Active = playerModel.Active,
                AlternateCaptain = playerModel.AlternateCaptain,
                BirthCity = playerModel.BirthCity,
                BirthCountry = playerModel.BirthCountry,
                BirthDate = playerModel.BirthDate,
                Captain = playerModel.Captain,
                FirstName = playerModel.FirstName,
                Height = playerModel.Height,
                LastName = playerModel.LastName,
                Link = playerModel.Link,
                Nationality = playerModel.Nationality,
                Position = playerModel.PrimaryPosition.Abbreviation,
                PrimaryNumber = playerModel.PrimaryNumber,
                Rookie = playerModel.Rookie,
                Weight = playerModel.Weight,
                TeamId = playerModel.CurrentTeam.Id
            };
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

            if (_repositoryPlayerStatistics != null)
                _repositoryPlayerStatistics.Dispose();

            if (_repositoryPlayers != null)
                _repositoryPlayers.Dispose();
        }
    }
}
