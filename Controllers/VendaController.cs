using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Context;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Controllers
{
    public class VendaController : Controller
    {
        private readonly VendaContext _context;

        public VendaController(VendaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var vendas = _context.Venda.ToList();
            return View(vendas);
        }

         [HttpPost]
        public IActionResult NovaVenda(Venda venda)
        {
            if (ModelState.IsValid)
            {
                _context.Venda.Add(venda);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(venda);
        }

        public IActionResult Editar(int id)
        {
            var venda = _context.Venda.Find(id);

            if (venda == null)
                return RedirectToAction(nameof(Index));

            return View(venda);
        }

        [HttpPost]
        public IActionResult Editar(Venda venda)
        {
            var vendaBanco = _context.Venda.Find(venda.Id);

            vendaBanco.Produto = venda.Produto;
            vendaBanco.Vendedor = venda.Vendedor;
            vendaBanco.Data = venda.Data;
            vendaBanco.Status = venda.Status;

            _context.Venda.Update(vendaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var venda = _context.Venda.Find(id);

            if (venda == null)
                return RedirectToAction(nameof(Index));

            return View(venda);
        }

        public IActionResult Deletar(int id)
        {
            var venda = _context.Venda.Find(id);

            if (venda== null)
                return RedirectToAction(nameof(Index));

            return View(venda);
        }

        [HttpPost]
        public IActionResult Deletar(Venda venda)
        {
            var vendaBanco = _context.Venda.Find(venda.Id);

            _context.Venda.Remove(vendaBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}