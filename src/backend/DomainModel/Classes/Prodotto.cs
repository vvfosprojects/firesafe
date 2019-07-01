namespace DomainModel.Classes
{
    public class Prodotto : AbstractEntity
    {
        /*
         * Rappresenta l'id nel DB di DCPST
         */
        public string Prog { get; set; }

        /*
        * Rappresenta il tipo dell'oggetto 
        */
        //public Tipo Tipo { get; set; }

        /*
         * Rappresenta il nome della ditta proprietaria del prodotto
         */
        public string Ditta { get; set; }

        /*
         * Rappresenta il nome commerciale del prodotto
         */
        public string DenominazioneCommerciale { get; set; }

        /*
         * Rappresenta la classe di appartenza del prodotto
         */
        //public Classe Classe { get; set; }

        /*
         * Rappresenta il codice di omologazione del prodotto
         */
        public string CodiceOmol { get; set; }

        /*
         * Rappresenta la categoria (impiego) associata al prodotto
         */
        public string Impiego { get; set; }
        /// <summary>
        /// La categora del prodotto
        /// </summary>
        public string MacroGruppo { get; set; }

        /*
         * Rappresenta il macrogruppo associato al prodotto
         */
        //public Macrogruppo Macrogruppo { get; set; }

        /*
         * Rappresenta la data in cui ???
         */
        //public Date Firma { get; set; }

        /*
         * Rappresenta la data di scadenza dell'omologazione associata al prodotto
         */
        //public Date Scadenza { get; set; }
    }
}
