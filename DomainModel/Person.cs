using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public abstract class Person
    {
        public int PersonId { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Range(0, 120)]
        public int Age { get; set; }

        //[Timestamp]
        //public byte[] ModifiedDate { get; set; }
    }
}
