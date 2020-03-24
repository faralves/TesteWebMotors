using AutoMapper;
using System.Collections.Generic;
using TesteWebMotors.AppService.Messages;
using TesteWebMotors.AppService.ViewModel;
using TesteWebMotors.Model;
using TesteWebMotors.Model.Contract;

namespace TesteWebMotors.AppService
{
    public class ApplicationTesteWebMotorsService
    {
        private ServicoAnuncio _servicoAnuncio;
        private ITesteWebMotorsRepository _repositorio;
        private readonly IMapper _mapper;
        public ApplicationTesteWebMotorsService(ITesteWebMotorsRepository repositorio, ServicoAnuncio servicoAnuncio, IMapper mapper)
        {
            _repositorio = repositorio;
            _servicoAnuncio = servicoAnuncio;
            _mapper = mapper;
        }
        public CriarAnuncioResponse CriarAnuncio(CriarAnuncioRequest criarAnuncioRequest)
        {
            Anuncio anuncio = new Anuncio();
            anuncio = criarAnuncioRequest.Anuncio;

            CriarAnuncioResponse criarAnuncioResponse = new CriarAnuncioResponse();
            criarAnuncioResponse.Successo = _servicoAnuncio.Cadastrar(anuncio);

            return criarAnuncioResponse;
        }
        public AtualizarAnuncioResponse AtualizarAnuncio(AtualizarAnuncioRequest atualizarAnuncioRequest)
        {
            Anuncio anuncio = new Anuncio();
            anuncio = atualizarAnuncioRequest.Anuncio;

            AtualizarAnuncioResponse atualizarAnuncioResponse = new AtualizarAnuncioResponse();
            atualizarAnuncioResponse.Successo = _servicoAnuncio.Atualizar(anuncio);

            return atualizarAnuncioResponse;
        }
        public ExcluirAnuncioResponse ExcluirAnuncio(int idAnuncio)
        {
            Anuncio anuncio = new Anuncio();

            ExcluirAnuncioResponse excluirAnuncioResponse = new ExcluirAnuncioResponse();
            excluirAnuncioResponse.Successo = _servicoAnuncio.Excluir(idAnuncio);

            return excluirAnuncioResponse;
        }
        public BuscarAnuncioResponse BuscarAnuncio(int idAnuncio)
        {
            Anuncio anuncio = new Anuncio();
            anuncio.Id = idAnuncio;
            Anuncio anuncioRetorno = _servicoAnuncio.ConsultarUnico(anuncio);

            BuscarAnuncioResponse buscarAnuncioResponse = new BuscarAnuncioResponse();
            buscarAnuncioResponse.AnuncioView = new AnuncioView()
            {
                Ano = anuncioRetorno.Ano,
                Id = anuncioRetorno.Id,
                Marca = anuncioRetorno.Marca,
                Modelo = anuncioRetorno.Modelo,
                Observacao = anuncioRetorno.Observacao,
                Quilometragem = anuncioRetorno.Quilometragem,
                Versao = anuncioRetorno.Versao
            };

            return buscarAnuncioResponse;
        }

        public BuscarVariosAnuncioResponse BuscarTodosAnuncio()
        {
            BuscarVariosAnuncioResponse buscarVariosAnuncioResponse = new BuscarVariosAnuncioResponse();
            buscarVariosAnuncioResponse.AnunciosView = new List<AnuncioView>();

            IList<Anuncio> ListaAnuncioRetorno = _servicoAnuncio.ConsultarTodos();
            foreach (Anuncio anuncioRetorno in ListaAnuncioRetorno)
            {
                buscarVariosAnuncioResponse.AnunciosView.Add(new AnuncioView()
                {
                    Ano = anuncioRetorno.Ano,
                    Id = anuncioRetorno.Id,
                    Marca = anuncioRetorno.Marca,
                    Modelo = anuncioRetorno.Modelo,
                    Observacao = anuncioRetorno.Observacao,
                    Quilometragem = anuncioRetorno.Quilometragem,
                    Versao = anuncioRetorno.Versao
                });
            }

            return buscarVariosAnuncioResponse;
        }
        public BuscarVariosAnuncioResponse BuscarAnuncioComFiltros(BuscarVariosAnuncioRequest buscarVariosAnuncioRequest)
        {
            Anuncio anuncio = new Anuncio();
            anuncio = buscarVariosAnuncioRequest.Anuncio;

            BuscarVariosAnuncioResponse buscarVariosAnuncioResponse = new BuscarVariosAnuncioResponse();
            buscarVariosAnuncioResponse.AnunciosView = new List<AnuncioView>();

            IList<Anuncio> ListaAnuncioRetorno = _servicoAnuncio.ConsultarComFiltro(anuncio);
            foreach (Anuncio anuncioRetorno in ListaAnuncioRetorno)
            {
                buscarVariosAnuncioResponse.AnunciosView.Add(new AnuncioView()
                {
                    Ano = anuncioRetorno.Ano,
                    Id = anuncioRetorno.Id,
                    Marca = anuncioRetorno.Marca,
                    Modelo = anuncioRetorno.Modelo,
                    Observacao = anuncioRetorno.Observacao,
                    Quilometragem = anuncioRetorno.Quilometragem,
                    Versao = anuncioRetorno.Versao
                });
            }

            return buscarVariosAnuncioResponse;
        }

        public void PopularBanco()
        {
            _servicoAnuncio.PopularBanco();
        }
    }
}
