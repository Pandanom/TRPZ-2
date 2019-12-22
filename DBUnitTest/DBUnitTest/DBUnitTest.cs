using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBLib;
using DBLib.DBModel;
using System.Collections.Generic;

namespace DBUnitTest
{
    [TestClass]
    public class DBUnitTest
    {
        const string cs = @"Data Source=.\MYSQL;Initial Catalog=TRPZ_2;Integrated Security=True";

        [TestMethod]
        public async Task UserRepCreateTest()
        {
            
            User test = new User(0, "testUser", "TestLogin", 111111, "test", false);
            try
            {
                using (var ur = new UserRep(cs))
                {
                    await ur.Create(test);
                }
            }
            catch (Exception ex)
            {

                Assert.Fail(ex.Message);
            }


        }

        [TestMethod]
        public void GetUserFromDBTest()
        {
            User test = new User(1, "qwq", "qqq", -1337154236, "123", false);
            User u;
            try
            {
                using (var ur = new UserRep(cs))
                    u =  ur.GetItem(1);



                Assert.AreEqual(test.FullName, u.FullName);
                Assert.AreEqual(test.Id, u.Id);
                Assert.AreEqual(test.Password, u.Password);
            }
            catch (Exception ex)
            {

                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public async Task DeleteUserFromDBTest()
        {

            try
            {

                using (var ur = new UserRep(cs))
                    await ur.Delete(5);




            }
            catch (Exception ex)
            {

                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public async Task UpdateUserFromDBTest()
        {

            User test = new User(13, "qwq", "qqq", -1337154236, "123", false);

            try
            {
                using (var ur = new UserRep(cs))
                    await ur.Update(test);

            }
            catch (Exception ex)
            {

                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void GetItemsUserFromDBTest()
        {


            try
            {
                List<User> c;
                using (var ur = new UserRep(cs))
                    c = new List<User>( ur.GetItems());
                Assert.AreEqual(c.Count, 9);
            }
            catch (Exception ex)
            {

                Assert.Fail(ex.Message);
            }
        }
    }
}
