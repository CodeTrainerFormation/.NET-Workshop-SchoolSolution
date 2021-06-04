using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table("Classrooms")]
    public class Classroom
    {
        // --- Propriétés ---

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassroomId { get; set; }

        [Required]
        [StringLength(30)]
        //[Column("NameOfTheClassroom", TypeName = "nchar(30)")]
        public string Name { get; set; }

        public int Floor { get; set; }

        public string Corridor { get; set; }

        // --- Propriétés de navigation ---

        public virtual ICollection<Student> Students { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
