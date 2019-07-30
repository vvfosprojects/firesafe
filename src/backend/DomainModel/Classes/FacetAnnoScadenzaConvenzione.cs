using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Classes
{
    public class FacetAnnoScadenzaConvenzione
    {
        /// <summary>
        /// Rappresenta l'anno in cui l'omologazione di un prodotto scade
        /// </summary>
        public int Anno { get; set; }

        /// <summary>
        /// Rappresenta il numero di prodotti la cui omologazione scadrà nell'anno indicato dalla proprietà Anno
        /// </summary>
        public int Count { get; set; }
    }
}
