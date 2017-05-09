using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructionComboApp.Data.models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ConstructionComboApp.Services
{
    public class TextingService
    {
        public static void MakeTwilioCall(OrderRequestModel input)
        {
            const string accountSid = "ACc99a3c101d2bb9846bcf0ff2be77644b";
            const string authToken = "d399de8fdf2a9420ba7d813fe1319054";

            TwilioClient.Init(accountSid, authToken);
            /*
            MessageResource.Create(
                from: new PhoneNumber("225-361-8457"),
                to: new PhoneNumber("+19313196339"),
                body: $"Work Request Recieved: Name: {input.Name}, Phone: {input.PhoneNumber}, Email: {input.Email}, Description: {input.OrderDescription}");
            */        
            MessageResource.Create(
                from: new PhoneNumber("225-361-8457"),
                to: new PhoneNumber("+12253059321"),
                body: $"Work Request Recieved: Name: {input.Name}, Phone: {input.PhoneNumber}, Email: {input.Email}, Description: {input.OrderDescription}");
        }
    }
}
