using Microsoft.AspNetCore.Mvc;
using MinhaDemoMVC.Models;
using System.Diagnostics;

namespace MinhaDemoMVC.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}
		[Route("")]
		[Route("pagina-inicial/{id:int}/{categoria:alpha?}")]
		public IActionResult Index(string id, string categoria)
		{
			var filme = new Filme()
			{
				Titulo = "ol",
				DataLancamento = DateTime.Now,
				Genero = "",
				Avaliacao = Filme.TipoAvaliacao.ruim,
				Valor = 20000
			};
			//return RedirectToAction("Privacy", filme);
			return View();
		}

		public IActionResult Privacy(Filme filme)
		{
			if (!ModelState.IsValid)
			{
				foreach (var error in ModelState.Values.SelectMany(m => m.Errors))
				{
					Console.WriteLine(error.ErrorMessage);
				}
			}
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}