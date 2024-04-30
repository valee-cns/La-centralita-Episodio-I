using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaCentralita
{
    public class Provincial : Llamada
    {
        protected Franja FranjaHoraria;

        public float CostoLlamada 
        {
            get
            {
                return CalcularCosto();
            }
        }

        public Provincial(Franja miFranja, Llamada llamada) : base("", 0, "")
        {
            this.FranjaHoraria = miFranja;
        }

        public Provincial(string origen, Franja miFranja, float duracion, string destino) : base(origen, duracion, destino)
        {
            this.FranjaHoraria = miFranja;
        }

        private float CalcularCosto()
        {
            float costo = 0;

            if (this.FranjaHoraria == Franja.Franja_1)
            {
                costo = (float)(0.99 * base.Duracion);
            }


            if(this.FranjaHoraria == Franja.Franja_2)
            {
                costo = (float)(1.25 * base.Duracion);
            }


            if(this.FranjaHoraria == Franja.Franja_3)
            {
                costo = (float)(0.66 * base.Duracion);
            }

            return costo;
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0}\n--La llamada fue Provincial--\n\nDatos de la llamada provincial:\nEl costo de la llamada Provincial fué: {1}\nLa franja horaria fué: {2}", base.Mostrar(), CostoLlamada, this.FranjaHoraria);
            
            return sb.ToString();
        }

        public enum Franja
        {
            Franja_1,
            Franja_2,
            Franja_3
        }
    }
}
