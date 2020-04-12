using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class BlabAdapter_MySql_UnitTests
    {
        private BlabAdapter _harness = new BlabAdapter(new MySqlBlab());

        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestAddAndGetBlab()
        {
            //Arrange
            string email = "myfooabar1@example.com";
            User mockUser = new User(email);
            Blab blab = new Blab("Now is the time for, blabs...", mockUser);
            //Act
            _harness.Add(blab);
            ArrayList actual = (ArrayList)_harness.GetByUserId(email);
            //Assert
            Assert.AreEqual(1, actual.Count);
        }

        [TestMethod]
        public void TestAddAndGet2Blabs()
        {
            string email ="testing2@email.com";
            User testUser = new User(email);
            Blab blab = new Blab("Here is some dummy text", testUser);
            _harness.Add(blab);
            Blab blab2 = new Blab("Message number two", testUser);
            _harness.Add(blab2);
            ArrayList actual = (ArrayList)_harness.GetByUserId(email);
            Assert.AreEqual(2, actual.Count);
        }

        // [TestMethod]
        // public void TestDeleteBlab()
        // {
        //     string email ="delete@email.com";
        //     User testUser = new User(email);
        //     Blab blab = new Blab("delete", testUser);
        //     _harness.Add(blab);
        //     _harness.Remove(blab);
        //     ArrayList actual = (ArrayList)_harness.GetByUserId(email);
        //     Assert.AreEqual(0, actual.Count);
        // }
    }
}