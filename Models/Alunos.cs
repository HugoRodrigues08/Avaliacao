using System;
using System.ComponentModel.DataAnnotations;

namespace escola.Models
{
    public class Alunos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get;set; }

        [DataType(DataType.Date)]
        public DateTime DataCadatro { get; set; }
        public string Turma { get; set; }

    }
}
