using System;
using Tote.Interfaces;

namespace Tote.Models
{
    public class Message:IMessage
    {     
        
        public string Send(string message)
        {
            return "Error "+message;
        }
    }
}