using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocketServer.DB.DBModel
{
    [Table("Parkings")]
    public class Parking
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
      

        public Parking()
        {
        }
        public Parking(ModelsForWpf.Parking parking)
        {
            this.Id = parking.Id;
            this.Name = parking.Name;
            this.Adress = parking.Adress;
        }
        public Parking(int id, string name, string adress)
        {
            this.Id = id;
            this.Name = name;
            this.Adress = adress;
            
        }
    }
}
