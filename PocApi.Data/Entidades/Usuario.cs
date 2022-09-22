using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PocApi.Data.Entidades
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string EMail { get; set; }
        public bool Ativo { get; set; }
        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }
    }
}
