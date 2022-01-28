using V1.DefaultProject.Domain.Interfaces;
using V1.DefaultProject.Persistence.Context;
using V1.DefaultProject.Persistence.Repository.Base;

namespace V1.DefaultProject.Persistence.Repository.Home
{
    public partial class HomeRepository: BaseRepository<Domain.Entities.Home.Home>, IHomeRepository
    {
        public V1DefaultProjectContext _context => DatabaseContext as V1DefaultProjectContext;
        public HomeRepository (V1DefaultProjectContext context) : base(context) { }
    }
}
