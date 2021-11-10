using Telegram.Bot.Types;
using Ucu.Poo.model;

namespace Ucu.Poo.TelegramBot
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class HelloHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="HelloHandler"/>. Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public HelloHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "hola" };
        }

        /// <summary>
        /// Procesa el mensaje "hola" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(Message message, out string response, out int responseCode, out Person person)
        {
            if (this.CanHandle(message))
            {
                response = "¡Hola! ¿Cómo estás?";
                person = null;
                responseCode = 00;

                return true;
            }
            person = null;
            responseCode = 00;

            response = string.Empty;
            return false;
        }

    }
}