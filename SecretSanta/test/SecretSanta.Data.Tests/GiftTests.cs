using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecretSanta.Data.Tests
{
    [TestClass]
    public class GiftTests : TestBase
    {
        [TestMethod]
        public async Task Gift_CanBeSavedToDatabase()
        {
            // Arrange
            using (var dbContext = new ApplicationDbContext(Options))
            {
                dbContext.Gifts.Add(SampleData.CreateXbox());
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            // Act
            // Assert
            using (var dbContext = new ApplicationDbContext(Options))
            {
                var gifts = await dbContext.Gifts.ToListAsync();

                Assert.AreEqual(1, gifts.Count);
                Assert.AreEqual(SampleData.Xbox, gifts[0].Title);
                Assert.AreEqual(SampleData.XboxUrl, gifts[0].Url);
                Assert.AreEqual(SampleData.XboxDescription, gifts[0].Description);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Gift_SetTitleToNull_ThrowsArgumentNullException()
        {
            _ = new Gift(null!, SampleData.XboxUrl, SampleData.XboxDescription, SampleData.CreateRobert());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Gift_SetDescriptionToNull_ThrowsArgumentNullException()
        {
            _ = new Gift(SampleData.Xbox, SampleData.XboxUrl, null!, SampleData.CreateRobert());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Gift_SetUrlToNull_ThrowsArgumentNullException()
        {
            _ = new Gift(SampleData.Xbox, null!, SampleData.XboxDescription, SampleData.CreateRobert());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Gift_NullUser_ThrowsException()
        {
            _ = new Gift(SampleData.Xbox, SampleData.XboxUrl, SampleData.XboxDescription, null!);
        }

        [TestMethod]
        public async Task Gift_UpdateData_Success()
        {
            //Arrange
            await using (ApplicationDbContext context = new ApplicationDbContext(Options))
            {
                context.Add(SampleData.CreateGameboy());
                await context.SaveChangesAsync().ConfigureAwait(false);

                context.Dispose();
            }

           //Act
           await using (ApplicationDbContext context = new ApplicationDbContext(Options))
            {
                var gift = await context.Gifts.Include(g => g.User).SingleOrDefaultAsync();

                Assert.AreEqual(SampleData.Gameboy, gift.Title);
                Assert.AreEqual(SampleData.GameboyDescription, gift.Description);
                Assert.AreEqual(SampleData.GameboyUrl, gift.Url);

                gift.Title = "New title";
                gift.Description = "New description";
                gift.Url = "New url";
                await context.SaveChangesAsync().ConfigureAwait(false);
                context.Dispose();
            }

            await using (ApplicationDbContext context = new ApplicationDbContext(Options))
            {
                var gift = await context.Gifts.Include(g => g.User).SingleOrDefaultAsync();

                Assert.AreEqual("New title", gift.Title);
                Assert.AreEqual("New description", gift.Description);
                Assert.AreEqual("New url", gift.Url);

                context.Dispose();
            }
        }

        [TestMethod]
        public async Task Gift_DeleteGift_Success()
        {
            await using (ApplicationDbContext context = new ApplicationDbContext(Options))
            {
                context.Add(SampleData.CreateXbox());
                await context.SaveChangesAsync().ConfigureAwait(false);

                List<Gift> gifts = await context.Gifts.ToListAsync();
                Assert.AreEqual(gifts.Count, 1);

                context.Dispose();
            }

            await using (ApplicationDbContext context = new ApplicationDbContext(Options))
            {
                var gift = await context.Gifts.SingleOrDefaultAsync();
                context.Gifts.Remove(gift);
                await context.SaveChangesAsync().ConfigureAwait(false);

                List<Gift> gifts = await context.Gifts.ToListAsync();
                Assert.AreEqual(gifts.Count, 0);

                context.Dispose();
            }
        }

        [TestMethod]
        public async Task Gift_Create_Success()
        {
            await using (ApplicationDbContext context = new ApplicationDbContext(Options))
            {
                context.Add(SampleData.CreateGameboy());
                await context.SaveChangesAsync().ConfigureAwait(false);

                List<Gift> gifts = await context.Gifts.ToListAsync();
                Assert.AreEqual(gifts.Count, 1);

                context.Dispose();
            }
        }
    }
}
