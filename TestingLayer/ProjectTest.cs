
using BusinessLayer;
using DataLayer;
using NUnit.Framework.Constraints;

namespace TestingLayer
{
    public class Tests
    {
        private ProjectContext _projectContext;
        private VacationManagerDbContext _dbContext;

        [SetUp]
        public void Setup()
        {
            _dbContext = new VacationManagerDbContext();
            _projectContext = new ProjectContext(_dbContext);
        }

        [Test]
        public async Task CreateTest()
        {
            var project = new Project("name", "description");
            await _projectContext.CreateAsync(project);
            Assert.That(await _projectContext.ReadAsync(project.Id), Is.EqualTo(project));
        }

        [Test]
        public async Task EditTest()
        {
            var project = new Project("name", "description");
            await _projectContext.CreateAsync(project);
      
            project.Name = "new name";
            project.Description = "new description";

            await _projectContext.UpdateAsync(project);
            var projectFromDb =  await _projectContext.ReadAsync(project.Id);
            Assert.That(projectFromDb.Name, Is.EqualTo(project.Name));
        }

        [Test]
        public async Task DeleteTest()
        {
            var project = new Project("name", "description");            
            await _projectContext.CreateAsync(project);
            
            await _projectContext.DeleteAsync(project.Id);
            Assert.That(
                async delegate
                {
                    await _projectContext.ReadAsync(project.Id);
                }, Throws.Exception);
        }
    }
}