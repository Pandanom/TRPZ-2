using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsForWpf
{
    [Serializable]
    public class Parking
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
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
