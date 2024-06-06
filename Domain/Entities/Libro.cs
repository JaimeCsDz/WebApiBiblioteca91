using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Libro
    {
        [Key]
        public int PkLibro {get; set; }
        public string LibroName { get; set; }
        public string description { get; set; }
        public string editorial {  get; set; }
        [ForeignKey("Autores")]
        public int FkAutor { get; set; }
        public Autor Autores { get; set; }
    }
}
