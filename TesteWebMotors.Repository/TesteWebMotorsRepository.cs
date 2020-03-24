using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TesteWebMotors.Model;
using TesteWebMotors.Model.Contract;

namespace TesteWebMotors.Repository
{
    public class TesteWebMotorsRepository : ITesteWebMotorsRepository
    {
        private TesteWebMotorsContext context = new TesteWebMotorsContext();

        public TesteWebMotorsRepository()
        {

        }
        public TesteWebMotorsRepository(TesteWebMotorsContext ctx)
        {
            context = ctx;

        }
        public bool Add(Anuncio anuncio)
        {
            bool cadastrou = false;
            try
            {
                context.Anuncio.Add(anuncio);

                context.SaveChanges();
            }
            catch 
            {
                throw;
            }

            return cadastrou;
        }

        public bool Save(Anuncio anuncio)
        {
            bool salvou = false;
            try
            {
                Anuncio anuncioContext = PesquisarAnuncio(anuncio);
                anuncioContext.Ano = anuncio.Ano;
                anuncioContext.Marca = anuncio.Marca;
                anuncioContext.Modelo = anuncio.Modelo;
                anuncioContext.Observacao = anuncio.Observacao;
                anuncioContext.Quilometragem = anuncio.Quilometragem;
                anuncioContext.Versao = anuncio.Versao;

                context.SaveChanges();
            }
            catch 
            {
                throw;
            }
            return salvou;
        }

        public IList<Anuncio> PesquisarTodosAnuncios()
        {
            return context.Anuncio.Where(x=> x.Id >0).ToList();
        }

        public IList<Anuncio> PesquisarTodosAnunciosComFiltroMarca(Anuncio anuncio)
        {
            return context.Anuncio.Where(x => x.Marca == anuncio.Marca).ToList();
        }
        public IList<Anuncio> PesquisarTodosAnunciosComFiltroModelo(Anuncio anuncio)
        {
            return context.Anuncio.Where(x => x.Modelo == anuncio.Modelo).ToList();
        }
        public IList<Anuncio> PesquisarTodosAnunciosComFiltroAno(Anuncio anuncio)
        {
            return context.Anuncio.Where(x => x.Ano == anuncio.Ano).ToList();
        }
        public IList<Anuncio> PesquisarTodosAnunciosComFiltroKM(Anuncio anuncio)
        {
            return context.Anuncio.Where(x => x.Quilometragem == anuncio.Quilometragem).ToList();
        }
        public IList<Anuncio> PesquisarTodosAnunciosComFiltroVersao(Anuncio anuncio)
        {
            return context.Anuncio.Where(x => x.Marca == anuncio.Marca && x.Modelo == anuncio.Modelo && x.Versao == anuncio.Versao).ToList();
        }
        public IList<Anuncio> PesquisarTodosAnunciosComFiltroVersaoAno(Anuncio anuncio)
        {
            return context.Anuncio.Where(x => x.Marca == anuncio.Marca && x.Modelo == anuncio.Modelo && x.Versao == anuncio.Versao && x.Ano == anuncio.Ano).ToList();
        }
        public IList<Anuncio> PesquisarTodosAnunciosComFiltroMarcaModelo(Anuncio anuncio)
        {
            return context.Anuncio.Where(x => x.Marca == anuncio.Marca && x.Modelo == anuncio.Modelo).ToList();
        }
        public IList<Anuncio> PesquisarTodosAnunciosComFiltroMarcaModeloAno(Anuncio anuncio)
        {
            return context.Anuncio.Where(x => x.Marca == anuncio.Marca && x.Modelo == anuncio.Modelo && x.Ano == anuncio.Ano).ToList();
        }
        public IList<Anuncio> PesquisarTodosAnunciosComFiltroMarcaModeloKM(Anuncio anuncio)
        {
            return context.Anuncio.Where(x => x.Marca == anuncio.Marca && x.Modelo == anuncio.Modelo && x.Quilometragem == anuncio.Quilometragem).ToList();
        }
        public IList<Anuncio> PesquisarTodosAnunciosComFiltroMarcaKM(Anuncio anuncio)
        {
            return context.Anuncio.Where(x => x.Marca == anuncio.Marca && x.Quilometragem == anuncio.Quilometragem).ToList();
        }
        public IList<Anuncio> PesquisarTodosAnunciosComFiltroModeloKM(Anuncio anuncio)
        {
            return context.Anuncio.Where(x => x.Modelo == anuncio.Modelo && x.Quilometragem == anuncio.Quilometragem).ToList();
        }
        public IList<Anuncio> PesquisarTodosAnunciosComTodosFiltros(Anuncio anuncio)
        {
            return context.Anuncio.Where(x => x.Marca == anuncio.Marca && x.Modelo == anuncio.Modelo && x.Quilometragem == anuncio.Quilometragem && x.Ano == anuncio.Ano).ToList();
        }

        public Anuncio PesquisarAnuncio(Anuncio anuncio)
        {
            Anuncio anunciocontex = null;
            if (anuncio != null)
                anunciocontex = context.Anuncio.Where(x => (x.Id == anuncio.Id) || (x.Marca == anuncio.Marca && x.Modelo == anuncio.Modelo && x.Ano == anuncio.Ano && x.Versao == anuncio.Versao && x.Quilometragem == anuncio.Quilometragem)).FirstOrDefault();
            else
                anunciocontex = new Anuncio();
            return anunciocontex;
        }

        public bool ExcluirAnuncio(int idAnuncio)
        {
            bool excluiu = false;
            try
            {
                Anuncio anuncio = new Anuncio() { Id = idAnuncio };
                Anuncio anuncioContext = PesquisarAnuncio(anuncio);

                context.Anuncio.Remove(anuncioContext);
                context.SaveChanges();
                excluiu = true;
            }
            catch 
            {
                throw;
            }
            return excluiu;
        }

        public void AtualizarOuCriarMarca(Marca marca)
        {
            Marca marcaContext = context.Marca.Find(marca.Id);
            if (marcaContext == null)
                context.Marca.Add(marca);
            else
            {
                marcaContext = new Marca();
                marcaContext = marca;
            }

            context.SaveChanges();                 
        }

        public IList<Marca> PesquisarTodasMarcas()
        {
            return context.Marca.Where(x => x.Id > 0).ToList();
        }

        public void AtualizarOuCriarModelo(Modelo modelo)
        {
            Modelo modeloContext = context.Modelo.Find(modelo.Id);
            if (modeloContext == null)
                context.Modelo.Add(modelo);
            else
            {
                modeloContext = new Modelo();
                modeloContext = modelo;
            }

            context.SaveChanges();                 
        }
        public IList<Modelo> PesquisarTodosModelos()
        {
            return context.Modelo.Where(x => x.Id > 0).ToList();
        }

        public void AtualizarOuCriarVersao(Versao versao)
        {
            Versao versaoContext = context.Versao.Find(versao.Id);
            if (versaoContext == null)
            {
                versaoContext = new Versao(); 
                context.Versao.Add(versao);
            }
            else
                versaoContext = versao;

            context.SaveChanges();                 
        }

        public IList<Versao> PesquisarTodasVersoes()
        {
            return context.Versao.Where(x => x.Id > 0).ToList();
        }

        public void AtualizarOuCriarVeiculo(Veiculo veiculo)
        {
            Veiculo veiculoContext = context.Veiculo.Find(veiculo.Id);
            if (veiculoContext == null)
                context.Veiculo.Add(veiculo);
            else
            {
                veiculoContext = new Veiculo();
                veiculoContext = veiculo;
            }

            context.SaveChanges();                 
        }

        public IList<Veiculo> PesquisarTodosVeiculos()
        {
            return context.Veiculo.Where(x => x.Id > 0).ToList();
        }

        public IList<Anuncio> PesquisarAnuncioTabelasRelacionais()
        {
            IList<Anuncio> listaAnuncio = new List<Anuncio>();

            var linq = from marca in context.Marca
                       join modelo in context.Modelo on marca.Id equals modelo.MakeId
                       join versao in context.Versao on modelo.Id equals versao.ModelId
                       select new
                       {
                           Marca = marca.Name,
                           Modelo = modelo.Name,
                           Versao = versao.Name
                       };
            var newListAnuncio = linq.ToList();

            Anuncio anuncio = null;
            foreach (var item in newListAnuncio)
            {
                anuncio = new Anuncio()
                {
                    Marca = item.Marca,
                    Modelo = item.Modelo,
                    Versao = item.Versao
                };
                listaAnuncio.Add(anuncio);
            }

            return listaAnuncio;
        }
    }
}
