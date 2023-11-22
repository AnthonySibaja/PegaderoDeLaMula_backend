using System.ComponentModel.DataAnnotations;

namespace PegaderoDeLaMula.Models.Dto
{
    public class TipoProductoDto
    {
        public int ID_TIPO_PRODUCTO { get; set; }

        public string TIPO_PRODUCTO { get; set; }

        public string DESCRIPCION { get; set; }
    }
}