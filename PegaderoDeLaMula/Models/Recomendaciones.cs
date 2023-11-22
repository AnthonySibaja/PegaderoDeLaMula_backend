using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace PegaderoDeLaMula.Models
{
    public class Recomendaciones
    {
        [Key]
        public int ID_RECOMENDACIONES { get; set; }

        public string DESCRIPCION { get; set; }

        public DateTime FECHA { get; set;}

        public int FK_ID_USUARIO { get; set; }

    }
}