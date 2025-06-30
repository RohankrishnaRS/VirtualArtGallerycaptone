using System.Data.SqlClient;
using System.Configuration;

namespace VirtualArtGallery.Util
{
    public class DBConnUtil
    {
        // ✅ This method MUST always return a NEW SqlConnection object.
        public static SqlConnection GetConnection()
        {
            string connectionString = DBPropertyUtil.GetConnectionString();
            return new SqlConnection(connectionString); // ✅ Always new connection
        }
    }
}
