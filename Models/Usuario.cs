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
        */

        private string nombreUsuario;
        private string contraseña;
        private string nombre;
        private string apellido;
        private string tipoUsuario;

        public Usuario(string nombreUsuario, string contraseña, string nombre, string apellido, string tipoUsuario)
        {
            this.nombreUsuario = nombreUsuario;
            this.contraseña = contraseña;
            this.nombre = nombre;
            this.apellido = apellido;
            this.tipoUsuario = tipoUsuario;
        }
    }
}
