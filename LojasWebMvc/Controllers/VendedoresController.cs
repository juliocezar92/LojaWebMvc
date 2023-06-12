using LojasWebMvc.Models;
using LojasWebMvc.Models.ViewModels;
using LojasWebMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace LojasWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedorService;
        private readonly DepartamentoService _departamentoService;
        public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService)
        {
            _vendedorService = vendedorService;
            _departamentoService = departamentoService;
        }

        public IActionResult Index()
        {
            var list = _vendedorService.FindAll();
            return View(list);
        }
        public IActionResult Create() 
        {
            var Departamentos = _departamentoService.FindAll();
            var viewModel = new VendedorFormViewModel { Departamentos = Departamentos };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor) 
        {
            _vendedorService.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }
    }
}
