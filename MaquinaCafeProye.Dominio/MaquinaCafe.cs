
using static MaquinaCafeProye.Dominio.Modelos;

namespace MaquinaCafeProye.Dominio
{
    public class MaquinaCafe
    {
        public Cafetera Cafe { get; set; }
        public Vaso VasosPequenos { get; set; }
        public Vaso VasosMedianos { get; set; }
        public Vaso VasosGrandes { get; set; }
        public Azucarero Azucar { get; set; }

        public Vaso GetTipoVaso(string tipoDeVaso)
        {
            return tipoDeVaso.ToLower() switch
            {
                "pequeno" => VasosPequenos,
                "mediano" => VasosMedianos,
                "grande" => VasosGrandes,
                _ => null
            };
        }

        public string GetVasoDeCafe(string tipoDeVaso, int cantidadDeVasos, int cantidadDeAzucar)
        {
            Vaso vasoSeleccionado = GetTipoVaso(tipoDeVaso);

            if (vasoSeleccionado == null || !vasoSeleccionado.HasVasos(cantidadDeVasos))
                return "No hay Vasos";

            int cafeNecesario = vasoSeleccionado.Contenido * cantidadDeVasos;
            if (!Cafe.HasCafe(cafeNecesario))
                return "No hay Cafe";

            if (!Azucar.HasAzucar(cantidadDeAzucar))
                return "No hay Azucar";

            vasoSeleccionado.GiveVasos(cantidadDeVasos);
            Cafe.GiveCafe(cafeNecesario);
            Azucar.GiveAzucar(cantidadDeAzucar);

            return "Felicitaciones";
        }
    }
}
