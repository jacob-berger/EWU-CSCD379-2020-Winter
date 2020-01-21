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
        public async Task Gift_CanBeCreate_AllPropertiesGetSet()
        {
            // Arrange
            var user = new User
            {
                Id = 0,
                FirstName = "Inigo",
                LastName = "Montoya",
                CreatedBy = "ImMontoya"
            };

            var gift = new Gift
            {
                Id = 0,
                Title = "Ring 2",
                Description = "Amazing way to keep the creepers away",
                Url = "www.ring.com",
                CreatedBy = "ImMontoya"
            };

            // Act

            // Assert
            using (ApplicationDbContext dbContext = new ApplicationDbContext(Options)
            {

            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Gift_SetTitleToNull_ThrowsArgumentNullException()
        {
            Gift gift = new Gift(1, null!, "Amazing way to keep the creepers away", "www.ring.com", new User(1, "Inigo", "Montoya", new List<Gift>()));


        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Gift_SetDescriptionToNull_ThrowsArgumentNullException()
        {
            Gift gift = new Gift(1, "Ring 2", null!, "www.ring.com", new User(1, "Inigo", "Montoya", new List<Gift>()));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Gift_SetUrlToNull_ThrowsArgumentNullException()
        {
            Gift gift = new Gift(1, "Ring 2", "Amazing way to keep the creepers away", null!, new User(1, "Inigo", "Montoya", new List<Gift>()));
        }
    }
}
