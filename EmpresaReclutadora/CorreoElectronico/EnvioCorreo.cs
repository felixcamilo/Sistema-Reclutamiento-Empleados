using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaReclutadora.CorreoElectronico
{
    internal class EnvioCorreo
    {
        public void enviar(string correo, string puestoLaboralDeInteres, string cuerpoMensaje, string encabezado)
        {
            Console.Clear();    
            try
            {
                string miCorreo = "alejandrocamilojavier5@gmail.com";
                string clave = "wslzdiaoktnwewzu";

                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress(miCorreo);

                mensaje.Subject = encabezado;
                mensaje.To.Add(new MailAddress(correo));

                mensaje.Body = $"<html><body>{cuerpoMensaje} {puestoLaboralDeInteres} </body></html>";
                mensaje.IsBodyHtml = true;

                var cliente = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(miCorreo, clave),
                    EnableSsl = true
                };

                cliente.Send(mensaje);
                Console.WriteLine("El correo ha sido enviado a todos los candidatos!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se produjo un error al enviar el correo");
            }
            Console.ReadKey();
        }
    }
}
