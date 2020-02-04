using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SecretSanta.Api.Controllers;
using SecretSanta.Business;
using SecretSanta.Data;
using SecretSanta.Data.Tests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Api.Tests
{
    [TestClass]
    public class GiftControllerTests
    {

        [TestMethod]
        public void CreateController_Success()
        {
            GiftController giftController = new GiftController(new Mock<IGiftService>().Object);
            Assert.IsNotNull(giftController);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateNullController_ThrowsException()
        {
            GiftController giftController = new GiftController(null!);
        }

        [TestMethod]
        public async Task GetListOfEntities_Success()
        {
            var service = new Mock<IGiftService>();
            service.Setup(service => service.FetchAllAsync()).Returns(Task.FromResult(new List<Gift> { SampleData.CreateSwitchGift() }));
            var giftController = new GiftController(service.Object);

            List<Gift> gifts = (List<Gift>)await giftController.Get();

            Assert.IsNotNull(gifts);
            Assert.AreEqual(gifts.Count, 1);
        }

        [TestMethod]
        public async Task GetItem_NotFound()
        {
            var service = new Mock<IGiftService>();
            service.Setup(service => service.FetchByIdAsync(12)).Returns(Task.FromResult<Gift>(null!));
            var giftController = new GiftController(service.Object);

            ActionResult<Gift> result = await giftController.Get(12);

            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetItemWithId_Success()
        {
            var service = new Mock<IGiftService>();
            service.Setup(service => service.FetchByIdAsync(12)).Returns(Task.FromResult(SampleData.CreateN64Gift()));
            var giftController = new GiftController(service.Object);

            ActionResult<Gift> result = await giftController.Get(12);

            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Post_Success()
        {
            var service = new Mock<IGiftService>();
            var gift = SampleData.CreateNew3DsGift();
            Gift giftFromDatabase = new MockGift(12, SampleData.CreateNew3DsGift());
            service.Setup(service => service.InsertAsync(gift)).Returns(Task.FromResult(giftFromDatabase));
            GiftController giftController = new GiftController(service.Object);

            ActionResult<Gift> actionResult = await giftController.Post(gift);
            Gift result = actionResult.Value;

            Assert.IsNotNull(result);
            Assert.AreEqual(gift.Title, result.Title);
        }

        [TestMethod]
        public async Task Put_Success()
        {
            var service = new Mock<IGiftService>();
            Gift gift = SampleData.CreateN64Gift();
            service.Setup(service => service.UpdateAsync(12, gift)).Returns(Task.FromResult<Gift?>(gift));
            var giftController = new GiftController(service.Object);

            ActionResult<Gift> result = await giftController.Put(12, gift);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Delete_Success()
        {
            var service = new Mock<IGiftService>();
            var gift = SampleData.CreateN64Gift();
            service.Setup(service => service.DeleteAsync(12)).Returns(Task.FromResult(true));
            var giftController = new GiftController(service.Object);

            IActionResult result = await giftController.Delete(12);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
        
        private class MockGift : Gift
        {
            public MockGift(int id, Gift gift)
            {
                Id = id;
                Description = gift.Description;
                Title = gift.Title;
                Url = gift.Url;
            }
        }
    }
}
