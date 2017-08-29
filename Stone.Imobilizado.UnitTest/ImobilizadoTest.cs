using Moq;
using Stone.Imobilizado.Repository;
using Stone.Imobilizado.Repository.Model;
using Stone.Imobilizado.Repository.Model.Enum;
using Stone.Imobilizado.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Stone.Imobilizado.UnitTest
{
    public class ImobilizadoTest
    {
        Mock<IImobilizadoRepository> _imobilizadoRepository;
        ImobilizadoService _imobilizadoService;
        public ImobilizadoTest()
        {
            _imobilizadoRepository = new Mock<IImobilizadoRepository>();
            _imobilizadoService = new ImobilizadoService(_imobilizadoRepository.Object);
        }
        [Fact]
        public void insert_imobilizado_computador()
        {
            _imobilizadoRepository
                .Setup(i => i.Add(It.IsAny<ComputadorModel>()));

            var computador = new ComputadorModel
            {
                Nome = "Computador Sala 1",
                Andar = new AndarModel(),
                Id = ""
            };
            _imobilizadoService.Add(computador);

            Assert.NotEqual(computador.Id, "");
        }
        [Fact]
        public void get_all_imobilizado_computador()
        {
            var listaMock = new List<ComputadorModel>();

            listaMock.Add(new ComputadorModel { Id = Guid.NewGuid().ToString(), Nome = "Computador 1" });
            listaMock.Add(new ComputadorModel { Id = Guid.NewGuid().ToString(), Nome = "Computador 2" });
            listaMock.Add(new ComputadorModel { Id = Guid.NewGuid().ToString(), Nome = "Computador 3" });

            _imobilizadoRepository
                .Setup(i => i.Get<ComputadorModel>(t => true))
                .Returns(listaMock);


            var listaRetorno = _imobilizadoService.GetAll<ComputadorModel>();

            Assert.Equal(listaMock.Count, listaRetorno.Count);
            Assert.Equal(listaMock, listaRetorno);
        }

        [Fact]
        public void get_by_id_imobilizado_computador()
        {
            var id = Guid.NewGuid().ToString();
            var computador = new ComputadorModel { Id = id, Nome = "Computador 1" };
            
            _imobilizadoRepository
                .Setup(i => i.GetById<ComputadorModel>(id))
                .Returns(computador);

            var computadorRetorno = _imobilizadoService.GetById<ComputadorModel>(id);

            Assert.Equal(computadorRetorno.Id, id);
            Assert.Equal(computadorRetorno.Nome, "Computador 1");
        }
    }
}
