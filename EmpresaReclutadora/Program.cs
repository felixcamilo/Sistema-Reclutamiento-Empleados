
using EmpresaReclutadora.Candidatos;
using EmpresaReclutadora.Puestos;
using System.Security.Cryptography.X509Certificates;

PuestoLaboral puestoCamarero = new Camarero("Camarero", 3000.00);

PuestoLaboral puestoCocinero = new Cocinero("Cocinero", 5000.00);

PuestoLaboral puestoSupervisor = new Supervisor("Supervisor", 7000.00);

PuestoLaboral puestoRecepcionista = new Recepcionista("Recepcionista", 9000.00);

PuestoLaboral puestoServicioAlCliente = new ServicioAlCliente("Servicio al cliente", 11000.00);


List<PuestoLaboral> puestosLaborales = new List<PuestoLaboral>();

puestosLaborales.Add(puestoCamarero);
puestosLaborales.Add(puestoCocinero);
puestosLaborales.Add(puestoSupervisor);
puestosLaborales.Add(puestoRecepcionista);
puestosLaborales.Add(puestoServicioAlCliente);


do
{
    Console.Clear();
    Console.WriteLine("********************EMPRESA RECLUTADORA********************");
    Console.WriteLine();
    Console.WriteLine("Elija su rol correspondiente...");
    Console.WriteLine("Reclutador[1] Candidato[2] Salir[3]");

    int opcion = 0;
    opcion = int.Parse(Console.ReadLine());

    if (opcion == 1)
    {
        Console.Clear();
        Console.WriteLine("Elija con la letra indicada lo que desee hacer con los puestos laborales");
        Console.WriteLine("aumentar salario[S] contratar candidato[C] despedir candidato[D]");
        string letra = Console.ReadLine().ToUpper();


        if (letra == "S")
        {
            Console.Clear();
            Console.WriteLine("Elija el puesto laboral al que desea editar el salario");
            Console.WriteLine("Camarero[1] Cocinero[2] Supervisor[3] Recepcionista[4] Servicio al Cliente[5] ");
            
            opcion = int.Parse(Console.ReadLine());
            opcion = opcion - 1;
            double nuevoSalario;

            Console.Write("Nuevo salario: ");
            nuevoSalario = int.Parse(Console.ReadLine());

            puestosLaborales[opcion].setSalario(nuevoSalario);

        }

        else if (letra == "C")
        {
            Console.Clear();
            Console.WriteLine("Escriba el nombre del candidato que quiere contratar al puesto laboral solicitado");
            
            string nombreCandidato = Console.ReadLine();

            List<Candidato> candidatos;

                
            foreach (PuestoLaboral puestoLaboral in puestosLaborales)
            {
                candidatos = puestoLaboral.getCandidatos();
                int ii = 0;

                foreach (Candidato suscriptor in candidatos)
                {
                    ii++;

                    if (suscriptor.getNombre() == nombreCandidato)
                    {
                        suscriptor.setContratado(true);
                        puestoLaboral.setDisponibilidad(false, nombreCandidato); 
                        break;
                    }
                    else
                    if (candidatos.Count == ii)
                    {
                        Console.WriteLine("Candidato inexistente");
                        Console.ReadKey();
                    }
                }
            }
   
        }
        else if(letra == "D")
        {
            Console.Clear();
            Console.WriteLine("Escriba el nombre del candidato que quiere despedir de su puesto laboral");

            string nombreCandidato = Console.ReadLine();

            List<Candidato> candidatos;


            foreach (PuestoLaboral puestoLaboral in puestosLaborales)
            {
                candidatos = puestoLaboral.getCandidatos();
                int ii = 0;

                foreach (Candidato suscriptor in candidatos)
                {
                    ii++;

                    if (suscriptor.getNombre() == nombreCandidato)
                    {
                        suscriptor.setContratado(false);
                        puestoLaboral.setDisponibilidad(true, nombreCandidato);
                        puestoLaboral.QuitarCandidato(suscriptor);
                        break;
                    }
                    else
                    if (candidatos.Count == ii)
                    {
                        Console.WriteLine("Candidato inexistente");
                        Console.ReadKey();
                    }
                }
            }
        }



    }
    else if (opcion == 2)
    {
        Console.Clear();
        Console.WriteLine("Elija");
        Console.WriteLine("Solicitar empleo[1] cancelar solicitud[2]");
        int opcionCandidato = int.Parse(Console.ReadLine());

        switch (opcionCandidato)
        {

            case 1:
                Console.Clear();
                Console.WriteLine("********Registrese******");
                Console.WriteLine();

                Candidato candidato = new Candidato();

                Console.Write("Nombre: ");  candidato.setNombre(Console.ReadLine());

                Console.Write("Cedula: ");  candidato.setCedula(Console.ReadLine());

                Console.Write("Correo: ");  candidato.setCorreo(Console.ReadLine());

                Console.Write("Aspiracion Salarial: "); candidato.setAspiracionSalarial(double.Parse(Console.ReadLine()));

                Console.WriteLine();

                Console.WriteLine("Registro exitoso");

                Console.ReadKey();

                Console.Clear();
                Console.WriteLine("Elija el puesto laboral que le interese: ");
                Console.WriteLine("Camarero[1] Cocinero[2] Supervisor[3] Recepcionista[4] Servicio al Cliente[5] Ninguno[6]");
                int eleccion = int.Parse(Console.ReadLine());
                eleccion = eleccion - 1;
                puestosLaborales[eleccion].AñadirCandidato(candidato);
                candidato.setPuestoLaboralDeInteres(puestosLaborales[eleccion].getNombrePuesto());

                Console.Write("Candidato registrado ");
                Console.ReadKey();
                break;


            case 2:
 
                    Console.WriteLine("Digite su nombre para cancelar la solicitud del puesto laboral de su interes: ");
                    string candidatoNombre = Console.ReadLine();

                    List<Candidato> candidatos;

                    foreach(PuestoLaboral puestoLaboral in puestosLaborales)
                    {
                        candidatos = puestoLaboral.getCandidatos();
                        int i = 0;

                        foreach (Candidato suscriptor in candidatos)
                        {
                            i++;

                            if(suscriptor.getNombre() == candidatoNombre)
                            {
                                puestoLaboral.QuitarCandidato(suscriptor);
                                Console.WriteLine("Ya no estas interesado en el puesto laboral");
                                break;
                            }
                            else
                            if(candidatos.Count == i)
                            {
                                Console.WriteLine("Candidato inexistente");
                                Console.ReadKey();

                            }
                    }
                    }
                Console.ReadKey();
                break;
        }
    }

    else if (opcion == 3)
    {
        Environment.Exit(0);
    }
    
}
while (true);

