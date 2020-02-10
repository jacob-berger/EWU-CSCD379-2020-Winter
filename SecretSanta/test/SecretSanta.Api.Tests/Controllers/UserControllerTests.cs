using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Api.Controllers;
using SecretSanta.Business;
using SecretSanta.Business.Dto;
using SecretSanta.Data;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SecretSanta.Api.Tests.Controllers
{
    [TestClass]
    public class UserControllerTests : BaseApiControllerTests<Business.Dto.User, UserInput, Data.User>
    {

        protected override Business.Dto.User CreateDto()
        {
            return new Business.Dto.User
            {
                FirstName = Guid.NewGuid().ToString(),
                LastName = Guid.NewGuid().ToString()
            };
        }

        protected override Data.User CreateEntity()
        {
            return new Data.User(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        }

        protected override UserInput CreateInput()
        {
            return new UserInput
            {
                FirstName = Guid.NewGuid().ToString(),
                LastName = Guid.NewGuid().ToString()
            };
        }

        [TestMethod]
        public async Task Get_ReturnsUsers()
        {
            //Arrange
            using ApplicationDbContext context = Factory.GetDbContext();
            Data.User im = SampleData.CreateInigoMontoya();
            context.Users.Add(im);
            context.SaveChanges();

            HttpClient client = Factory.CreateClient();

            //Uri uri = new Uri("api/User");

            //Act
            HttpResponseMessage response = await client.GetAsync("api/User");

            //Assert
            response.EnsureSuccessStatusCode();
            string jsonData = await response.Content.ReadAsStringAsync();

            Business.Dto.User[] users = JsonSerializer.Deserialize<Business.Dto.User[]>(jsonData);
            Assert.AreEqual(21, users.Length);
            Assert.AreEqual(users[0].Id, im.Id);
            Assert.AreEqual(users[0].FirstName, im.FirstName);
            Assert.AreEqual(users[0].LastName, im.LastName);
        }
    }
}
