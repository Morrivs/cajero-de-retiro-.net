using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Enums;

namespace Application.ViewModels
{
    public class RetiroVewModel
    {
        public int monto { get; set; }
        public string resultado { get; set; }
        public int configuracion { get; set; } = (int)ModoDispencion.eficiente;
    }
}
