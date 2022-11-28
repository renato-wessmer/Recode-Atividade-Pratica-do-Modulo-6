using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace AgenciaDeViagensNyssa.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> listClients = new List<ClientInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=DESKTOP-VDGGV86;Initial Catalog=agenciadeviagensnyssa;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM cliente";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id = "" + reader.GetInt32(0);
                                clientInfo.nome = reader.GetString(1);
                                clientInfo.cpf = reader.GetString(2);
                                clientInfo.rg = reader.GetString(3);
                                clientInfo.email = reader.GetString(4);
                                clientInfo.telefone = reader.GetString(5);
                                clientInfo.created_at = reader.GetDateTime(6).ToString();

                                listClients.Add(clientInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class ClientInfo
    {
        public String id;
        public String nome;
        public String cpf;
        public String rg;
        public String email;
        public String telefone;
        public String created_at;
    }

}
