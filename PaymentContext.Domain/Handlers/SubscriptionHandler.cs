using System;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable,
        IHandler<CreateBoletoSubscriptionCommand>,
        IHandler<CreatePayPalSubscriptionCommand>,
        IHandler<CreateCreditCardSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;
        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //Fail Fast Validations
            command.Validate();
            if(command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "It was not possible create subscription");
            }
                
            //Verify if document has been saved
            if(_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF ja esta em uso");

            //verifify if e-mail has been saved
            if(_repository.EmailExists(command.Email))
                AddNotification("E-mail", "Este E-mail ja esta em uso");

            //Create VO's
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            //Create Entities
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.BarCode,
                command.BoletoNumber,
                command.PaidDate,
                command.ExpireDate,
                command.Total, 
                command.TotalPaid,
                command.Payer,
                new Document(command.Document, EDocumentType.CPF),
                address,
                email
            );
            // Relationships
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);
            
            //Group validations
            AddNotifications(name, document, email, address, student, subscription, payment);

            //Save information
            _repository.CreateSubscriprion(student);

            //Send welcome e-mail
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Welcome", "Your subscription has been created");

            //return information
            return new CommandResult(true, "Subscription success");
        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            //CREATE FAIL FAST VALIDATIONS
                
            //Verify if document has been saved
            if(_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF ja esta em uso");

            //verifify if e-mail has been saved
            if(_repository.EmailExists(command.Email))
                AddNotification("E-mail", "Este E-mail ja esta em uso");

            //Create VO's
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            //Create Entities
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PayPalPayment(command.TransactionCode,
                command.PaidDate,
                command.ExpireDate,
                command.Total, 
                command.TotalPaid,
                command.Payer,
                new Document(command.Document, EDocumentType.CPF),
                address,
                email
            );
            // Relationships
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);
            
            //Group validations
            AddNotifications(name, document, email, address, student, subscription, payment);

            //Save information
            _repository.CreateSubscriprion(student);

            //Send welcome e-mail
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Welcome", "Your subscription has been created");

            //return information
            return new CommandResult(true, "Subscription success");
        }

        public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
        {
            //CREATE FAIL FAST VALIDATIONS
                
            //Verify if document has been saved
            if(_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF ja esta em uso");

            //verifify if e-mail has been saved
            if(_repository.EmailExists(command.Email))
                AddNotification("E-mail", "Este E-mail ja esta em uso");

            //Create VO's
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            //Create Entities
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new CreditCardPayment(command.CardHolderName,
                command.CardNumber,
                command.LastTransactionNumber,
                command.PaidDate,
                command.ExpireDate,
                command.Total, 
                command.TotalPaid,
                command.Payer,
                new Document(command.Document, EDocumentType.CPF),
                address,
                email
            );
            // Relationships
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);
            
            //Group validations
            AddNotifications(name, document, email, address, student, subscription, payment);

            //Save information
            _repository.CreateSubscriprion(student);

            //Send welcome e-mail
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Welcome", "Your subscription has been created");

            //return information
            return new CommandResult(true, "Subscription success");
        }
    }
}