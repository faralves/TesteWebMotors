using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TesteWebMotors.AppService;
using TesteWebMotors.AppService.Messages;
using TesteWebMotors.AppService.ViewModel;
using TesteWebMotors.Model;
using TesteWebMotors.Models;

namespace TesteWebMotors.Controllers
{
    public class HomeController : Controller
    {
        ApplicationTesteWebMotorsService _applicationTesteWebMotorsService;

        public HomeController(ApplicationTesteWebMotorsService applicationTesteWebMotorsService)
        {
            _applicationTesteWebMotorsService = applicationTesteWebMotorsService;
            _applicationTesteWebMotorsService.PopularBanco();
        }
        public IActionResult Index()
        {
            IList<AnuncioView> Anuncios = new List<AnuncioView>();
            Anuncios.Clear();
            BuscarVariosAnuncioResponse responseAll = _applicationTesteWebMotorsService.BuscarTodosAnuncio();
            Anuncios = responseAll.AnunciosView;
            return View(Anuncios);
        }

        public IActionResult Editar(int idAnuncio)
        {
            BuscarAnuncioResponse response = _applicationTesteWebMotorsService.BuscarAnuncio(idAnuncio);
            AnuncioView accView = response.AnuncioView;

            return View(accView);
        }
        
        [HttpPost]
        public IActionResult Editar(AnuncioView anuncioView)
        {
            AtualizarAnuncioRequest atualizarAnuncioRequest = new AtualizarAnuncioRequest();
            atualizarAnuncioRequest.Anuncio = new Anuncio()
            {
                Ano = anuncioView.Ano,
                Id = anuncioView.Id,
                Marca = anuncioView.Marca,
                Modelo = anuncioView.Modelo,
                Observacao = anuncioView.Observacao,
                Quilometragem = anuncioView.Quilometragem,
                Versao = anuncioView.Versao
            };

            AtualizarAnuncioResponse response = _applicationTesteWebMotorsService.AtualizarAnuncio(atualizarAnuncioRequest);
            AnuncioView accView = response.AnuncioView;
            return RedirectToAction("Index");
        }

        public IActionResult Salvar(AtualizarAnuncioRequest atualizarAnuncioRequest)
        {

            AtualizarAnuncioResponse response = _applicationTesteWebMotorsService.AtualizarAnuncio(atualizarAnuncioRequest);
            AnuncioView accView = response.AnuncioView;
            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int idAnuncio)
        {
            BuscarAnuncioResponse response = _applicationTesteWebMotorsService.BuscarAnuncio(idAnuncio);
            AnuncioView accView = response.AnuncioView;

            return View(accView);
        }


        public IActionResult Deletar(int idAnuncio)
        {
            ExcluirAnuncioResponse response = _applicationTesteWebMotorsService.ExcluirAnuncio(idAnuncio);
            AnuncioView accView = response.AnuncioView;

            if(response.Successo)
                ViewData["alertaExcluiu"] = true;

            return RedirectToAction("Index");
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(AnuncioView anuncioView)
        {
            CriarAnuncioRequest criarAnuncioRequest = new CriarAnuncioRequest();
            criarAnuncioRequest.Anuncio = new Anuncio()
            {
                Ano = anuncioView.Ano,
                Id = anuncioView.Id,
                Marca = anuncioView.Marca,
                Modelo = anuncioView.Modelo,
                Observacao = anuncioView.Observacao,
                Quilometragem = anuncioView.Quilometragem,
                Versao = anuncioView.Versao
            };

            CriarAnuncioResponse response = _applicationTesteWebMotorsService.CriarAnuncio(criarAnuncioRequest);
            AnuncioView accView = response.AnuncioView;
            return RedirectToAction("Index");
        }

        public ViewResult Create() => View("Edit", new CriarAnuncioRequest());


        [HttpPost]
        public IActionResult Edit(CriarAnuncioRequest  criarAnuncioRequest)
        {
            if (ModelState.IsValid)
            {
                CriarAnuncioResponse response = _applicationTesteWebMotorsService.CriarAnuncio(criarAnuncioRequest);

                return RedirectToAction("Index");
            }
            else
            {
                return View(criarAnuncioRequest.Anuncio);
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
