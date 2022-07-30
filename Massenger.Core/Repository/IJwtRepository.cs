using System;
using System.Collections.Generic;
using System.Text;
using Massenger.Core.Data;

namespace Massenger.Core.Repository
{
    public interface IJwtRepository
    {
        Mass_Login Auth(Mass_Login login);
    }
}
