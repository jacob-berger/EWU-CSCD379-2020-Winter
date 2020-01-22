using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Data.Tests
{
    [TestClass]
    public class UserTests : TestBase
    {
        [TestMethod]
        public async Task User_CanBeCreate_AllPropertiesGetSet()
        {
            // Arrange
            using (var applicationDbContext = new ApplicationDbContext(Options))
            {
                User user = new User
                {
                    FirstName = "Inigo",
                    LastName = "Montoya",
                    Santa = null,
                    Gifts = new List<Gift>(),
                    Links = new List<Link>(),
                    Id = 1
                };

                User anotherUser = new User
                {
                    FirstName = "Master",
                    LastName = "Splinter",
                    Santa = null,
                    Gifts = new List<Gift>(),
                    Links = new List<Link>(),
                    Id = 2
                };

                applicationDbContext.Users.Add(user);
                applicationDbContext.Users.Add(anotherUser);
            }

            

            // Act
            // Assert
            using (var applicationContext = new ApplicationDbContext(Options))
            {
                var user = await applicationContext.Users.Where(u => u.Id == 1).SingleOrDefaultAsync();
                var anotherUser = await applicationContext.Users.Where(u => u.Id == 2).SingleOrDefaultAsync();

                Assert.IsNotNull(user);
                Assert.IsNotNull(anotherUser);
                Assert.AreEqual("Inigo", user.FirstName);
                Assert.AreEqual("Master", anotherUser.FirstName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void User_SetFirstNameToNull_ThrowsArgumentNullException()
        {
            User user = new User
            {
                FirstName = null!,
                LastName = "Montoya",
                Santa = null,
                Gifts = new List<Gift>(),
                Links = new List<Link>(),
                Id = 3
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void User_SetLastNameToNull_ThrowsArgumentNullException()
        {
            User user = new User
            {
                FirstName = "FirstName",
                LastName = null!,
                Santa = null,
                Gifts = new List<Gift>(),
                Links = new List<Link>(),
                Id = 4
            };
        }
    }
}
