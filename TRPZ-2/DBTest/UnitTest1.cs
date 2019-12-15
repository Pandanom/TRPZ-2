using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelsForWpf;
using TRPZ_2.ViewModel.DB;

namespace DBTest
{
    [TestClass]
    public class UserDBTest
    {
        
        [TestMethod]
        public async Task UserRepCreateTest()
        {
            User test = new User(0, "testUser", "TestLogin", 111111, "test", false, null);
            try
            {
                var ur = new UserRep();
                
                    await ur.Create(test);
                ur.Dispose();

                
            }
            catch(Exception ex)
            {
               
                Assert.Fail(ex.Message);
            }

            
        }

        [TestMethod]
        public async Task GetUserFromDBTest()
        {
            User test = new User(1, "qwq", "qqq", -1337154236, "123", false, new List<Car>());
            User u;
            try
            {
                var ur = new UserRep();

                u =  await ur.GetItem(1);
                   
                ur.Dispose();

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
                var ur = new UserRep();

                 await ur.Delete(2);

                ur.Dispose();

               
            }
            catch (Exception ex)
            {

                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public async Task UpdateUserFromDBTest()
        {

            User test = new User(3, "qwq", "qqq", -1337154236, "123", false, new List<Car>());
            
            try
            {
                var ur = new UserRep();
                 await ur.Update(test);
                ur.Dispose();             
            }
            catch (Exception ex)
            {

                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public async Task GetItemsUserFromDBTest()
        {

          
            try
            {
                var ur = new UserRep();
                var c =new List<User>( await ur.GetItems());
                ur.Dispose();
                Assert.AreEqual(c.Count, 13);
            }
            catch (Exception ex)
            {

                Assert.Fail(ex.Message);
            }
        }

    }
}
