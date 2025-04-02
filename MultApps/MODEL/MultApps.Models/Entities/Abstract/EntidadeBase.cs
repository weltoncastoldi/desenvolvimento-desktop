using System;
using MultApps.Models.Enums;

namespace MultApps.Models.Entities.Abstract
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public StatusEnum Status { get; set; }
    }
}
