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
        [Fact]
        public void insert_imobilizado_computador()
        {
            Mock<IImobilizadoRepository> imobilizadoRepository = new Mock<IImobilizadoRepository>();
            ImobilizadoService imobilizadoService = new ImobilizadoService(imobilizadoRepository.Object);

            imobilizadoRepository
                .Setup(i => i.Add(It.IsAny<Computador>()));

            var computador = new Computador {
                Nome = "Computador Sala 1",
                Andar = AndarEnum.PrimeiroAndar,
                Id = ""
            };
            imobilizadoService.Add(computador);

            Assert.NotEqual(computador.Id, "");
        }
        //[Fact]
        //public void update_imobilizado_computador()
        //{
        //    Mock<IImobilizadoRepository> imobilizadoRepository = new Mock<IImobilizadoRepository>();
        //    ImobilizadoService imobilizadoService = new ImobilizadoService(imobilizadoRepository.Object);

        //    var guid = Guid.NewGuid().ToString();

        //    var computador = new Computador {
        //        Id = guid,
        //        Nome = "Computador Sala 1"
        //    };

        //    //imobilizadoRepository
        //    //    .Setup(i => i.Add(It.IsAny<Computador>()))
        //    //    .Callback((Computador cp) => cp.);

        //    var computadorAlterado = new Computador
        //    {
        //        Nome = "Computador Sala 2",
        //        Andar = AndarEnum.PrimeiroAndar,
        //        Id = guid
        //    };
        //    imobilizadoService.Update(computadorAlterado);
        //    //var c = imobilizadoService.Get<Computador>(cp => cp.Id == guid).FirstOrDefault();

        //    Assert.NotEqual(computador.Id, "");
        //}
    }
}
