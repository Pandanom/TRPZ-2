using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsForWpf;
using TRPZ_2.ViewModel.DB;


namespace TRPZ_2.ViewModel
{
    class AccountManager
    {

        public async Task RegistrateUser(User u)
        {
           
            UserRep ur = new UserRep();
            await ur.Create(u);
         
            
        }

        public async Task<bool> Validate(string login,string pass1,string pass2, string number,string name)
        {
            if(pass1 == pass2 && login !="" && name!="" && pass1!=" " && pass1 != "")
            {
                await RegistrateUser( new User(0, name, login, pass1.GetHashCode(), number, false, null));
                return true;
            }

            return false;

        }
        public async Task<bool> LogIn(string login,string password)
        {
            UserRep ur = new UserRep();
            List<User> users = (await ur.GetItems()).ToList();
            foreach (var u in users)
            {
                if (u.Login.Trim() == login && u.Password == password.GetHashCode())
                {
                    StaticData.CurUser = u;
                    Serv.StartUp.Start();
                    //StaticData.bc = Task.Run(async ()=> { await Serv.StartUp.ListenBroadcast(); });
                    Serv.StartUp.ListenBroadcast();
                    return true;
                }
            }
            return false;
        }
    }
}
