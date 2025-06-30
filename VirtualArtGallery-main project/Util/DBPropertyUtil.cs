using System.Configuration;

namespace VirtualArtGallery.Util
{
    public class DBPropertyUtil
    {
        // Reads the connection string from app.config
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        }
    }
}
