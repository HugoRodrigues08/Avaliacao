using System;
using System.ComponentModel.DataAnnotations;

namespace escola.Models
{
    public class ProfessoresCandidatos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set;}

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Linkedin { get; set; }  
    }
}
