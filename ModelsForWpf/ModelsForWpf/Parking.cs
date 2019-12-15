using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ModelsForWpf
{
    [Serializable]
    [DataContract]
    public class Parking:BDMember
    {
       
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Adress { get; set; }
        [DataMember]
        public List<Slot> Slots { get; set; }

        public Parking()
        {
        }

        public Parking(int id, string name, string adress, List<Slot> slots)
        {
            this.Id = id;
            this.Name = name;
            this.Adress = adress;
            this.Slots = slots;
        }
    }
}
