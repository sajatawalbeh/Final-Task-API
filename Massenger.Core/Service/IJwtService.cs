using System;
using System.Collections.Generic;
using System.Text;
using Massenger.Core.Data;

namespace Massenger.Core.Service
{
   public interface IJwtService
    {
        string Auth(Mass_Login login);
    }
}
