using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace AgenciaDeViagensNyssa.Pages.Clients
{
    public class EditModel : PageModel
    { 
        public ClientInfo clientInfo = new ClientInfo();
        public String errorMessage = "";
        public String successMessage = "";
    
        public void OnGet()
        {
            String id = Request.Query["id"];

            try
            {
                String connectionString = "Data Source=DESKTOP-VDGGV86;Initial Catalog=agenciadeviagensnyssa;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();  
                    String sql = "SELECT * FROM cliente WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                clientInfo.id = "" + reader.GetInt32(0);
                                clientInfo.nome = reader.GetString(1);
                                clientInfo.cpf = reader.GetString(2);
                                clientInfo.rg = reader.GetString(3);
                                clientInfo.email = reader.GetString(4);
                                clientInfo.telefone = reader.GetString(5);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;  
            }
        }

        public void OnPost()
        {
            clientInfo.id = Request.Form["id"];
            clientInfo.nome = Request.Form["nome"];
            clientInfo.cpf = Request.Form["cpf"];
            clientInfo.rg = Request.Form["rg"];
            clientInfo.email = Request.Form["email"];
            clientInfo.telefone = Request.Form["telefone"];

            if (clientInfo.id.Length == 0 || clientInfo.nome.Length == 0 || 
                clientInfo.cpf.Length == 0 || clientInfo.rg.Length == 0 || 
                clientInfo.email.Length == 0 || clientInfo.telefone.Length == 0)
            {
                errorMessage = "Todos os campos são obrigatórios";
                return;
            }

            try
            {
                String connectionString = "Data Source=DESKTOP-VDGGV86;Initial Catalog=agenciadeviagensnyssa;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE cliente" +
                                 " SET nome=@nome, cpf=@cpf, rg=@rg, email=@email, telefone=@telefone " +
                                 "WHERE id=@id";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@nome", clientInfo.nome);
                        command.Parameters.AddWithValue("@cpf", clientInfo.cpf);
                        command.Parameters.AddWithValue("@rg", clientInfo.rg);
                        command.Parameters.AddWithValue("@email", clientInfo.email);
                        command.Parameters.AddWithValue("@telefone", clientInfo.telefone);
                        command.Parameters.AddWithValue("@id", clientInfo.id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage=ex.Message;
                return;
            }

            Response.Redirect("/Clients/Index");
        }
    }
}
