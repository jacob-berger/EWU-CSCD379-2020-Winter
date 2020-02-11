using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Api.Controllers;
using SecretSanta.Business;
using SecretSanta.Business.Dto;
using SecretSanta.Data;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
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
            HttpClient client = Factory.CreateClient();
            //test setup creates and adds 20 users
            Uri uri = new Uri("api/User", UriKind.RelativeOrAbsolute);

            //Act
            HttpResponseMessage response = await client.GetAsync(uri);

            //Assert
            response.EnsureSuccessStatusCode();
            string jsonData = await response.Content.ReadAsStringAsync();

            Business.Dto.User[] users = JsonSerializer.Deserialize<Business.Dto.User[]>(jsonData);
            Assert.AreEqual(20, users.Length);
        }

        [TestMethod]
        public async Task Put_MissingId_NotFound()
        {
            //Arrange
            HttpClient client = Factory.CreateClient();
            Uri uri = new Uri("api/User/1000", UriKind.RelativeOrAbsolute);

            //Act
            HttpResponseMessage response = await client.GetAsync(uri);

            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
        }

        [TestMethod]
        public async Task Put_WithId_UpdatesEntry()
        {
            //Arrange
            HttpClient client = Factory.CreateClient();

            using ApplicationDbContext context = Factory.GetDbContext();
            Data.User originalUser = await context.Users.FirstOrDefaultAsync();
            UserInput userInput = CreateInput();
            userInput.FirstName += " changed";
            userInput.LastName += " changed";
            string jsonSerialized = JsonSerializer.Serialize(userInput);
            Uri uri = new Uri($"api/User/{originalUser.Id}", UriKind.RelativeOrAbsolute);

            //Act
            using StringContent stringContent = new StringContent(jsonSerialized, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();
            string jsonData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            Business.Dto.User result = JsonSerializer.Deserialize<Business.Dto.User>(jsonData, options);

            //Assert
            Assert.AreEqual(userInput.FirstName, result.FirstName);
            Assert.AreEqual(userInput.LastName, result.LastName);

            Data.User databaseEntitiy = await context.Users.FindAsync(result.Id);
            Assert.AreEqual(databaseEntitiy.FirstName, result.FirstName);
            Assert.AreEqual(databaseEntitiy.LastName, result.LastName);
        }

        [TestMethod]
        public async Task Put_NullName_ReturnsBadRequest()
        {
            //Arrange
            using ApplicationDbContext context = Factory.GetDbContext();
            HttpClient client = Factory.CreateClient();
            UserInput userInput = CreateInput();
            userInput.FirstName = null;
            string jsonSerialized = JsonSerializer.Serialize(userInput);
            Uri uri = new Uri("api/User/19", UriKind.RelativeOrAbsolute);

            using StringContent stringContent = new StringContent(jsonSerialized, Encoding.UTF8, "application/json");


            //Act
            HttpResponseMessage response = await client.PutAsync(uri, stringContent);

            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task Post_ValidData_CreatesUser()
        {
            //Arrange
            using ApplicationDbContext context = Factory.GetDbContext();
            HttpClient client = Factory.CreateClient();
            Business.Dto.UserInput userInput = CreateInput();
            string json = JsonSerializer.Serialize(userInput);
            using StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            Uri uri = new Uri("api/User", UriKind.RelativeOrAbsolute);

            //Act
            HttpResponseMessage response = await client.PostAsync(uri, stringContent);
            response.EnsureSuccessStatusCode();

            //Assert

            string result = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            Business.Dto.User user = JsonSerializer.Deserialize<Business.Dto.User>(result, options);

            Assert.AreEqual(userInput.FirstName, user.FirstName);
            Assert.AreEqual(userInput.LastName, user.LastName);

            Data.User databaseUser = await context.Users.FindAsync(user.Id);
            Assert.AreEqual(userInput.FirstName, databaseUser.FirstName);
            Assert.AreEqual(userInput.LastName, databaseUser.LastName);
        }
    }
}
