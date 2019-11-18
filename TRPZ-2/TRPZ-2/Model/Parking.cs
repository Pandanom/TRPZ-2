using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TRPZ_2.Model
{
    [Table("Parkings")]
    public class Parking
    {
        [Key]
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
