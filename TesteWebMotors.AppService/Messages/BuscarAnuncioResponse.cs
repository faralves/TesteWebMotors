using TesteWebMotors.AppService.ViewModel;

namespace TesteWebMotors.AppService.Messages
{
    public class BuscarAnuncioResponse : ResponseBase
    {
        public AnuncioView AnuncioView { get; set; }
    }
}
