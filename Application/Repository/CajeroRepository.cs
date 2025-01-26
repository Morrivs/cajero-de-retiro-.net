using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;

namespace Application.Repository
{
    public sealed class CajeroRepository
    {
        private CajeroRepository() { }
        public static CajeroRepository Instance { get; } = new();
        public RetiroVewModel Retiro { get; set; } = new();
    }
}
