using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBLib.DBModel
{
    [Table("Talons")]
    public class Talon
    {
        [Key]
        public int Id { get; set; }
        public DateTime One { get; set; }
        public DateTime Two { get; set; }
        public int? Car_Id { get; set; }
        public int? Slot_Id { get; set; }
        public Talon()
        {
        }
        public Talon(ModelsForWpf.Talon talon)
        {
            this.Id = talon.Id;
            this.One = talon.One;
            this.Two = talon.Two;
            this.Car_Id = talon.Car.Id;
            this.Slot_Id = talon.Slot.Id;
        }

        public Talon(int id, DateTime one, DateTime two, int car_Id, int slot_Id)
        {
            Id = id;
            One = one;
            Two = two;
            Car_Id = car_Id;
            Slot_Id = slot_Id;
        }
    }
}
