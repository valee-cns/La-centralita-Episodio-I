using System.Text;

namespace LaCentralita
{
    public class Centralita
    {
        private List<Llamada> ListaDeLlamadas;
        protected string RazonSocial;

        public float GanaciaPorLocal 
        {
            get
            {
                return CalcularGanancia(TipoLlamada.Local);
            } 
        }
        public float GanaciaPorProvincial
        {
            get
            {
                return CalcularGanancia(TipoLlamada.Provincial);
            }
        }
        public float GanaciaPorTotal
        {
            get
            {
                return CalcularGanancia(TipoLlamada.Todas);
            }
        }

        public List<Llamada> Llamadas
        {
            get
            {
                return this.ListaDeLlamadas;
            }
        }

        public Centralita()
        { }

        public Centralita(string nombreEmpresa) 
        {
            this.RazonSocial = nombreEmpresa;
            this.ListaDeLlamadas = new List<Llamada>();
        }

        private float CalcularGanancia(TipoLlamada tipo)
        {
            float gananciaLocal = 0;
            float gananciaProvincial = 0;

            foreach (var llamada in ListaDeLlamadas)
            {
                if (llamada is Local)
                {
                    gananciaLocal += ((Local)llamada).CostoLlamada;
                }

                
                if(llamada is Provincial)
                {
                    gananciaProvincial += ((Provincial)llamada).CostoLlamada;
                }
                
            }

            if(tipo == TipoLlamada.Local)
            {
                return gananciaLocal;
            }

            else if(tipo == TipoLlamada.Provincial)
            {
                return gananciaProvincial;
            }

            else
            {
                return gananciaLocal + gananciaProvincial;
            }
        }

        public void OrdenarLlamadas()
        {
            ListaDeLlamadas.Sort(Llamada.OrdenarPorDuracion);
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\n----------------------------------\n");

            sb.AppendFormat("Empresa: {0}\nGanancia total: {1}\nGanancia por llamados locales: {2}\nGanancia por llamados provinciales: {3}\n", this.RazonSocial, GanaciaPorTotal, GanaciaPorLocal, GanaciaPorProvincial);

            sb.AppendLine("\n|||Llamadas Realizadas|||\n");

            foreach (var llamada in Llamadas)
            {
                sb.AppendLine(llamada.Mostrar());
            }

            sb.AppendLine("\n|||Fin del historial de llamadas|||\n\n----------------------------------");

            return sb.ToString();
        }
            
    }
}
