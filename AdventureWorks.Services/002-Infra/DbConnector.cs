using AdventureWorks.Services._001_Domain;



namespace AdventureWorks.Services._002_Infra
{
    public class DbConnector
    {
        public AuthenticationResult Authenticate(decimal mobileNumber, string password)
        {

            //var connectionstring = "Server=tcp:adventureworksdatabase.database.windows.net,1433;Database=AdventureWorks.Db;User ID=cvihite@adventureworksdatabase;Password=Adventure123!;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            //SqlConnection connection = new SqlConnection(connectionstring);
            //try
            //{
            //    connection.Open();
            //    SqlCommand command = new SqlCommand("select * from users");
            //    DataSet ds = new DataSet();
            //    SqlDataAdapter adapter = new SqlDataAdapter(command);
            //    adapter.Fill(ds);
            
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            //finally {
            //    connection.Close();
            //}

            return new AuthenticationResult();

        }
    }
}
