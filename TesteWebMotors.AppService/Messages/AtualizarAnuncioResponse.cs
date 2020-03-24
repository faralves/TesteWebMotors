using TesteWebMotors.AppService.ViewModel;

namespace TesteWebMotors.AppService.Messages
{
    public class AtualizarAnuncioResponse : ResponseBase
    {
        public AnuncioView AnuncioView { get; set; }

    }
}
