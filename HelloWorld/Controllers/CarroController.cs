using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class CarroController : Controller
    {

        private readonly Contexto _contexto;

        public CarroController(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public IActionResult Index()
        {
            return View(_contexto.Carros.ToList());
        }

        [HttpGet]
        public IActionResult NovoCarro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NovoCarro(Carro carro)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(carro);
                _contexto.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(carro);
        }

        [HttpGet]
        public IActionResult AtualizarCarro(int? id)
        {
            if(id == null)
                return NotFound();

            var carro = _contexto.Carros.Find(id);
            return View(carro);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AtualizarCarro(Carro carro)
        {
            if (carro.CarroId == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                _contexto.Update(carro);
                _contexto.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(carro);
        }

        public IActionResult DetalhesCarro(int? id)
        {
            if (id == null)
                return NotFound();

            var carro = _contexto.Carros.FirstOrDefault(x => x.CarroId == id);
            return View(carro);
        }

        [HttpGet]
        public IActionResult ExcluirCarro(int? id)
        {
            if (id == null)
                return NotFound();

            var carro = _contexto.Carros.FirstOrDefault(x => x.CarroId == id);
            return View(carro);
        }

        [HttpPost, ActionName("ExcluirCarro")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarExclusao(int? id)
        {
            if (id == null)
                return NotFound();

            var carro = _contexto.Carros.FirstOrDefault(x => x.CarroId == id);
            _contexto.Remove(carro);
            _contexto.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}