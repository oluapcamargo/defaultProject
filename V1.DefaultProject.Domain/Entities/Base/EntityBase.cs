using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace V1.DefaultProject.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Codigo { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        protected EntityBase()
        {
            Codigo = Guid.NewGuid();
            DataRegistro = DateTime.Now;
            DataUltimaAtualizacao = DateTime.Now;

        }
    }
}
