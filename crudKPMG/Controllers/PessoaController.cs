using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crudKPMG.Models;

namespace crudKPMG.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Contato
        public ActionResult Index()
        {
            using (PessoaModel model = new PessoaModel())
            {
                List<Pessoa> lista = model.Read();
                return View(lista);
            }
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            Pessoa Pessoa = new Pessoa();
            Pessoa.Nome         = form["Nome"];
            Pessoa.Email        = form["Email"];
            Pessoa.DDD          = Int32.Parse(form["DDD"]);
            Pessoa.Telefone     = Int32.Parse(form["Telefone"]);
            Pessoa.Endereco     = form["Endereco"];
            Pessoa.Num_endereco = Int32.Parse(form["Num_endereco"]);

            using (PessoaModel model = new PessoaModel())
            {
                model.Create(Pessoa);
                return RedirectToAction("Index");
            }
        }
    }
}