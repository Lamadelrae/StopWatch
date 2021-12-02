using System.Data.SqlClient;

namespace StopWatch.Infra.Data
{
    public static class Connection
    {
        public static SqlConnection Get()
        {
            return new SqlConnection("Server=Localhost\\SQL2019;Database=StopWatch;User Id=sa;Password=pass;");
        }
    }
}
