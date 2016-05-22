using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LL.Solutions.PMS.Service
{
    public class ControllerService : IService
    {
        #region Properties
        public IList<string> Controllers { get; set; }

        /// <summary>
        /// DisplayName
        /// </summary>
        public string DisplayName
        {
            get
            {
                return "Controller Service";
            }
        } 
        #endregion
    }
}
