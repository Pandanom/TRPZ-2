using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace ModelsForWpf
{
    
     public   class Converter<T>
        where T : class
    {
        public Converter()
        {
        }

        public byte[] ObjectToByteArray(T obj)
            {
                if (obj == null)
                    return null;

                BinaryFormatter bf = new BinaryFormatter();
                MemoryStream ms = new MemoryStream();
                bf.Serialize(ms, obj);

                return ms.ToArray();
            }

            public T ByteArrayToObject(byte[] arrBytes)
            {
                MemoryStream memStream = new MemoryStream();
                BinaryFormatter binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                T obj = (T)binForm.Deserialize(memStream);

                return obj;
            }
        }
    
}
