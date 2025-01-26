using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Enums;
using Application.Repository;
using Application.ViewModels;

namespace Application.Services
{
    public class DispensadorService
    {
        public void modoDispension(ConfiguracionViewModel vm)
        {    
            CajeroRepository.Instance.Retiro.configuracion = vm.modoconfiguracion;
        }

        public void retirar(RetiroVewModel vm)
        {
            switch (CajeroRepository.Instance.Retiro.configuracion)
            {
                case (int)ModoDispencion._200y1000:
                    if (vm.monto % 200 != 0 && vm.monto % 1000 != 0)
                    {
                        vm.resultado = "Este cajero solo dispensa billetes de 200 y 1000.";
                    }
                    else
                    {
                        int billetesDeMil = vm.monto / 1000;
                        vm.monto %= 1000;

                        int billetesDeDoscientos = vm.monto / 200;

                        vm.resultado = $"Dispensado: {billetesDeMil} billete(s) de 1000 y {billetesDeDoscientos} billete(s) de 200.";
                    }

                    CajeroRepository.Instance.Retiro.monto = vm.monto;
                    CajeroRepository.Instance.Retiro.resultado = vm.resultado;
                    CajeroRepository.Instance.Retiro.configuracion = vm.configuracion;

                    break;
                case (int)ModoDispencion._100y500:
                    if (vm.monto % 100 != 0 && vm.monto % 500 != 0)
                    {
                        vm.resultado = "Este cajero solo dispensa billetes de 100 y 500.";
                    }
                    else
                    {
                        int billetesDeQuinientos = vm.monto / 500;
                        vm.monto %= 500;

                        int billetesDeCien = vm.monto / 100;
                        vm.resultado = $"Dispensado: {billetesDeQuinientos} billete(s) de 500 y {billetesDeCien} billete(s) de 100.";
                    }
                    CajeroRepository.Instance.Retiro.monto = vm.monto;
                    CajeroRepository.Instance.Retiro.resultado = vm.resultado;
                    CajeroRepository.Instance.Retiro.configuracion = vm.configuracion;
                    break;
                case (int)ModoDispencion.eficiente:
                    int[] billetes = { 1000, 500, 200, 100 };
                    string resultado = "Dispensado: ";
                    foreach (var billete in billetes)
                    {
                        int cantidad = vm.monto / billete;
                        if (cantidad > 0)
                        {
                            resultado += $"{cantidad} billete(s) de {billete}, ";
                            vm.monto %= billete;
                        }
                    }
                    vm.resultado = resultado;
                    CajeroRepository.Instance.Retiro.monto = vm.monto;
                    CajeroRepository.Instance.Retiro.resultado = vm.resultado;
                    CajeroRepository.Instance.Retiro.configuracion = vm.configuracion;
                    break;
                default: 
                    
                    break;
            }
            
        }

        public RetiroVewModel getAll()
        {
            return CajeroRepository.Instance.Retiro;
        }
    }
}
