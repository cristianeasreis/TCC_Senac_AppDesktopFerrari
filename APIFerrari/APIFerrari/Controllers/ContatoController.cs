using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APIFerrari.Controllers
{
    public class ContatoController : ApiController
    {
        // GET: api/Contato
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        [HttpGet]
        public IHttpActionResult Get(string nome, string email, string telefone, string assunto, string mensagem)
        {

            string body = "";
            body += "Nome:" + nome + Environment.NewLine;
            body += "E_mail:" + email + Environment.NewLine;
            body += "Telefone:" + telefone + Environment.NewLine;
            body += "Assunto:" + assunto + Environment.NewLine;
            body += "Mensagem:" + mensagem;


            // Configuração de SMTP
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("ferrarieempilhadeira@gmail.com", "p@ssw0rdjean");

            //Preparando a menssagem sendo emviada
            MailMessage msg = new MailMessage();

            //Rementente
            msg.From = new MailAddress("ferrarieempilhadeira@gmail.com");

            //destino
            msg.To.Add(new MailAddress("cristianeara628@gmail.com"));

            //Assunto
            msg.Subject = "  Contato via site  " + assunto;

            //Corpo do email
            msg.Body = body;

            smtp.Send(msg);
            return Ok();
        }
    }



}


