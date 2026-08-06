namespace tpSessions.Models
{
    public class Usuario
    {
        /*
        crea una clase "Usuario.cs" en Models en la cual hayan los siguientes atributos privados:

        nombreUsuario (string)
        contraseña (string)
        nombre (string)
        apellido (string)
        tipoUsuario (string)

        Crea el constructor de Usuario

        haz que los atributos de Usuario.cs se puedan acceder desde otros lados con getters y setters
        */

        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoUsuario { get; set; }

        public Usuario(string nombreUsuario, string contraseña, string nombre, string apellido, string tipoUsuario)
        {
            this.NombreUsuario = nombreUsuario;
            this.Contraseña = contraseña;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.TipoUsuario = tipoUsuario;
        }
    }
}
