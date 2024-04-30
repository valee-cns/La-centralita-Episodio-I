using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaCentralita
{
    public enum TipoLlamada
    {
        Local,
        Provincial,
        Todas
    }

    public class Llamada
    {
        protected float _duracion;
        protected string _nroDestino;
        protected string _nroOrigen;

        public Llamada(string nroOrigen, float duracion, string nroDestino)
        {
            this._duracion = duracion;
            this._nroDestino = nroDestino;
            this._nroOrigen = nroOrigen;
        }

        public float Duracion
        {
            get { return _duracion; }
        }
        public string NroDestino
        {
            get { return _nroDestino; }
        }

        public string NroOrigen
        {
            get { return _nroOrigen; }
        }

        public static int OrdenarPorDuracion(Llamada llamada1, Llamada llamada2)
        {
            if(llamada1.Duracion > llamada2.Duracion)
            {
                return -1;
            }

            else
            {
                return 0;
            }

        }

        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("La llamada duró: {0}\nEl destino era: {1}\nEl origen era: {2}\n", Duracion, NroDestino, NroOrigen);

            return sb.ToString();
        }

        
    }
}
