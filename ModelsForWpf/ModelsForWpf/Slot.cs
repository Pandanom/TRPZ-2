using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsForWpf
{
    [Serializable]
    public class Slot
    {
       
        public int Id { get; set; }
        public List<Talon> Talons { get; set; }
        public int XCord { get; set; }
        public int YCord { get; set; }
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
