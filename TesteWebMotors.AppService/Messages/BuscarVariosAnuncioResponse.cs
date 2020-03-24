using System.Collections.Generic;
using TesteWebMotors.AppService.ViewModel;

namespace TesteWebMotors.AppService.Messages
{
    public class BuscarVariosAnuncioResponse : ResponseBase
    {
        public IList<AnuncioView> AnunciosView { get; set; }
    }
}
