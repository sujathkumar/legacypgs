using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LL.Solutions.PMS.DataAccess.DataModels
{
    public class UserRole
    {
        #region Properties

        public int RoleId { get; set; }
        public string Role { get; set; }
        
        public log4net.ILog Log
        {
            get
            {
                return Connection<UserRole>.log;
            }
        }
        #endregion

        #region Methods
        public UserRole GetRole(int roleId)
        {
            Connection<UserRole> conn = new Connection<UserRole>(Connection<string>.connectionString);

            try
            {
                conn.OpenConnection();
                UserRole role = conn.LoadData("SELECT Role FROM Role where RoleId = '" + roleId + "';").FirstOrDefault();
                return role;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
            finally
            {
                conn.CloseConnection();
            }
        }
        #endregion
    }
}
