using V1.DefaultProject.Domain.Interfaces;
using V1.DefaultProject.Persistence.Context;
using V1.DefaultProject.Persistence.Repository.Base;

namespace V1.DefaultProject.Persistence.Repository.Usuario
{
    public partial class UsuarioRepository : BaseRepository<Domain.Entities.Usuario>, IUsuarioRepository
    {
        public V1DefaultProjectContext _context => DatabaseContext as V1DefaultProjectContext;
        public UsuarioRepository(V1DefaultProjectContext context) : base(context) { }
    }
}
