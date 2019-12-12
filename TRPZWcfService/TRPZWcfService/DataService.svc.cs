using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace TRPZWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DataService.svc or DataService.svc.cs at the Solution Explorer and start debugging.
    public class DataService : IDataService
    {
        const int packageSize = 65536/2;
        static Dictionary<int, FileStream> FS = new Dictionary<int, FileStream>();
        
        public async Task<byte[]> GetFilePart(int FSId)
        {
            if (FS.Keys.Contains(FSId))
            {
                byte[] buff = new byte[packageSize];
                var bytes = await FS[FSId].ReadAsync(buff, 0, packageSize);


               

                if (bytes == packageSize)
                    return buff;
                else
                {
                    FS[FSId].Dispose();
                    FS.Remove(FSId);
                     return buff.Take(bytes).ToArray();
                }

            }
            else
                return null;
        }
     



        public int GetFileFSId(string path)
        {
            string fileName = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", path);
            if (File.Exists(fileName))
            {
                FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                int key =0;
                if (FS.Keys.Count>0)
                     key = FS.Keys.Last()  + 1;
                    FS.Add(key, file);
                    return  key ;
            }
            return - 1;                
        }
    }
}
