﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Web.Aluno.Models
{
    public class ClienteModel
    {
        public int ClienteId { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Observacao { get; set; }

        public int RepresentanteId { get; set; }
        public RepresentanteModel? Representante { get; set; }
    }
}