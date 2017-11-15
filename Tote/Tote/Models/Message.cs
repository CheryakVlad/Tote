using System;
using Tote.Interfaces;

namespace Tote.Models
{
    public class Message:IMessage
    {     
        
        public string Send()
        {
            return "Interface Message Text";
        }
    }
}