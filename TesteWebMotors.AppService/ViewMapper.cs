using AutoMapper;
using TesteWebMotors.AppService.ViewModel;
using TesteWebMotors.Model;

namespace TesteWebMotors.AppService
{
    public class ViewMapper : Profile
    {
        public ViewMapper()
        {
            CreateMap<Anuncio, AnuncioView>();
        }
    }
}
