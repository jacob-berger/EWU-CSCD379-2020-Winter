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
    public class GiftControllerTests : BaseApiControllerTests<Business.Dto.Gift, GiftInput, Data.Gift>
    {
        protected override Business.Dto.Gift CreateDto()
        {
            return new Business.Dto.Gift();
        }

        protected override Data.Gift CreateEntity()
        {
            return new Data.Gift();
        }

        protected override GiftInput CreateInput()
        {
            return new GiftInput();
        }

        [TestMethod]
        public async Task Get_ReturnsGifts()
        {
            //Arrange
            using ApplicationDbContext context = Factory.GetDbContext();

            Data.Gift gift = SampleData.CreateGameboy();
            context.Gifts.Add(gift);
            context.SaveChanges();
            Uri uri = new Uri("api/Gift", UriKind.RelativeOrAbsolute);

            //Act
            HttpResponseMessage response = await Client.GetAsync(uri);

            //Assert
            response.EnsureSuccessStatusCode();
            string jsonData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            Business.Dto.Gift[] gifts = JsonSerializer.Deserialize<Business.Dto.Gift[]>(jsonData, options);

            Assert.AreEqual(gifts.Length, 1);
            Assert.AreEqual(gifts[0].Id, gift.Id);
            Assert.AreEqual(gifts[0].Title, gift.Title);
            Assert.AreEqual(gifts[0].Description, gift.Description);
            Assert.AreEqual(gifts[0].Url, gift.Url);
            Assert.AreEqual(gifts[0].UserId, gift.UserId);
        }

        [TestMethod]
        public async Task Put_MissingId_NotFound()
        {
            //Arrange
            Business.Dto.GiftInput giftInput = CreateInput();
            string jsonData = JsonSerializer.Serialize(giftInput);
            Uri uri = new Uri("api/Gift/1000", UriKind.RelativeOrAbsolute);
            using StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            //Act
            HttpResponseMessage response = await Client.PutAsync(uri, stringContent);

            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task Put_ValidId_UpdatesItem()
        {
            using ApplicationDbContext context = Factory.GetDbContext();
            Data.Gift gift = SampleData.CreateGameboy();
            context.Gifts.Add(gift);
            context.SaveChanges();

            Business.Dto.GiftInput giftInput = Mapper.Map<Data.Gift, Business.Dto.GiftInput>(gift);

            giftInput.Title += " changed";
            giftInput.Url += " changed";
            giftInput.Description += " changed";

            string jsonData = JsonSerializer.Serialize(giftInput);
            using StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            Uri uri = new Uri($"api/Gift/{gift.Id}", UriKind.RelativeOrAbsolute);

            //Act
            HttpResponseMessage response = await Client.PutAsync(uri, stringContent);

            //Assert
            response.EnsureSuccessStatusCode();
            string returnedJson = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            Business.Dto.Gift giftReturned = JsonSerializer.Deserialize<Business.Dto.Gift>(returnedJson, options);

            Assert.AreEqual(giftReturned.Title, giftInput.Title);
            Assert.AreEqual(giftReturned.Url, giftInput.Url);
            Assert.AreEqual(giftReturned.Description, giftInput.Description);
        }

        [TestMethod]
        [DataRow(nameof(Business.Dto.GiftInput.Title))]
        [DataRow(nameof(Business.Dto.GiftInput.UserId))]
        public async Task Post_WithoutRequiredProperty_BadRequest(string propName)
        {
            //Arrange
            Data.Gift gift = SampleData.CreateGameboy();
            Business.Dto.GiftInput giftInput = Mapper.Map<Data.Gift, Business.Dto.Gift>(gift);
            Type inputType = typeof(Business.Dto.GiftInput);
            System.Reflection.PropertyInfo? propertyInfo = inputType.GetProperty(propName);
            propertyInfo!.SetValue(giftInput, null);
            Uri uri = new Uri($"api/Gift/{gift.Id}", UriKind.RelativeOrAbsolute);

            string jsonData = JsonSerializer.Serialize(giftInput);
            using StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            //Act
            HttpResponseMessage response = await Client.PutAsync(uri, stringContent);

            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }
    }
}
