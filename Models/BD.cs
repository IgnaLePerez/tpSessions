using Dapper;
using Microsoft.Data.SqlClient;


namespace tpSessions.Models
{
    public class BD
    {
        private static string _connectionString = @"Server=localhost; DataBase=tpSessions;Integrated Security=True;TrustServerCertificate=True;";

        public int iniciarSesion(string nombreUsuario, string contraseña)
        {
            int id = -1;
            string query = "SELECT id FROM Usuarios WHERE nombreUsuario = @nombreUsuario AND contraseña = @contraseña";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                id = connection.QueryFirstOrDefault<int>(query, new { nombreUsuario = nombreUsuario, contraseña = contraseña });
            }
            return id;
        }

        public Usuario MostrarUsuario(int id){
            Usuario user = null;
            string query = "SELECT * FROM Usuarios WHERE id = @id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                user = connection.QueryFirstOrDefault(query, new { id = id });
            }
            return user;
        }

        public void CrearUsuario(Usuario user){
            string query = "INSERT INTO Usuarios (nombreUsuario, contraseña, nombre, apellido, tipoUsuario) VALUES (@nombreUsuario, @contraseña, @nombre, @apellido, @tipoUsuario)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, new { nombreUsuario = user.NombreUsuario, contraseña = user.Contraseña, nombre = user.Nombre, apellido = user.Apellido, tipoUsuario = user.TipoUsuario });
            }
        }
    }
}
