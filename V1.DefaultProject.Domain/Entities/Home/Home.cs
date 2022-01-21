using System;
using System.Collections.Generic;
using System.Text;

namespace V1.DefaultProject.Domain.Entities.Home
{
    public class Home
    {
        public Guid Codigo { set; get; }
        public string Desenvolvedor { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataDesativacao { get; set; }


        public Home(string desenvolvedor) 
        {
            Codigo = Guid.NewGuid();
            Desenvolvedor = desenvolvedor;
            DataCriacao = DateTime.Now;
        }

        public void Desativar() 
        {
            DataDesativacao = DateTime.Now;
        }
    }
}
