

namespace Fatec_2026_DFS.Models
{
    public class Sensor 
    {
        public string Nome { get; set; }
        public bool SensorChama { get; set; }
        public bool SensorGas { get; set; }

        public static List<Sensor> Lista
        {
            get
            {
              
                var lista = new List<Sensor>
                {

                    new () { Nome = "Quarto", SensorChama = true, SensorGas = false },
                    new () { Nome = "Cozinha", SensorChama = false, SensorGas = true },
                    new () { Nome = "Sala", SensorChama = true, SensorGas = true }
                };
                return lista;
            }
        }
    }
}
