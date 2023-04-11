using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace TestingLayer
{
    internal class TeamTest
    {
        private ProjectContext _projectContext;
        private TeamContext _teamContext;
        private VacationManagerDbContext _dbContext;
        private Project project;

        [SetUp]
        public void Setup()
        {
            _dbContext = new VacationManagerDbContext();
            _teamContext = new TeamContext(_dbContext);
            _projectContext = new ProjectContext(_dbContext);
            project = new Project("name", "description");

        }

        [Test]
        public async Task CreateTeam()
        {
            await _projectContext.CreateAsync(project);

            var team = new Team("name", project);
            await _teamContext.CreateAsync(team);
            Assert.That(await _teamContext.ReadAsync(team.Id), Is.EqualTo(team));
        }

        [Test]
        public async Task EditTeam()
        {
            await _projectContext.CreateAsync(project);

            var team = new Team("name", project);
            await _teamContext.CreateAsync(team);

            team.Name = "new name";

            await _teamContext.UpdateAsync(team);
            var teamFromDb = await _teamContext.ReadAsync(team.Id);
            Assert.That(teamFromDb.Name, Is.EqualTo(team.Name));
        }

        [Test]
        public async Task DeleteTeam()
        {
            await _projectContext.CreateAsync(project);

            var team = new Team("name", project);
            await _teamContext.CreateAsync(team);

            await _teamContext.DeleteAsync(team.Id);
            Assert.That(
                async delegate
                {
                    await _teamContext.ReadAsync(team.Id);
                }, Throws.Exception);
        }
    }
}
