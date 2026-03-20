using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaReclutadora.Puestos
{
    internal class Supervisor : PuestoLaboral
    {
        public Supervisor(string nombre, double salario) : base(nombre, salario)  {}
    }
}
