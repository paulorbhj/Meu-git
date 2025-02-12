using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// O using abaixo é necessário para implementar a anotação [HiddenInput(DisplayValue = false)] e outras
using System.ComponentModel.DataAnnotations;

namespace CadastroUF.Models
{
    public class Usuario
    {
        //O atributo ID ficou incorreto, deveria se chamar NomeID. Porém o visual studio não aceitou por falta da anotação [HiddenInput(DisplayValue = false)]
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string NomeMae { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public long CPF { get; set; }
        //O atributo acima(CPF) deveria ser de outro tipo pois na view create o visual studio acabou por criar uma caixa de incremento que não deveria

        [Required(ErrorMessage ="Campo Obrigatório")]
        public string Senha { get; set; }
    }
}
