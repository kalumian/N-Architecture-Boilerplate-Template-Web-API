using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Layer.Exceptions
{
    public class AuthorizationException(string message) : HttpException(403, message)
    {
    }
}
