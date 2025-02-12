using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroUF.Data;
using CadastroUF.Models;
//using CadastroUF.App;
//using System.Web.MVC;
using System.Web;
using System.Threading;
using X.PagedList;


namespace CadastroUF
{
    public class UsuariosController : Controller
    {
        private readonly CadastroUFContext _context;

        public UsuariosController(CadastroUFContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        // Alterei o método abaixo para apresentar a caixa de pesquisa
        // Alterei o método abaixo para apresentar a paginação
        public async Task<IActionResult> Index(string Procura, int? pagina)
        {
            const int itensPorPagina = 8;
            int numeroPagina = (pagina ?? 1);
            var usuario = from m in _context.Usuario
            select m;
           

            if (!String.IsNullOrEmpty(Procura))
            {
                usuario = usuario.Where(s => s.Nome.Contains(Procura));
            }

            return View(await usuario.ToPagedListAsync(numeroPagina, itensPorPagina));
            //return View(await usuario.ToListAsync());

        }


        /*
         Criei o metodo abaixo (GET - DadosUsuario) para acessar a página que trás os dados do 
         usuário cadastrado através do POST Create.
         */
        public async Task<IActionResult> DadosUsuario(int? id)
        {
            var usuario = await _context.Usuario.FirstOrDefaultAsync(m => m.ID == id);
            return View(usuario);
        }


        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.ID == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        /*Criei o metodo abaixo (GET Login) para onde o usuário que se encontra em DadosUsuario
          será direcionado para fazer login
         */
        public IActionResult Login()
        {
            return View();
        }


        //Não consigo utilizar o ModelStateIsvalid no método abaixo porque passei apenas o email e senha do ususario cadastrado
        // Foi enviado através da view login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login( [Bind("Email,Senha")] Usuario usuario)
        {
            var x = _context.Usuario.FirstOrDefault(m => m.Email == usuario.Email);
            if(x == null)
            {
                //LimparFormulario();
                return View("Login");
            }
            else
            {
                if(x.Senha != usuario.Senha)
                {
                    //LimparFormulario();
                    return View("Login");
                }
            }

            if (x.Senha == usuario.Senha & x.Email == usuario.Email)
            {
                Thread.Sleep(4000);
                return RedirectToAction("Index");
            }
            //usuario.LimparFormulario();
            //colocar também uma popup de erro ou sucesso
            
            return View(); 
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // Alterei o Post Create abaixo
        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id,[Bind("ID,Nome,NomeMae,Email,CPF,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                //Adiciona Usuario no banco
                _context.Add(usuario);

                //Salva a alteração no banco
                await _context.SaveChangesAsync();

                //Muda o estado do modelState de valido para nulo
                //ModelState.Clear();

                //Passando valor nulo para a variavel Usuario no comentario abaixo
                //usuario = null;
                if (usuario != null)
                {
                    //A instrução Threas.Sleep do código abaixo foi colocada para que a janela pop up da pagina Create(cadastro de Usuario) tivesse tempo de ser utilizada.
                    Thread.Sleep(1800);
                    //o atributo new { id = usuario.ID} do código abaixo redireciona o usuario atual para a pagina DadosUsuario
                    return RedirectToAction(nameof(DadosUsuario),new { id = usuario.ID});
                }
            }
            return View();
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,NomeMae,Email,CPF,Senha")] Usuario usuario)
        {
            if (id != usuario.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.ID == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.ID == id);
        }

    }
}
