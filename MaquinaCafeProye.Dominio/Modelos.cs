namespace MaquinaCafeProye.Dominio
{
    public class Modelos
    {
        public class Vaso
        {
            public int CantidadVasos { get; set; }
            public int Contenido { get; set; }

            public Vaso(int cantidadVasos, int contenido)
            {
                CantidadVasos = cantidadVasos;
                Contenido = contenido;
            }

            public bool HasVasos(int cantidad) => CantidadVasos >= cantidad;
            public void GiveVasos(int cantidad) => CantidadVasos -= cantidad;
        }

        public class Cafetera
        {
            public int CantidadCafe { get; set; }

            public Cafetera(int cantidadCafe)
            {
                CantidadCafe = cantidadCafe;
            }

            public bool HasCafe(int cantidad) => CantidadCafe >= cantidad;
            public void GiveCafe(int cantidad) => CantidadCafe -= cantidad;
        }

        public class Azucarero
        {
            public int CantidadDeAzucar { get; set; }

            public Azucarero(int cantidadDeAzucar)
            {
                CantidadDeAzucar = cantidadDeAzucar;
            }

            public bool HasAzucar(int cantidad) => CantidadDeAzucar >= cantidad;
            public void GiveAzucar(int cantidad) => CantidadDeAzucar -= cantidad;
        }
    }
}
