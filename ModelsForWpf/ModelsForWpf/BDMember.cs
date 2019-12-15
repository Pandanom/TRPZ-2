using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ModelsForWpf
{
    [Serializable]
    [DataContract]
    public class BDMember
    {
        public BDMember()
        {

        }

        public BDMember(int id)
        {
            Id = id;
        }

        [DataMember]
        public int Id { get; set; }
    }
}
