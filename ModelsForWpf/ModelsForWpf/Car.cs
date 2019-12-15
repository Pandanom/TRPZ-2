using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ModelsForWpf
{
    [Serializable]
    [DataContract]
    public class Car: BDMember
    {
        
        [DataMember]
        public string RegNum { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public string Info { get; set; }
        [DataMember]
        public User Owner { get; set; }
        [DataMember]
        public List<Talon> UserTalons { get; set; }


        public Car()
        {
        }

        public Car(int id, string regNum, string color, string info, User owner, List<Talon> userTalons)
        {
            this.Id = id;
            this.RegNum = regNum;
            this.Color = color;
            this.Info = info;
            this.Owner = owner;
            this.UserTalons = userTalons;
        }
    }
}
