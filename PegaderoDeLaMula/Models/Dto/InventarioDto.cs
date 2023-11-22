using System.ComponentModel.DataAnnotations;

namespace PegaderoDeLaMula.Models
{
    public class InventarioDto
    {
        public int ID_PRODUCTO { get; set; }
 
        public string NOMBRE { get; set; }

        public int CANTIDAD { get; set; }

        public int PESO { get; set; }

        public int FK_ID_NUMERO_PRODUCTO { get; set; }
    }
}