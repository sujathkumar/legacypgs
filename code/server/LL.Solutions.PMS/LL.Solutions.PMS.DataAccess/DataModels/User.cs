using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LL.Solutions.PMS.DataAccess.DataModels
{
    public class User
    {
        #region Properties

        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        
        public log4net.ILog Log
        {
            get
            {
                return Connection<User>.log;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// GetUser
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User GetUser(string name, string password)
        {
            Connection<User> conn = new Connection<User>(Connection<string>.connectionString);

            try
            {
                conn.OpenConnection();
                User user = conn.LoadData("SELECT * FROM User where UserName = '" + name +  "' and Password = '" + password + "';").FirstOrDefault();
                user.Role = new UserRole().GetRole(user.RoleId).Role;
                return user;
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
