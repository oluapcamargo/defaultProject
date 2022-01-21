using System;
using System.Collections.Generic;
using System.Text;
using V1.DefaultProject.Domain.Entities.Base;

namespace V1.DefaultProject.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
    }
}
