using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUF.Models
{
    public class Curso
    {
        [Key]
        public int IdCurso { get; set; }
        public string Nome { get; set; }
        public string Disciplina { get; set; }

    }
}
