using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr3
{
    /// <summary>
    /// Запрашиваемая информация о городе
    /// </summary>
    public class WeatherResponse
    {
        /// <summary>
        /// Температура
        /// </summary>
        public Temperature Main { get; set; }
        
        /// <summary>
        /// Рассвет и закат
        /// </summary>
        public Sun Sys { get; set; }
    }
}
