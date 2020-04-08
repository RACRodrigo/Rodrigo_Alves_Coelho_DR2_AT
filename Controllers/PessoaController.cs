using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rodrigo_Alves_Coelho_DR2_AT.Models;
using Rodrigo_Alves_Coelho_DR2_AT.Repositories;
using Rodrigo_Alves_Coelho_DR2_AT.Repositories.Implementations;
using Rodrigo_Alves_Coelho_DR2_AT.Services;
using Rodrigo_Alves_Coelho_DR2_AT.Services.Implementations;
using Microsoft.Extensions.Configuration;

namespace Rodrigo_Alves_Coelho_DR2_AT.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(
            IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        // GET: Pessoa
        public ActionResult Index(string filtro = null)
        {
            var pessoas = _pessoaService.GetAll();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                pessoas = pessoas.Where(x => x.Nome.Contains(filtro, StringComparison.OrdinalIgnoreCase));

                ViewBag.Filtro = filtro;
            }

            return View(pessoas);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}