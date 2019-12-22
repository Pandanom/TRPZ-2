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
                using (var ur = new GenericRep<User>())
                {
                    await ur.Create(test);
                }      
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
                using (var ur = new GenericRep<User>())
                    u =  await ur.GetItem(1);
                   
               

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
              
                using (var ur = new GenericRep<User>())
                    await ur.Delete(2);

    

               
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
                using (var ur = new GenericRep<User>())
                    await ur.Update(test);
                    
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
                List<User> c;
                using (var ur = new GenericRep<User>())
                     c =new List<User>( await ur.GetItems());
                Assert.AreEqual(c.Count, 9);
            }
            catch (Exception ex)
            {

                Assert.Fail(ex.Message);
            }
        }

    }
}
