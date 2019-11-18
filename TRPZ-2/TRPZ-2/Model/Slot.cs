using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TRPZ_2.Model
{
    [Table("Slots")]
    public class Slot
    {
        [Key]
       public  int Id { get; set; }
        public List<Talon> Talons { get; set; }
        public int XCord { get;  set; }
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
