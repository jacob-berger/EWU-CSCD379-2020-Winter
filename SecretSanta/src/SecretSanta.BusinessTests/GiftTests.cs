using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecretSanta.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Business.Tests
{
    [TestClass()]
    public class GiftTests
    {
        [TestMethod()]
        public void NewGift_GoodValues_Success()
        {
            //Arrange
            int id = 10;
            string title = "Title";
            string description = "Description";
            string url = "URL";
            User user = new User(1, "First", "Last", new List<Gift>());

            //Act
            Gift gift = new Gift(id, title, description, url, user);

            //Assert
            Assert.AreEqual(gift.Id, id);
            Assert.AreEqual(gift.Title, title);
            Assert.AreEqual(gift.Description, description);
            Assert.AreEqual(gift.Url, url);
            Assert.IsNotNull(gift.User);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NewGift_NullTitle_ThrowsException()
        {
            //Arrange
            //Act
            Gift gift = new Gift(1, null!, "Description", "URL", new User(2, "First", "Last", new List<Gift>()));
            
            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NewGift_NullDescription_ThrowsException()
        {
            //Arrange
            //Act
            Gift gift = new Gift(1, "Title", null!, "URL", new User(2, "First", "Last", new List<Gift>()));

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NewGift_NullUrl_ThrowsException()
        {
            //Arrange
            //Act
            Gift gift = new Gift(1, "Title", "Description", null!, new User(2, "First", "Last", new List<Gift>()));

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NewGift_NullUser_Success()
        {
            //Arrange
            //Act
            Gift gift = new Gift(1, "Title", "Description", "URL", null!);
        }
    }
}