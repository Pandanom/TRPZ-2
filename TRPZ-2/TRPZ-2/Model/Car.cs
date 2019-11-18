using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TRPZ_2.Model
{
    [Table("Cars")]
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string RegNum { get; set; }
        public string Color { get; set; }
        public string Info { get; set; }
        [ForeignKey("Owner")]
        public int Owner_Id { get; set; }
        public User Owner { get; set; }

        public List<Talon> UserTalons { get; set; }
        
        
        public Car()
        {
        }

        public Car(int id, string regNum, string color, string info, User owner, List<Talon> userTalons)
        {
            this.Id = id;
            this.RegNum = regNum;
            this.Color = color;
            this.Info = info;
            this.Owner = owner;
            this.UserTalons = userTalons;
        }
    }
}
