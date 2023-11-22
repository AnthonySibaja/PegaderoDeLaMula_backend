using System.ComponentModel.DataAnnotations;

namespace PegaderoDeLaMula.Models.Dto
{
    public class ClienteDto
    {
        public int ID_CLIENTE { get; set; }

        public string NOMBRE { get; set; }

        public string APELLIDOS { get; set; }

        public int CEDULA { get; set; }

        public string EMAIL { get; set; }

        public string DIRECCION { get; set; }

        public int ZIP { get; set; }
    }
}
