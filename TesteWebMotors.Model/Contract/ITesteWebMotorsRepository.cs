using System.Collections.Generic;

namespace TesteWebMotors.Model.Contract
{
    public interface ITesteWebMotorsRepository
    {
        bool Add(Anuncio anuncio);
        bool Save(Anuncio anuncio);
        IList<Anuncio> PesquisarTodosAnuncios();
        IList<Anuncio> PesquisarTodosAnunciosComFiltroMarca(Anuncio anuncio);
        IList<Anuncio> PesquisarTodosAnunciosComFiltroModelo(Anuncio anuncio);
        IList<Anuncio> PesquisarTodosAnunciosComFiltroAno(Anuncio anuncio);
        IList<Anuncio> PesquisarTodosAnunciosComFiltroKM(Anuncio anuncio);
        IList<Anuncio> PesquisarTodosAnunciosComFiltroVersao(Anuncio anuncio);
        IList<Anuncio> PesquisarTodosAnunciosComFiltroVersaoAno(Anuncio anuncio);
        IList<Anuncio> PesquisarTodosAnunciosComFiltroMarcaModelo(Anuncio anuncio);
        IList<Anuncio> PesquisarTodosAnunciosComFiltroMarcaModeloAno(Anuncio anuncio);
        IList<Anuncio> PesquisarTodosAnunciosComFiltroMarcaModeloKM(Anuncio anuncio);
        IList<Anuncio> PesquisarTodosAnunciosComFiltroMarcaKM(Anuncio anuncio);
        IList<Anuncio> PesquisarTodosAnunciosComFiltroModeloKM(Anuncio anuncio);
        IList<Anuncio> PesquisarTodosAnunciosComTodosFiltros(Anuncio anuncio);
        Anuncio PesquisarAnuncio(Anuncio anuncioId);
        bool ExcluirAnuncio(int idAnuncio);
        void AtualizarOuCriarMarca(Marca marca);
        IList<Marca> PesquisarTodasMarcas();
        void AtualizarOuCriarModelo(Modelo modelo);
        IList<Modelo> PesquisarTodosModelos();
        void AtualizarOuCriarVersao(Versao versao);
        IList<Versao> PesquisarTodasVersoes();
        void AtualizarOuCriarVeiculo(Veiculo veiculo);
        IList<Veiculo> PesquisarTodosVeiculos();

        IList<Anuncio> PesquisarAnuncioTabelasRelacionais();
    }
}
