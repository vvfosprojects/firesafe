using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Classes
{
    public class FacetAnnoFirmaConvenzione
    {
        /// <summary>
        /// Rappresenta l'anno in cui un prodotto è stato omologato
        /// </summary>
        public int Anno { get; set; }

        /// <summary>
        /// Rappresenta il numero di prodotti omologati nell'anno indicato dalla proprietà Anno
        /// </summary>
        public int Count { get; set; }
    }
}
