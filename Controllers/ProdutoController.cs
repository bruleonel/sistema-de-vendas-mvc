using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Context;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoContext _context;

        public ProdutoController(ProdutoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var produtos = _context.Produto.ToList();
            return View(produtos);
        }

         [HttpPost]
        public IActionResult CadastrarNovoProduto(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produto.Add(produto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        public IActionResult Editar(int id)
        {
            var produto = _context.Produto.Find(id);

            if (produto == null)
                return RedirectToAction(nameof(Index));

            return View(produto);
        }

        [HttpPost]
        public IActionResult Editar(Produto produto)
        {
            var produtoBanco = _context.Produto.Find(produto.Id);

            produtoBanco.Nome = produto.Nome;
            produtoBanco.Preco = produto.Preco;
            produtoBanco.Quantidade = produto.Quantidade;

            _context.Produto.Update(produtoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int id)
        {
            var produto = _context.Produto.Find(id);

            if (produto  == null)
                return RedirectToAction(nameof(Index));

            return View(produto );
        }

        public IActionResult Deletar(int id)
        {
            var produto = _context.Produto.Find(id);

            if (produto == null)
                return RedirectToAction(nameof(Index));

            return View(produto);
        }

        [HttpPost]
        public IActionResult Deletar(Produto produto)
        {
            var produtoBanco = _context.Produto.Find(produto.Id);

            _context.Produto.Remove(produtoBanco);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}