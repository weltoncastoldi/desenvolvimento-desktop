using System;
using System.Runtime.CompilerServices;
using MultApps.Models.Entities.Abstract;

namespace MultApps.Models.Entities
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataUltimoAcesso { get; set; }
    }
}
