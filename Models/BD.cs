namespace tpSessions.Models
{
    public class BD
    {
        /*
        Tambien en la mima carpeta crea una clase BD.cs sin métodos ni atributos
        */

        private static string _connectionString = @"Server=localhost; DataBase=tpSessions;Integrated Security=True;TrustServerCertificate=True;";

        public int iniciarSesion(string nombreUsuario, string contraseña)
        {
            int id = -1;
            string query = "SELECT * FROM Usuarios WHERE nombreUsuario = @nombreUsuario AND contraseña = @contraseña";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                id = connection.QueryFirstOrDefault<int>(query, new { nombreUsuario, contraseña });
            }
            return id;
        }

        
    }
}
