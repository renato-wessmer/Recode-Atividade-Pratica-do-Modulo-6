using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace AgenciaDeViagensNyssa.Pages.Clients
{
    public class CreateModel : PageModel
    {
        public ClientInfo clientInfo = new ClientInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            clientInfo.nome = Request.Form["nome"];
            clientInfo.cpf = Request.Form["cpf"];
            clientInfo.rg = Request.Form["rg"];
            clientInfo.email = Request.Form["email"];
            clientInfo.telefone = Request.Form["telefone"];

            if (clientInfo.nome.Length == 0 || clientInfo.cpf.Length == 0 ||
                clientInfo.rg.Length == 0 || clientInfo.email.Length == 0 ||
                clientInfo.telefone.Length == 0)
            {
                errorMessage = "Todos os campos são obrigatórios";
                return;
            }

            //Salvar novo cliente no banco de dados

            try
            {
                String connectionString = "Data Source=DESKTOP-VDGGV86;Initial Catalog=agenciadeviagensnyssa;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO cliente " +
                                 "(nome, cpf, rg, email, telefone) VALUES " +
                                 "(@nome, @cpf, @rg, @email, @telefone);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@nome", clientInfo.nome);
                        command.Parameters.AddWithValue("@cpf", clientInfo.cpf); 
                        command.Parameters.AddWithValue("@rg", clientInfo.rg);
                        command.Parameters.AddWithValue("@email", clientInfo.email);
                        command.Parameters.AddWithValue("@telefone", clientInfo.telefone);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            clientInfo.nome = ""; clientInfo.cpf = ""; clientInfo.rg = ""; clientInfo.email = ""; clientInfo.telefone = "";
            successMessage = "Novo cliente adicionado corretamente";

            Response.Redirect("/Clients/Index");
        }
    }
}
