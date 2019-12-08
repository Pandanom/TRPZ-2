using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsForWpf
{
    [Serializable]
    public class Talon
    {
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
