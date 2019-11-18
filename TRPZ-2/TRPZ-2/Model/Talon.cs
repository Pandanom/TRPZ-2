using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TRPZ_2.Model
{
    [Table("Talons")]
    public class Talon
    {
        [Key]
        public int Id { get; set; }
        public DateTime One { get; set; }
        public DateTime Two { get; set; }
        public Car Car { get; set; }
        public Slot Slot { get; set; }

        public Talon()
        {
        }

        public Talon(int id, DateTime one, DateTime two, Car car, Slot slot)
        {
            this.Id = id;
            this.One = one;
            this.Two = two;
            this.Car = car;
            this.Slot = slot;
        }
    }
}
