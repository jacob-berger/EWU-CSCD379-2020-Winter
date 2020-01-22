using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretSanta.Data.Tests
{
    [TestClass]
    public class GiftTests : TestBase
    {
        [TestMethod]
        public async Task Gift_CreatedForeignRelation_Sucess()
        {
            //Arrange
            var gift = new Gift
            {
                Title = "Title",
                Description = "Description",
                Url = "Url"
            };

            var user = new User
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Santa = null,
                Gifts = new List<Gift>(),
                Links = new List<Link>()
            };

            //Act
            gift.User = user;
            using (ApplicationDbContext dbContext = new ApplicationDbContext(Options))
            {
                dbContext.Add(gift);
                await dbContext.SaveChangesAsync();
            }

            //Assert
            using (ApplicationDbContext dbContext = new ApplicationDbContext(Options))
            {
                var gifts = await dbContext.Gifts.Include(g => g.User).ToListAsync();
                Assert.AreEqual(1, gifts.Count);
                Assert.AreEqual(gift.Title, gifts[0].Title);
                Assert.AreNotEqual(0, gifts[0].Id);
            }
        }
    }
}