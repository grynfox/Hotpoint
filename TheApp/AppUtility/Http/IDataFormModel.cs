using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLabs.Platform.Services.Media;

namespace AppUtility.Http
{
    public interface IDataFormModel : IXW3FormModel
    {
        Dictionary<String, MediaFile> GetBinaryBody();
    }
}
