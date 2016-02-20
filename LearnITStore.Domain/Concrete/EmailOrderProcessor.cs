using LearnITStore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnITStore.Domain.Entities;
using System.Net.Mail;
using System.Net;

namespace LearnITStore.Domain.Concrete
{
    public class EmailOrderProcessor : IOrderProcessor
    {
        private readonly EmailSettings _settings;
        public EmailOrderProcessor(EmailSettings settings)
        {
            _settings = settings;
        }

        public void Process(Cart cart, ShippingDetails shipping)
        {
            using(var client = new SmtpClient())
            {
                ConfigureSMTP(client);
                var body = BuildMessage(cart, shipping);

                var message = new MailMessage(
                    _settings.MailFrom, //From
                    _settings.MailTo,//To
                    "Nueva orden enviada", //Subject
                    body);//Contenido

                if (_settings.WriteAsFile)
                {
                    message.BodyEncoding = Encoding.UTF8;
                }

                client.Send(message);
            }
        }

        private string BuildMessage(Cart cart, ShippingDetails shipping)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Nueva orden enviada.")
            .AppendLine("--------------------")
            .AppendLine("Items:")
            .AppendLine("--------------------");

            foreach (var line in cart.Lines)
            {
                sb.AppendFormat("{0} x {1} (subtotal: {2:c}",
                    line.Product.Name,
                    line.Quantity,
                    line.SubTotal);
            }
            sb.AppendLine("");
            sb.AppendFormat("Total de la Orden: {0:c}", cart.TotalPrice);

            sb.AppendLine("--------------------")
            .AppendLine("Enviar a:")
            .AppendLine("--------------------")
            .AppendLine(shipping.Name)
            .AppendLine(shipping.Line1)
            .AppendLine(shipping.Line2 ?? "")
            .AppendLine(shipping.Line3 ?? "")
            .AppendLine(shipping.City)
            .AppendLine(shipping.State)
            .AppendLine(shipping.ZIP)
            .AppendLine(shipping.Country)
            .AppendLine("--------------------")
            .AppendFormat("Envoltura de regalo:{0}",
            shipping.GiftWrap ? "Si" : "No");

            return sb.ToString();
        }

        private void ConfigureSMTP(SmtpClient client)
        {
            client.EnableSsl = _settings.UseSSL;
            client.Host = _settings.Server;
            client.Port = _settings.ServerPort;
            client.UseDefaultCredentials = false;
            client.Credentials =
                new NetworkCredential(
                    _settings.UserName,
                    _settings.Password);

            if (_settings.WriteAsFile)
            {
                client.DeliveryMethod =
                    SmtpDeliveryMethod.SpecifiedPickupDirectory;
                client.PickupDirectoryLocation =
                    _settings.FileLocation;
                client.EnableSsl = false;
            }
        }
    }
}
