using System;
using System.Collections.Generic;
using System.Text;
using Massenger.Core.DTO;

namespace Massenger.Core.Service
{
   public  interface IEmailservice
    {
        public string GetEmail(emailmessage mes);
    }
}
