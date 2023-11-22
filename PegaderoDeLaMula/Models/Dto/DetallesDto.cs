using System.ComponentModel.DataAnnotations;

namespace PegaderoDeLaMula.Models
{
    public class DetallesDto
    {
        public int NUMERO_PRODUCTO { get; set; }

        public int UNIDADES { get; set; }

        public int PRECIOXUNIDAD { get; set; }

        public int PK_ID_TIPO_PRODUCTO { get; set; }
    }
}