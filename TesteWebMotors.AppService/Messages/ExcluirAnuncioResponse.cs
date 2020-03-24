using TesteWebMotors.AppService.ViewModel;
using TesteWebMotors.Model;

namespace TesteWebMotors.AppService.Messages
{
    public class ExcluirAnuncioResponse : ResponseBase
    {
        public AnuncioView AnuncioView { get; set; }
    }
}
