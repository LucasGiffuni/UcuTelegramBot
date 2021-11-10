using Telegram.Bot.Types;
using Ucu.Poo.model;
using System.Collections.Generic;
using System.Text;


namespace Ucu.Poo.TelegramBot
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "chau".
    /// </summary>
    public class MenuHandler : BaseHandler
    {
        private new List<Person> Persons;


        public MenuHandler(BaseHandler next, List<Person> persons) : base(next)
        {
            this.Persons = persons;
            this.Keywords = new string[] { "menu" };
        }


        protected override bool InternalHandle(Message message, out string response, out int responseCode, out Person person)
        {
            if (this.CanHandle(message))
            {
                Person p1 = new Person(message.From.Id, message.From.FirstName, message.From.LastName, "Rol 1");
                if (Persons.Exists(x => x.Id == p1.Id) == false) //El ususario que se intenta registrar no existe en la lsita
                {
                    StringBuilder stringResponse = new StringBuilder();
                    stringResponse.Append("######## MENU ######## ");
                    stringResponse.Append("\n- register");

                    response = stringResponse.ToString();
                    person = null;
                    responseCode = 00;

                    return true;

                }
                else
                {
                   StringBuilder stringResponse = new StringBuilder();
                    stringResponse.Append("######## MENU ######## ");
                    stringResponse.Append("\n- hola");

                    response = stringResponse.ToString();
                    person = null;
                    responseCode = 00;

                    return true;
                }



            }
            person = null;
            responseCode = 00;

            response = string.Empty;
            return false;
        }


    }
}