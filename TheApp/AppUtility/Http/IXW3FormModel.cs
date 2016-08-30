using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUtility.Http
{
    public interface IXW3FormModel
    {
        Dictionary<String, String> GetBody();
        string GetControllerPath();
    }
}
