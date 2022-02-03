using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using V1.DefaultProject.Domain.Entities.Home;
using V1.DefaultProject.Domain.Interfaces;
using V1.DefaultProject.Domain.ViewModels.Input.Home;

namespace V1.DefaultProject.Test.FakeRepository
{
    public class HomeFakeRepository : IHomeRepository
    {
        private readonly List<Home> _home;
        Random rnd = new Random();

        public HomeFakeRepository()
        {
            _home = new List<Home>()
            {
                new Home("Desenvolvedor " + rnd.Next(1,100))
            };
        }
        public async Task AddAsync(Home entity)
        {
            var t = Task.Run(() => _home.Add(entity));
            await t.ConfigureAwait(true);
        }

        public async Task<IEnumerable<Home>> GetAll(ObterHomeInput input)
        {
            var t = Task.Run(() => _home);
            return await t.ConfigureAwait(true);
        }

        public async Task<IEnumerable<Home>> GetAllAsync()
        {
            var t = Task.Run(() => _home);
            return await t.ConfigureAwait(true);
        }

        public async Task<Home> GetAsync(Guid id)
        {
             var t = Task.Run(() => _home.FirstOrDefault(t=>t.Codigo == id));
            return await t.ConfigureAwait(true);
        }

        public async Task RemoveByIdAsync(Guid id)
        {
            var item = _home.FirstOrDefault(t => t.Codigo == id);
            _home.Remove(item);
            item.DataDesativacao = DateTime.Now;
            var t = Task.Run(() =>  _home.Add(item));
            await t.ConfigureAwait(true);

        }

        public async Task UpdateAsync(Home entity)
        {
            var item = _home.FirstOrDefault(t => t.Codigo == entity.Codigo);
            _home.Remove(item);
            var t = Task.Run(() => _home.Add(entity));
            await t.ConfigureAwait(true);
        }
    }
}
