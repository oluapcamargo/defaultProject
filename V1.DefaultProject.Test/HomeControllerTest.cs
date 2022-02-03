using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using V1.DefaultProject.Domain.Interfaces;
using V1.DefaultProject.Domain.ViewModels.Input.Home;

namespace V1.DefaultProject.Test
{
    public class HomeControllerTest
    {
        private readonly IHomeRepository _repository;

        public HomeControllerTest() 
        {
            _repository = new FakeRepository.HomeFakeRepository();
        }
        [Test]
        public async Task CadastrarHome() 
        {
            Domain.Entities.Home.Home  input = new Domain.Entities.Home.Home("Usuario Testes");
            await _repository.AddAsync(input);
            Assert.IsTrue(true);
        }
        [Test]
        public async Task ObterTodosHome()
        {
            ObterHomeInput filter = new ObterHomeInput();
            var okResult = await _repository.GetAll(filter);
            Assert.IsTrue(okResult.Any());
        }

        [Test]
        public async Task ObterById()
        {
            ObterHomeInput filter = new ObterHomeInput();
            var registro =  await _repository.GetAll(filter);
            var okResult = await _repository.GetAsync(registro.First().Codigo);
            Assert.IsTrue(okResult.DataCriacao != (DateTime?)null? true : false);
        }

        [Test]
        public async Task Desativar()
        {
            ObterHomeInput filter = new ObterHomeInput();
            var registro = await _repository.GetAll(filter);
            await _repository.RemoveByIdAsync(registro.First().Codigo);
            Assert.IsTrue(true);
        }
        [Test]
        public async Task Update()
        {
            ObterHomeInput filter = new ObterHomeInput();
            var registro = await _repository.GetAll(filter);
            var item = registro.First();
            item.Desenvolvedor += " / Update Metodos;";
            await _repository.UpdateAsync(item);
            Assert.IsTrue(true);
        }
    }
}
