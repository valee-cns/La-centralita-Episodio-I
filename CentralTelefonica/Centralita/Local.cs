using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaCentralita
{
    public class Local : Llamada
    {
        protected float Costo;

        public float CostoLlamada 
        {
            get
            {
                return CalcularCosto();
            } 
        }

        public Local(float costo, Llamada llamada) : base("", 0, "")
        {
            this.Costo = costo;
        }

        public Local(string origen, float duracion, string destino, float costo) : base(origen, duracion, destino)
        {
            this.Costo = costo;
        }

        private float CalcularCosto()
        {
            float costoDeLaLlamada = this.Costo * base.Duracion;

            return costoDeLaLlamada;
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0}\n--La llamada fue Local--\n\nDatos de la llamada local:\nEl costo de la llamada Local fué: {1}\n", base.Mostrar(), CostoLlamada);

            return sb.ToString();
        }
    }
}
