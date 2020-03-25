using System;
using System.Collections.Generic;
using System.Net.Http;
using TesteWebMotors.Model.Contract;

namespace TesteWebMotors.Model
{
    public class ServicoAnuncio
    {
        private ITesteWebMotorsRepository _repositorio;
        private static HttpClient client = null;

        public  ServicoAnuncio()
        {
            PopularBanco();
        }

        public ServicoAnuncio(ITesteWebMotorsRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public bool Cadastrar(Anuncio anuncio)
        {
            if (anuncio != null)
                return _repositorio.Add(anuncio);
            else
                return false;
        }
        public bool Atualizar(Anuncio anuncio)
        {
            return _repositorio.Save(anuncio); 
        }
        public bool Excluir(int idAnuncio)
        {
            return _repositorio.ExcluirAnuncio(idAnuncio); 
        }

        public Anuncio ConsultarUnico(Anuncio anuncio)
        {
            return _repositorio.PesquisarAnuncio(anuncio);
        }

        public IList<Anuncio> ConsultarTodos()
        {
            return _repositorio.PesquisarTodosAnuncios();
        }
        public IList<Anuncio> ConsultarComFiltro(Anuncio anuncio)
        {
            if (anuncio?.Marca != null && anuncio?.Ano == null && anuncio?.Modelo == null && anuncio?.Quilometragem == null && anuncio?.Versao == null)
                return _repositorio.PesquisarTodosAnunciosComFiltroMarca(anuncio);
            else if (anuncio?.Modelo != null && anuncio?.Marca == null && anuncio?.Ano == null && anuncio?.Quilometragem == null && anuncio?.Versao == null)
                    return _repositorio.PesquisarTodosAnunciosComFiltroModelo(anuncio);
            else if (anuncio?.Ano != null && anuncio?.Marca == null && anuncio?.Modelo == null && anuncio?.Quilometragem == null && anuncio?.Versao == null)
                    return _repositorio.PesquisarTodosAnunciosComFiltroAno(anuncio);
            else if (anuncio?.Quilometragem != null && anuncio?.Ano == null && anuncio?.Marca == null && anuncio?.Modelo == null && anuncio?.Versao == null)
                    return _repositorio.PesquisarTodosAnunciosComFiltroKM(anuncio);
            else if (anuncio?.Marca != null && anuncio?.Modelo != null && anuncio?.Versao != null && anuncio?.Quilometragem == null && anuncio?.Ano == null)
                    return _repositorio.PesquisarTodosAnunciosComFiltroVersao(anuncio);
            else if (anuncio?.Marca != null && anuncio?.Modelo != null && anuncio?.Versao != null && anuncio?.Ano != null && anuncio?.Quilometragem == null )
                    return _repositorio.PesquisarTodosAnunciosComFiltroVersaoAno(anuncio);
            else if (anuncio?.Marca != null && anuncio?.Modelo != null && anuncio?.Versao == null && anuncio?.Ano == null && anuncio?.Quilometragem == null)
                    return _repositorio.PesquisarTodosAnunciosComFiltroMarcaModelo(anuncio);
            else if (anuncio?.Marca != null && anuncio?.Modelo != null && anuncio?.Ano != null && anuncio?.Versao == null && anuncio?.Quilometragem == null)
                    return _repositorio.PesquisarTodosAnunciosComFiltroMarcaModeloAno(anuncio);
            else if (anuncio?.Marca != null && anuncio?.Modelo != null && anuncio?.Ano != null && anuncio?.Quilometragem != null && anuncio?.Versao == null )
                    return _repositorio.PesquisarTodosAnunciosComFiltroMarcaModeloKM(anuncio);
            else if (anuncio?.Marca != null && anuncio?.Quilometragem != null && anuncio?.Modelo == null && anuncio?.Ano == null  && anuncio?.Versao == null)
                    return _repositorio.PesquisarTodosAnunciosComFiltroMarcaKM(anuncio);
            else if (anuncio?.Marca != null && anuncio?.Modelo != null && anuncio?.Quilometragem != null && anuncio?.Ano == null && anuncio?.Versao == null)
                    return _repositorio.PesquisarTodosAnunciosComFiltroModeloKM(anuncio);
            else
                return _repositorio.PesquisarTodosAnunciosComTodosFiltros(anuncio);
        }

        public IList<Anuncio> PopularBanco()
        {
            IList<Anuncio> anuncios = new List<Anuncio>();
            anuncios = _repositorio.PesquisarTodosAnuncios();

            if (anuncios == null || anuncios?.Count <= 0)
            {
                if (client == null)
                {
                    client = new HttpClient();
                    client.BaseAddress = new Uri("http://desafioonline.webmotors.com.br");
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                }

                System.Net.Http.HttpResponseMessage response = client.GetAsync("api/OnlineChallenge/Make").Result;

                if (response.IsSuccessStatusCode)
                {
                    IEnumerable<Marca> retornoMarca = response.Content.ReadAsAsync<IEnumerable<Marca>>().Result;
                    foreach (Marca marca in retornoMarca)
                    {
                        _repositorio.AtualizarOuCriarMarca(marca);

                        ObterModelosApi(marca);
                    }
                }
                Anuncio anuncio = null;

                IList<Marca> marcas = new List<Marca>();
                marcas = _repositorio.PesquisarTodasMarcas();
                IList<Modelo> modelos = new List<Modelo>();
                modelos = _repositorio.PesquisarTodosModelos();
                IList<Versao> versoes = new List<Versao>();
                versoes = _repositorio.PesquisarTodasVersoes();
                IList<Veiculo> veiculos = new List<Veiculo>();
                veiculos = _repositorio.PesquisarTodosVeiculos();

                foreach (Veiculo veiculo in veiculos)
                {
                    anuncio = new Anuncio()
                    {
                        Ano = veiculo.YearModel,
                        Marca = veiculo.Make,
                        Modelo = veiculo.Model,
                        Quilometragem = veiculo.KM,
                        Versao = veiculo.Version
                    };
                    Anuncio anuncioContext = _repositorio.PesquisarAnuncio(anuncio);
                    if (anuncioContext == null)
                        _repositorio.Add(anuncio);
                }

                IList<Anuncio> validarAnuncios = _repositorio.PesquisarAnuncioTabelasRelacionais();
                foreach (Anuncio validarAnuncio in validarAnuncios)
                {
                    Anuncio anuncioContext = _repositorio.PesquisarAnuncio(validarAnuncio);
                    if (anuncioContext == null)
                        _repositorio.Add(validarAnuncio);
                }

                anuncios = _repositorio.PesquisarTodosAnuncios();

            }


            return anuncios;
        }

        private void ObterModelosApi(Marca marca)
        {
            HttpResponseMessage response = client.GetAsync("api/OnlineChallenge/Model?MakeID=" + marca.Id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Modelo> retornoModelo = response.Content.ReadAsAsync<IEnumerable<Modelo>>().Result;

                foreach (Modelo modelo in retornoModelo)
                {
                    _repositorio.AtualizarOuCriarModelo(modelo);

                    ObterVersoesApi(modelo);
                }
            }
        }
        private void ObterVersoesApi(Modelo modelo)
        {
            HttpResponseMessage response = client.GetAsync("api/OnlineChallenge/Version?ModelID=" + modelo.Id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Versao> retornoVersao = response.Content.ReadAsAsync<IEnumerable<Versao>>().Result;
                foreach (Versao versao in retornoVersao)
                {

                    _repositorio.AtualizarOuCriarVersao(versao);
                    ObterVeiculosApi(modelo);
                }
            }
        }
        private  void ObterVeiculosApi(Modelo modelo)
        {
            HttpResponseMessage response = client.GetAsync("api/OnlineChallenge/Vehicles?Page=" + modelo.Id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Veiculo> retornoVeiculo = response.Content.ReadAsAsync<IEnumerable<Veiculo>>().Result;
                foreach (Veiculo veiculo in retornoVeiculo)
                {
                    _repositorio.AtualizarOuCriarVeiculo(veiculo);
                }
            }
        }
    }
}
