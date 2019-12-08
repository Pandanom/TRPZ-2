using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocketServer.DB.DBModel
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public long Password { get; set; }
        public string PhoneNum { get; set; }
        public bool IsAdmin { get; set; }
      

        public User()
        {
        }
        public User(ModelsForWpf.User user)
        {
            this.Id = user.Id;
            this.FullName = user.FullName;
            this.Login = user.Login;
            this.Password = user.Password;
            this.PhoneNum = user.PhoneNum;
            this.IsAdmin = user.IsAdmin;
    
        }

        public User(int id, string fullName, string login, long password, string phoneNum, bool isAdmin)
        {
            this.Id = id;
            this.FullName = fullName;
            this.Login = login;
            this.Password = password;
            this.PhoneNum = phoneNum;
            this.IsAdmin = isAdmin;
        }
    }
}
