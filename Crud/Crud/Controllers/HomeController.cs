using Crud.Dal;
using System;
using System.Linq;
using System.Web.Mvc;
using Crud.Models;
using Crud.Repositories;

namespace Crud.Controllers
{
    public class HomeController : Controller
    {
        private ProdutoRepository _produtoRepository;

        public HomeController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        public ActionResult Index()
        {
            return View(_produtoRepository.GetProdutos());
        }

        [HttpPost]
        public ActionResult Search(string searchString)
        {
            return Json(_produtoRepository.GetProdutos(searchString));      
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _produtoRepository.RemoveProdutoById(id);
            return Json(_produtoRepository.GetProdutos());      
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = _produtoRepository.GetBaseViewModel();
            viewModel.Produto = new Produto();
            viewModel.Tela = TiposTela.Create;

            return View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            _produtoRepository.SaveProduto(produtoViewModel.Produto);
            return RedirectToAction("Index", "Home");
        }

        
        [HttpPost]
        public ActionResult AddEmbalagem(ProdutoViewModel produtoViewModel, Embalagem embalagem)
        {
            produtoViewModel.Produto.Embalagens.ToList().Add(embalagem);
            return View("Edit", produtoViewModel);
        }

        [HttpPost]
        public ActionResult RemoveEmbalagem(ProdutoViewModel produtoViewModel, int embalagemId)
        {
            var embalagem = produtoViewModel.Produto.Embalagens.ToList().Where(e => e.ID == embalagemId).First();
            produtoViewModel.Produto.Embalagens.ToList().Remove(embalagem);
            return View("Edit", produtoViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = _produtoRepository.GetBaseViewModel();
            viewModel.Produto = _produtoRepository.GetProdutoById(id);
            viewModel.Tela = TiposTela.Edit;

            return View(viewModel);
        }

        public string EmailRandomizer() 
        { 
            const string chars = "abcdefghijklmnopqrstuvwyxz0123456789";
            var random = new Random();
            string mail = new string(Enumerable.Repeat(chars, random.Next(5, 10)).Select(s => s[random.Next(s.Length)]).ToArray());

            return mail + "@gmail.com";
        }
    }
}