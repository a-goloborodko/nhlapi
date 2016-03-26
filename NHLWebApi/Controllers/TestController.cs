using Core.Data;
using Core.Interfaces;
using DAL.Repositories;
using NHLWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NHLWebApi.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        private IRepository<Team> _repository;
        public TestController()
        {
            _repository = new Repository<Team>(new EFDbContext());
        }

        [HttpPost]
        [Route("import")]
        public IHttpActionResult ImportTeams(List<TeamModel> teams)
        {
            foreach (TeamModel team in teams)
            {
                _repository.Insert(new Team
                {
                    Id = team.Id,
                    Name = team.Name,
                    Link = team.Link,
                    Abbreviation = team.Abbreviation,
                    TeamName = team.TeamName,
                    LocationName = team.LocationName,
                    FirstYearOfPlay = team.FirstYearOfPlay,
                    DivisionId = team.DivisionId,
                    ConferenceId = team.ConferenceId,
                    OfficialSiteUrl = team.OfficialSiteUrl,
                    ShortName = team.ShortName,
                    Active = team.Active
                });
            }

            _repository.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("test")]
        public IHttpActionResult TestGet()
        {
            IEnumerable<Team> teams = _repository.GetAll();

            return Ok<IEnumerable<Team>>(teams);
        }
    }
}
