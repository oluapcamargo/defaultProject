using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using V1.DefaultProject.Persistence.ModelConfiguration.Table.Usuarios;

namespace V1.DefaultProject.Persistence.ModelConfiguration.Table
{
    public static class TableConfigureExtension
    {
        public static void ApplyTableConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
        }
    }
}
