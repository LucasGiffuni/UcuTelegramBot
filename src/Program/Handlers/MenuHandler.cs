using Telegram.Bot.Types;
using PII_E13.model;
using System.Collections.Generic;
using System.Text;


namespace PII_E13.Handlers
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
                Person p1 = new Person(message.From.Id, message.From.FirstName, "Rol 1");

                foreach(Person p in Persons){ //Recorremos la lista de los usuarios buscando si el usuario p1 (auxiliar) existe dentro de los usuarios registrados
                    if(p.Id == p1.Id){        // En caso de que exista asignamos p a p1, el cual usaremos para evaluar los distintos roles
                        p1 = p;
                    }
                }

                if (Persons.Exists(x => x.Id == p1.Id) == false) //El ususario que se intenta registrar no existe en la lsita
                {
                    StringBuilder stringResponse = new StringBuilder();
                    stringResponse.Append("######## MENU ######## ");
                    stringResponse.Append("\n- registrar empresa");
                    stringResponse.Append("\n- registrar emprendedor");


                    response = stringResponse.ToString();
                    person = null;
                    responseCode = 00;

                    return true;

                }
                else if((Persons.Exists(x => x.Id == p1.Id) == true) & (p1.Role == "Empresario"))
                {
                    StringBuilder stringResponse = new StringBuilder();
                    stringResponse.Append("######## MENU EMPRESARIO ######## ");
                    stringResponse.Append("\n- hola");

                    response = stringResponse.ToString();
                    person = null;
                    responseCode = 00;

                    return true;
                }
                else if((Persons.Exists(x => x.Id == p1.Id) == true) & (p1.Role == "Emprendedor"))
                {
                    StringBuilder stringResponse = new StringBuilder();
                    stringResponse.Append("######## MENU EMPRENDEDOR ######## ");
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