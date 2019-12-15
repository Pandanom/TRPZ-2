using ModelsForWpf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TRPZ_2.ViewModel.DB.Services
{
    class RESTAPIUserRep
    {
        public enum ActionType
        {
            INSERT, UPDATE, DELETE
        }
        static string url = ConfigurationManager.AppSettings["ServiceAdr"];
        public static async Task<List<User>> GetUsersAsync()
        {

            List<User> users = null;
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = httpClient.GetAsync(url+ "GetItems").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string usersJson = await response.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<List<User>>(usersJson);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return users;
        }

        public static bool ModifyUser(User User, ActionType type)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {                 
                    string UserJson = JsonConvert.SerializeObject(User);
                    StringContent data = new StringContent(UserJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = null;
                    switch (type)
                    {
                        case ActionType.INSERT:
                            response = httpClient.PostAsync(url+"Create", data).Result;
                            break;
                        case ActionType.UPDATE:
                            response = httpClient.PutAsync(url+"Update", data).Result;
                            break;
                        case ActionType.DELETE:
                            UserJson = JsonConvert.SerializeObject(User.Id);
                            data = new StringContent(UserJson, Encoding.UTF8, "application/json");
                            response = httpClient.PutAsync(url+"Delete",data).Result;
                            break;
                    }
                    return response.IsSuccessStatusCode;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return false;
            }
        }


    }
}
