using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ModelsForWpf
{
    [Serializable]
    [DataContract]
    public class User : BDMember
    {
       
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public long Password { get; set; }
        [DataMember]
        public string PhoneNum { get; set; }
        [DataMember]
        public bool IsAdmin { get; set; }
        [DataMember]
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
