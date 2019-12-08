using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocketServer.DB.DBModel
{
    [Table("Slots")]
    public class Slot
    {
        [Key]
        public int Id { get; set; }
        public int XCord { get; set; }
        public int YCord { get; set; }
        public int? Parking_Id { get; set; }
  

        public Slot()
        {
        }

        public Slot(ModelsForWpf.Slot slot)
        {
            Id = slot.Id;
            XCord = slot.XCord;
            YCord = slot.YCord;
            Parking_Id = slot.Parking?.Id ?? 0;
        }

        public Slot(int id, int xCord, int yCord, int parking_Id)
        {
            Id = id;
            XCord = xCord;
            YCord = yCord;
            Parking_Id = parking_Id;
        }
    }
}
