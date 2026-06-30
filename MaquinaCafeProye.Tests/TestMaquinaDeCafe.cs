
using MaquinaCafeProye.Dominio;
using static MaquinaCafeProye.Dominio.Modelos;

namespace MaquinaCafeProye.Tests
{
    [TestFixture]
    public class TestMaquinaDeCafe
    {
        private MaquinaCafe _maquinaCafe;

        [SetUp]
        public void Setup()
        {
            _maquinaCafe = new MaquinaCafe
            {
                Cafe = new Cafetera(50),
                VasosPequenos = new Vaso(10, 3),
                VasosMedianos = new Vaso(10, 5),
                VasosGrandes = new Vaso(10, 7),
                Azucar = new Azucarero(20)
            };
        }

        [Test]
        public void DeberiaDevolverUnVasoPequeno()
        {
            Vaso vaso = _maquinaCafe.GetTipoVaso("pequeno");
            Assert.That(vaso, Is.EqualTo(_maquinaCafe.VasosPequenos));
        }

        [Test]
        public void DeberiaDevolverUnVasoMediano()
        {
            Vaso vaso = _maquinaCafe.GetTipoVaso("mediano");
            Assert.That(vaso, Is.EqualTo(_maquinaCafe.VasosMedianos));
        }

        [Test]
        public void DeberiaDevolverUnVasoGrande()
        {
            Vaso vaso = _maquinaCafe.GetTipoVaso("grande");
            Assert.That(vaso, Is.EqualTo(_maquinaCafe.VasosGrandes));
        }

        [Test]
        public void DeberiaDevolverNoHayVasos()
        {
            _maquinaCafe.VasosPequenos.CantidadVasos = 0;
            string resultado = _maquinaCafe.GetVasoDeCafe("pequeno", 1, 2);
            Assert.That(resultado, Is.EqualTo("No hay Vasos"));
        }

        [Test]
        public void DeberiaDevolverNoHayCafe()
        {
            _maquinaCafe.Cafe.CantidadCafe = 0;
            string resultado = _maquinaCafe.GetVasoDeCafe("pequeno", 1, 2);
            Assert.That(resultado, Is.EqualTo("No hay Cafe"));
        }

        [Test]
        public void DeberiaDevolverNoHayAzucar()
        {
            _maquinaCafe.Azucar.CantidadDeAzucar = 0;
            string resultado = _maquinaCafe.GetVasoDeCafe("pequeno", 1, 5);
            Assert.That(resultado, Is.EqualTo("No hay Azucar"));
        }

        [Test]
        public void DeberiaRestarCafe()
        {
            _maquinaCafe.GetVasoDeCafe("pequeno", 1, 2);
            Assert.That(_maquinaCafe.Cafe.CantidadCafe, Is.EqualTo(47));
        }

        [Test]
        public void DeberiaRestarVasoYAzucar()
        {
            _maquinaCafe.GetVasoDeCafe("pequeno", 1, 3);
            Assert.That(_maquinaCafe.VasosPequenos.CantidadVasos, Is.EqualTo(9));
            Assert.That(_maquinaCafe.Azucar.CantidadDeAzucar, Is.EqualTo(17));
        }
    }
}
