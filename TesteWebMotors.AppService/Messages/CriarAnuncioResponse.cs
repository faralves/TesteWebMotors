using TesteWebMotors.AppService.ViewModel;
using TesteWebMotors.Model;

namespace TesteWebMotors.AppService.Messages
{
    public class CriarAnuncioResponse : ResponseBase
    {
        public AnuncioView AnuncioView { get; set; }
    }
}
