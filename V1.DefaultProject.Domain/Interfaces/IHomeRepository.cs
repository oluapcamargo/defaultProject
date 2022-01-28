using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using V1.DefaultProject.Domain.Entities;
using V1.DefaultProject.Domain.Interfaces.Base;
using V1.DefaultProject.Domain.ViewModels.Input.Home;

namespace V1.DefaultProject.Domain.Interfaces
{
    public interface IHomeRepository : IBaseRepository<Entities.Home.Home>
    {
        Task<IEnumerable<Domain.Entities.Home.Home>> GetAll(ObterHomeInput input);
    }
}
