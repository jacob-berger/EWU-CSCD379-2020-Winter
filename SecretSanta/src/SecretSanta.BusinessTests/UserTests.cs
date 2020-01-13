using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Business.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void NewUser_GoodData_Success()
        {
            //Arrange
            int id = 12;
            string first = "Jacob";
            string last = "Berger";
            List<Gift> gifts = new List<Gift>();
            Gift gift = new Gift(12, "Test Gift", "This is a test gift", "http://thisisnotarealwebsite.fake", new User(10, "Mr.", "Tester", new List<Gift>()));
            gifts.Add(gift);

            //Act
            User user = new User(id, first, last, gifts);

            //Assert
            Assert.AreEqual(user.Id, id);
            Assert.AreEqual(user.FirstName, first);
            Assert.AreEqual(user.LastName, last);
            Assert.IsNotNull(user.Gifts);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NewUser_NullFirstName_ThrowsException()
        {
            //Arrange
            //Act
            _ = new User(10, null!, "TestLastName", new List<Gift>());

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NewUser_NullLastName_ThrowsException()
        {
            //Arrange
            //Act
            _ = new User(10, "TestFirstName", null!, new List<Gift>());

            //Assert
        }

        [TestMethod]
        public void NewUser_NullGiftList_Success()
        {
            //Arrange
            //Act
            User user = new User(10, "TestFirstName", "TestLastName", null!);

            //Assert
            Assert.IsNotNull(user.Gifts);
        }

        [TestMethod]
        public void ExistingUser_AddGift_Success()
        {
            //Arrange
            User user = new User(10, "TestFirstName", "TestLastName", new List<Gift>());

            //Act
            user.Gifts.Add(new Gift(11, "OtherFirstName", "OtherLastName", "NotARealURL", new User(12, "First", "Last", new List<Gift>())));

            //Assert
            Assert.AreEqual(user.Gifts.Count, 1);
        }
    }
}