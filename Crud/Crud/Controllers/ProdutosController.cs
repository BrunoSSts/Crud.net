using Crud.Models;
using Crud.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class ProdutosController : Controller
    {
        private ProdutoRepository _produtoRepository;


        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }


    }
}