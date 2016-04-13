using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirVinyl.Model
{
    public class RecordStore
    {
        [Key]
        public int RecordStoreId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public Address StoreAddress { get; set; }

        public ICollection<string> Tags { get; set; }
       
        public ICollection<Rating> Ratings { get; set; }

        public RecordStore()
        {
            StoreAddress = new Address();
            Ratings = new List<Rating>();
            Tags = new List<string>();
        }
    }
}
