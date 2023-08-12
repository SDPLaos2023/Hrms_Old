using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.files
{
    interface FileUpload
    {
        string avatar(string path);
        bool files(string path);

    }
}
