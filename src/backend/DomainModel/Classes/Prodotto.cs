using System;

namespace DomainModel.Classes
{
    public class Prodotto : AbstractEntity
    {
        public string Id { get; protected set; }

        /*
         * Rappresenta l'id nel DB di DCPST
         */
        public string Prog { get; set; }

        /*
        * Rappresenta il tipo dell'oggetto
        */
        public Tipo Tipo { get; set; }

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
        public Classe Classe { get; set; }

        /*
         * Rappresenta il codice di omologazione del prodotto
         */
        public string CodiceOmol { get; set; }

        /*
         * Rappresenta la categoria (impiego) associata al prodotto
         */
        public string Impiego { get; set; }

        /// <summary>
        ///Il metodo ricerca la chiave passata prima per corrispondenza esatta nei campi DenominazioneCommerciale, Impiego e Macrogruppo;
        /// se viene trovata la corrispondenza viene ritornato un intero che vuole indicare quanto efficace sia stata la ricerca
        /// Nel caso in cui non venisse trovata alcuna corrispondenza esatta, viene effettuata una ricerca per corrispondenza parziale
        /// </summary>

        public int ScoreBySearchKey(string key)
        {
            string toLower = key.ToLower();
            int score = 0;

            //se la Key è uguale alla DenominazioneCommerciale allora lo score ha peso +3
            if (toLower == DenominazioneCommerciale.ToLower())
            {
                score += 2;
            }

            if (DenominazioneCommerciale.ToLower().Contains(toLower))
            {
                score += 1;
            }

            //se la Key è uguale ad Impiego o Macrogruppo allora lo score ha peso +2
            if (toLower == Impiego.ToLower() || toLower == MacroGruppo.ToLower())
            {
                return 2;
            }
            //se la Key è parzialmente contenuta in uno dei campi DenominazioneCommerciale, Impiego o MacroGruppo allora lo score ha peso 1
            else if (DenominazioneCommerciale.ToLower().Contains(toLower) || Impiego.ToLower().Contains(toLower) || MacroGruppo.ToLower().Contains(toLower))
            {
                return 1;
            }
            //altrimenti non è stato riscontrato alcun match quindi ho peso 0
            return 0;
        }

        /// <summary>
        ///   La categora del prodotto (la differenza con Impiego è che questo campo presenta dei
        ///   raggruppamenti di record Impiego
        /// </summary>
        public string MacroGruppo { get; set; }

        /// <summary>
        ///   Rappresenta la data in cui ???
        /// </summary>
        public DateTime Firma { get; set; }

        /*
         * Rappresenta la data di scadenza dell'omologazione associata al prodotto
         */
        public DateTime Scadenza { get; set; }
    }
}
