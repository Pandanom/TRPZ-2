using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsForWpf
{
    [Serializable]
    public class User
    {
        
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public long Password { get; set; }
        public string PhoneNum { get; set; }
        public bool IsAdmin { get; set; }
        public List<Car> Cars { get; set; }

        public User()
        {
        }

        public User(int id, string fullName, string login, long password, string phoneNum, bool isAdmin, List<Car> cars)
        {
            this.Id = id;
            this.FullName = fullName;
            this.Login = login;
            this.Password = password;
            this.PhoneNum = phoneNum;
            this.IsAdmin = isAdmin;
            this.Cars = cars;
        }
    }
}
