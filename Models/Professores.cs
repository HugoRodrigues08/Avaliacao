using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace escola.Models
{
    public class Professores
    {
        public int Id { get; set; }
        public string Nome { get; set;}
        public string Sobrenome { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }
        public string Linkedin { get; set; }
       
    }
}
