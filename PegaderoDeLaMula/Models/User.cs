using System.ComponentModel.DataAnnotations;

namespace PegaderoDeLaMula.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string USUARIO { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string NOMBRE { get; set; }

        public string APELLIDOS { get; set; }

        public int CEDULA { get; set; }

        public string EMAIL { get; set; }

        public string DIRECCION { get; set; }

        public int ZIP { get; set; }
    }
}
