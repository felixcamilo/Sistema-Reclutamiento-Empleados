using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpresaReclutadora.Candidatos;

namespace EmpresaReclutadora.Puestos
{
    public class PuestoLaboral
    {
        private protected string nombrePuesto;
        private protected double salario;
        private protected bool disponibilidad;
        List<Candidato> candidatos = new List<Candidato>();

        public PuestoLaboral(string puesto, double salario) { 
        
            this.nombrePuesto = puesto;
            this.salario = salario;
        
        }

        public void AñadirCandidato(Candidato candidato)
        {
            candidatos.Add(candidato);
        }

        public void QuitarCandidato(Candidato candidato)
        {
            candidatos.Remove(candidato);
        }

        public void Notificar(string nombreCandidato)
        {
            if (candidatos.Count >= 1)
            {

                foreach (Candidato candidato in candidatos)
                {
                    if (candidato.getAspiracionSalarial() <= this.salario && disponibilidad)
                    {
                        if (!candidato.getContratado() && candidato.getNombre() == nombreCandidato)
                        {
                            candidato.Actualizar("Despedido!", "Usted ha sido despedido del puesto laboral de ");
                            continue;
                        }

                        candidato.Actualizar("Vacante Disponible!" , "Tiene vacante disponible del puesto laboral de su interes");
                    }

                    else
                    if (candidato.getAspiracionSalarial() <= this.salario && !disponibilidad)
                    {
                        if (candidato.getContratado() && candidato.getNombre() == nombreCandidato)
                        {   
                            candidato.Actualizar("Estas contratado!", "Felicidades usted ha sido contratado al puesto laboral de ");
                            continue;

                        }

                        candidato.Actualizar("Vacante Ocupada!", "Este atento para cuando tengamos vacantes disponibles");

                    }
                    
                }

            }
            else
            {
                Console.WriteLine("No hay candidatos interesados");
                Console.ReadKey();
            }
        }

        public void setDisponibilidad(bool disponibilidad, string nombreCandidato)
        {
            this.disponibilidad = disponibilidad;
            Notificar(nombreCandidato);
        }


        public void setSalario(double salario)
        {
            this.salario = salario;
        }


        public string getNombrePuesto()
        {
            return nombrePuesto;
        }

        public List<Candidato> getCandidatos()
        {
            return this.candidatos;
        }
    }
}
