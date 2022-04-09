namespace EmployeeManagement.Helper
{
    public class EmployeeAPI
    {
        public HttpClient Initial()
        {
            var Client=new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:44327");
            return Client;
        }
    }
}
