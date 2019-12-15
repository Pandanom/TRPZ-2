using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ModelsForWpf
{
    [Serializable]
    [DataContract]
    public class Talon
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime One { get; set; }
        [DataMember]
        public DateTime Two { get; set; }
        [DataMember]
        public Car Car { get; set; }
        [DataMember]
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
