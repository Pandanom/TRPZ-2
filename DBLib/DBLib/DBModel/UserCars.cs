using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace DBLib.DBModel
{
    [Table("UserCars")]
    class UserCars
    {
        public UserCars()
        {
        }

        public UserCars(int id, int owner_Id, int car_Id)
        {
            Id = id;
            Owner_Id = owner_Id;
            Car_Id = car_Id;
        }

        [Key]
        public int Id { get; set; }        
        public int Owner_Id { get; set; }  
        public int Car_Id { get; set; }
    }
}
