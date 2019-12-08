using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocketServer.DB.DBModel
{
   
    [Table("Cars")]
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string RegNum { get; set; }
        public string Color { get; set; }
        public string Info { get; set; }
       
        
        public Car()
        {
        }

        public Car(ModelsForWpf.Car car)
        {
            this.Id = car.Id;
            this.RegNum = car.RegNum;
            this.Color = car.Color;
            this.Info = car.Info;
            
        }

        public Car(int id, string regNum, string color, string info)
        {
            Id = id;
            RegNum = regNum;
            Color = color;
            Info = info;
           
        }
    }
    
}
