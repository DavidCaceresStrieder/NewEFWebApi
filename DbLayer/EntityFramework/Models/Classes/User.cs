using ModelsLayer.EntityFramework;
using ModelsLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelsLayer
{
    [Table("Users")]
    public class User 
    {
        [Key]        
        [Column("UserID")]        
        public int UserID { get; set; }

        [Column("UserName")]
        public string UserName { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("RealName")]
        public string RealName { get; set; }

        [Column("RealLastName")]
        public string RealLastName { get; set; }

        [Column("BirthDate")]
        public DateTime BirthDate { get; set; }
       
        
    }
}
