using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaReclutadora.Candidatos
{
    internal interface ICandidato
    {
        public void Actualizar(string encabezado, string cuerpoMensaje);
    }
}
