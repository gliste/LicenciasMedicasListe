﻿using System;
using System.Collections.Generic;
using LicenciasMedicasGL.Helpers;
using System.ComponentModel.DataAnnotations;

namespace LicenciasMedicasGL.Models
{
    public class Medico : Persona
    {
        [Required (ErrorMessage = ErrorMsg.MsgRequerido)]
        [StringLength(12, MinimumLength = 1, ErrorMessage = ErrorMsg.MsgRango)]
        public string Matricula { get; set; }

        [Display(Name = "Id Prestadora")]
        public int PestadoraId { get; set; } 
                       
        public Prestadora Prestadora { get; set; }

        [Display(Name = "Id Licencia")]
        public int LicenciaId { get; set; }

        //public List<Licencia> Licencias { get; set; } Medico hereda de Persona, que ya tiene Licencias

    }

}
