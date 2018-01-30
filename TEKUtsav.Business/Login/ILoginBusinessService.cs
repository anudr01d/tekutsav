using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEKUtsav.Business.Login
{
    public interface ILoginBusinessService
    {
        bool ValidateCredentials(string userName, string password);
    }
}
