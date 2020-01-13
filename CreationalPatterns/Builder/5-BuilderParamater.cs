using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.CreationalPatterns.Builder
{
    public class Email
    {
        public string From, To, Subject, Body;
        // other members here
    }

    public class EmailBuilder
    {
        private readonly Email email;
        public EmailBuilder(Email email) => this.email = email;
        public EmailBuilder From(string from)
        {
            email.From = from;
            return this;
        }

        public EmailBuilder To(string to)
        {
            email.To = to;
            return this;
        }
        public EmailBuilder Body(string body)
        {
            email.Body = body;
            return this;
        }

        // other fluent members here
    }

    public class MailService
    {
        //public class EmailBuilder { ... }
        private void SendEmailInternal(Email email) { }
        public void SendEmail(Action<EmailBuilder> builder)
        {
            var email = new Email();
            builder(new EmailBuilder(email));
            SendEmailInternal(email);
        }
    }

    class DemoParameter
    {
        static void Main2(string[] args)
        {
            var ms = new MailService();
            ms.SendEmail(email => email.From("foo@bar.com")
             .To("bar@baz.com")
             .Body("Hello, how are you?"));
        }
    }
}
