using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroUF.Models;

// Essa classe é utilizada para conexão com banco de dados
namespace CadastroUF.Data
{
    public class CadastroUFContext : DbContext
    {
        public CadastroUFContext (DbContextOptions<CadastroUFContext> options)
            : base(options)
        {
        }

        public DbSet<CadastroUF.Models.Usuario> Usuario { get; set; }
    }

    //O metodo abaixo é utilizado para eliminar o problema de pluralização das tabelas no banco. Nesta aplicação, não foi utilizado por força do acaso

    /*
    protected override void OnModelCreating(DbModelBuilder dbmodelBuilder)
    {
        dbmodelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
    
     */
}
