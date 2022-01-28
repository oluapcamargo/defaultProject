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
        public DateTime DataDesativacao { get; set; }


        public Usuario(string nome, string documento, string email)
        {
            Codigo = Guid.NewGuid();
            Nome = nome;
            Documento = documento;
            Email = email;
            DataRegistro = DateTime.Now;
        }

        public void Desativar()
        {
            DataDesativacao = DateTime.Now;
        }
    }
}
