using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LL.Solutions.PMS.Service
{
    public static class Constants
    {
        internal static readonly string UDP = "UDP";
        internal static readonly string SSH = "SSH";
        internal static readonly string SCP = "SCP";
        internal static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    }
}
