using Dapper;
using Microsoft.Data.SqlClient;


namespace tpSessions.Models
{
    public class BD
    {
        private static string _connectionString = @"Server=localhost; DataBase=tpSessions;Integrated Security=True;TrustServerCertificate=True;";

        public string BuscarSesion(string nombreUsuario, string contraseña)
        {
            string id = "-1";
            string query = "SELECT id FROM Usuarios WHERE nombreUsuario = @NombreUsuario AND contraseña = @Contraseña";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                if(connection.QueryFirstOrDefault<string>(query, new { NombreUsuario = nombreUsuario, Contraseña = contraseña }) != null)
                {
                    id = connection.QueryFirstOrDefault<string>(query, new { NombreUsuario = nombreUsuario, Contraseña = contraseña }).ToString();
                }
            }
            return id;
        }

        public Usuario MostrarUsuario(int id){
            Usuario user = null;
            string query = "SELECT * FROM Usuarios WHERE id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                user = connection.QueryFirstOrDefault<Usuario>(query, new { Id = id });
            }
            return user;
        }

        public void CrearUsuario(Usuario user){
            string query = "INSERT INTO Usuarios (nombreUsuario, contraseña, nombre, apellido, tipoUsuario, idGenero) VALUES (@nombreUsuario, @contraseña, @nombre, @apellido, @tipoUsuario, @idGenero)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, new { nombreUsuario = user.nombreUsuario, contraseña = user.contraseña, nombre = user.nombre, apellido = user.apellido, tipoUsuario = user.tipoUsuario, idGenero = user.idGenero });
            }
        }

        public bool ValidarNombreUsuario(string nombreUsuario){
            string query = "SELECT COUNT(nombreUsuario) FROM Usuarios WHERE nombreUsuario = @nombreUsuario";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                int count = connection.QueryFirstOrDefault<int>(query, new { nombreUsuario = nombreUsuario });
                if (count > 0)
                {
                    return false;
                }  
            }
            return true;
        }
    }
}
