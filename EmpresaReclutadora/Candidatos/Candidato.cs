using EmpresaReclutadora.CorreoElectronico;
using EmpresaReclutadora.Puestos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaReclutadora.Candidatos
{
    public class Candidato : ICandidato
    {
        private string nombre;
        private string cedula;
        private string correo;
        private double aspiracionSalarial;
        private string puestoLaboralDeInteres;
        private bool contratado = false;

        public Candidato(string nombre, string cedula, string correo, double aspiracionSalarial)
        {
            this.nombre = nombre;
            this.cedula = cedula;
            this.correo = correo;
            this.aspiracionSalarial = aspiracionSalarial;
        }

        public Candidato(){}

        public void Actualizar(string encabezado, string cuerpoMensaje)
        {
            EnvioCorreo envioCorreo = new EnvioCorreo();
            envioCorreo.enviar(this.correo, this.puestoLaboralDeInteres, cuerpoMensaje, encabezado);
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;   
        }

        public void setCedula(string cedula)
        {
            this.cedula = cedula;
        }

        public void setCorreo(string correo)
        {
            this.correo = correo;
        }

        public void setAspiracionSalarial(double aspiracionsalarial)
        {
            this.aspiracionSalarial = aspiracionsalarial;
        }

        public void setPuestoLaboralDeInteres(string puestoLaboralDeInteres)
        {
            this.puestoLaboralDeInteres = puestoLaboralDeInteres;
        }

        public void setContratado(bool contratado)
        {
            this.contratado = contratado;
        }
        public string getNombre()
        {
            return this.nombre;
        }

        public double getAspiracionSalarial()
        {
            return (double)this.aspiracionSalarial;
        }

        public string getPuestoLaboralDeInteres()
        {
            return this.puestoLaboralDeInteres;
        }

        public bool getContratado()
        {
            return this.contratado;
        }
    }
}
