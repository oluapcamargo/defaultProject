using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V1.DefaultProject.Domain.Interfaces;
using V1.DefaultProject.Domain.ViewModels.Input.Home;
using V1.DefaultProject.Persistence.Context;
using V1.DefaultProject.Persistence.Repository.Base;

namespace V1.DefaultProject.Persistence.Repository.Home
{
    public partial class HomeRepository
    {
        public async Task<IEnumerable<Domain.Entities.Home.Home>> GetAll(ObterHomeInput input) 
        {
            var defaultSearch = !string.IsNullOrEmpty(input.TermoBusca) ? input.TermoBusca.ToUpper() : input.TermoBusca;
            return !string.IsNullOrEmpty(input.TermoBusca)? 
                await _context.Home.AsNoTracking().Where(t=>t.Desenvolvedor.Contains(defaultSearch)).ToListAsync() : await _context.Home.AsNoTracking().ToListAsync();
        }
    }
}
