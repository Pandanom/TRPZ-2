using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ModelsForWpf
{
    [Serializable]
    [DataContract]
    public class Slot : BDMember
    {
        
        [DataMember]
        public List<Talon> Talons { get; set; }
        [DataMember]
        public int XCord { get; set; }
        [DataMember]
        public int YCord { get; set; }
        [DataMember]
        public Parking Parking { get; set; }

        public Slot()
        {
        }

        public Slot(int id, List<Talon> talons, int xCord, int yCord, Parking parking)
        {
            Id = id;
            Talons = talons;
            XCord = xCord;
            YCord = yCord;
            Parking = parking;
            
        }
    }
}
