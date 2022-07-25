using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Utilities
{
    public static class FileUtility
    {
        public static bool DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
