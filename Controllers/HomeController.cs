using CadastroUF.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CadastroUF.Controllers
{
    //Alterei um método abaixo
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Se der erro, o codigo abaixo esta no bloco de notas "buscaApi"
        public async Task<IActionResult> Index()
        {
            List<Curso> cursos = new List<Curso>();
            try
            {
                using (var cliente = new HttpClient())
                {
                    using (var response = await cliente.GetAsync("https://localhost:44388/api/Curso"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        cursos = JsonConvert.DeserializeObject<List<Curso>>(apiResponse);
                    }
                    return View(cursos);
                }
            }
            catch
            {
                //precisa colocar alguma coisa aqui para diminuir o tempo de cargada da pagina inicial(5 minutos)
                //Acredito que colocando um valor na lista seria o suficiente, A lista no inicio está vazia
                //cursos = new List<Curso>();
                return View(cursos);
            }
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
