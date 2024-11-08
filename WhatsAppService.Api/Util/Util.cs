using WhatsAppService.Api.Models;

namespace WhatsAppService.Api.Util
{
    public class Util : IUtil
    {
        // public string GetUserText(WhatsAppModel message)
        // {
        //     // plural?
        //     string tipo = message.Entry[0].Changes[0].Value.Messages[0].Type;
        //     if (tipo == "text")
        //     {
        //         string mensaje = message.Entry[0].Changes[0].Value.Messages[0].Text.Body;
        //         return mensaje;
        //     }
        //     else
        //     {
        //         return "Error";
        //     }

        // }


        // public string GetUserText(WhatsAppModel message)
        // {
            // string mensaje = message.Entry[0].Changes[0].Value.Messages[0];

        // string TypeMessage = message.Type ?? "";

        // if(TypeMessage.ToUpper() == "TEXT"){
        //     return message.Text.Body;
        // }
        // return "Mensaje mno compatible";

            // switch (mensaje.Type.ToUpper())
            // {
            //     case "TEXT":
            //         return mensaje.Text.Body;
            //         break;

            //     case "INTERACTIVE":
            //         string interactiveType = mensaje.Interactive.Type;
            //         if (interactiveType.ToUpper() == "LIST_REPLY")
            //         {
            //             return mensaje.Interactive.List_Reply.Title;
            //         }
            //         else if (interactiveType.ToUpper() == "BUTTON_REPLY")
            //         {
            //             return mensaje.Interactive.Button_Reply.Title;
            //         }
            //         else
            //         {
            //             return string.Empty;
            //         }
            //         break;
            //     case "IMAGE":
            //         return mensaje.Text.Body;
            //     case "LOCATION":
            //         return mensaje.Text.Body.ToString();
            //     default:
            //         return string.Empty;
            // }

            // return string.Empty;
        // }




        public string GetUserText(Message message)
        {
            string TypeMessage = message.Type ?? "";

            if (TypeMessage.ToUpper() == "TEXT")
            {
                return message.Text.Body;
            }
            return "Mensaje no compatible";
            
        }







        public string TratarNumero(string numero){
            return numero.Remove(2,1);
        }


        public string GetUserType(WhatsAppModel message)
        {
            return message.Entry[0].Changes[0].Value.Messages[0].Type.ToUpper();
        }

        public string GetNumber(WhatsAppModel message)
        {
            // plural? si
            string numero = message.Entry[0].Changes[0].Value.Messages[0].From;
            return numero;
        }

        // public object TextMessage(string message, string number)
        // {
        //     return new
        //     {
        //         messaging_product = "whatsapp",
        //         recipient_type = "individual",
        //         to = number,
        //         type = "text",
        //         text = new { preview_url = true, body = message },
        //     };
        // }

        public object TextMessage(string message, string number)
		{
            return new
            {
                messaging_product = "whatsapp",
                to = number,
                type = "text",
                text = new
                {
                    body = message
                }
            };
        }

        public object ImageMessage(string number, string link)
        {
            return new
            {
                messaging_product = "whatsapp",
                recipient_type = "individual",
                to = number,
                type = "image",
                image = new { link = link },
            };
        }

        public object LocationMessage(string number)
        {
            return new
            {
                messaging_product = "whatsapp",
                recipient_type = "individual",
                to = number,
                type = "location",
                location = new
                {
                    latitude = "19.432608",
                    longitude = "-99.133209",
                    name = "Palacio de Bellas Artes",
                    address = "Docker",
                },
            };
        }

        
       public object ButtonMessage(string number)
{
    return new
    {
        messaging_product = "whatsapp",
        recipient_type = "individual",
        to = number,
        type = "interactive",
        interactive = new
        {
            type = "button",
            header = new
            {
                type = "text",
                text = "¡Hola! Elige una opción:"
            },
            body = new
            {
                text = "Selecciona una opción para continuar."
            },
            footer = new
            {
                text = "Gracias por tu respuesta."
            },
            action = new
            {
                buttons = new[]
                {
                    new
                    {
                        type = "reply",
                        reply = new
                        {
                            id = "button1",
                            title = "Opción 1"
                        }
                    },
                    new
                    {
                        type = "reply",
                        reply = new
                        {
                            id = "button2",
                            title = "Opción 2"
                        }
                    }
                }
            }
        }
    };
}
 



        // public object InteractiveMessage (string number, string prueba)
        // {
        //     return new
        //     {
        //         messaging_product = "whatsapp",
        //         recipient_type = "individual",
        //         to = number,
        //         type = "location",
        //         location = new
        //         {
        //             latitude = "19.432608",
        //             longitude = "-99.133209",
        //             name = "Palacio de Bellas Artes",
        //             address = prueba,
        //         },
        //     };
        // }
    }
}
