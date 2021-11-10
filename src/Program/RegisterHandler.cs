using Telegram.Bot.Types;
using System;
using System.Collections.Generic;
using Ucu.Poo.model;

namespace Ucu.Poo.TelegramBot
{


    public class RegisterHandler : BaseHandler
    {


        private new List<Person> Persons;
        public RegisterHandler(BaseHandler next, List<Person> persons) : base(next)
        {
            this.Persons = persons;
            this.Keywords = new string[] { "register" };
        }


        protected override bool InternalHandle(Message message, out string response, out int responseCode, out Person outPerson)
        {

            if (this.CanHandle(message))
            {
                Person p1 = new Person(message.From.Id, message.From.FirstName, message.From.LastName, "Rol 1");

                if (Persons.Exists(x => x.Name == p1.Name) == false) //El ususario que se intenta registrar no existe en la lsita
                {



                    response = "Bienvenido " + p1.Name + ", has sido registrado como " + p1.Role;
                    outPerson = p1;
                    responseCode = 01;
                    return true;

                }
                else
                {
                    response = "El Usuario " + p1.Name + " ya se encuentra registrado.";
                    outPerson = p1;
                    responseCode = 00;
                    return true;
                }
            }


            outPerson = null;
            responseCode = 00;
            response = string.Empty;
            return false;
        }


    }

}