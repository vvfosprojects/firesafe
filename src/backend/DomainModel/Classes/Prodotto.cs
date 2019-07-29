using System;

namespace DomainModel.Classes
{
    public class Prodotto : AbstractEntity
    {
        /// <summary>
        ///   Rappresenta un prodotto nel dominio d'interesse
        /// </summary>
        public Prodotto()
        { }

        /// <summary>
        ///   Rappresenta l'id in MongoDB
        /// </summary>
        public string Id { get; protected set; }

        /// <summary>
        ///   Rappresenta l'id nel DB di DCPST
        /// </summary>
        public string Prog { get; set; }

        /// <summary>
        ///   Rappresenta il tipo dell'oggetto
        /// </summary>
        public Tipo Tipo { get; set; }

        /// <summary>
        ///   Rappresenta il nome della ditta proprietaria del prodotto
        /// </summary>
        public string Ditta { get; set; }

        /// <summary>
        ///   Rappresenta il nome commerciale del prodotto
        /// </summary>
        public string DenominazioneCommerciale { get; set; }

        /// <summary>
        ///   Rappresenta la classe di appartenza del prodotto
        /// </summary>
        public Classe Classe { get; set; }

        /// <summary>
        ///   Rappresenta il codice di omologazione del prodotto
        /// </summary>
        public string CodiceOmol { get; set; }

        /// <summary>
        ///   Rappresenta la categoria (impiego) associata al prodotto
        /// </summary>
        public string Impiego { get; set; }

        /// <summary>
        ///   Il metodo ricerca la chiave passata in input, nei campi DenominazioneCommerciale,
        ///   Impiego e Macrogruppo; il metodo assegna un punteggio di +2 se la chiave in input ha
        ///   una corrispondenza ESATTA, +1 se vi è una corrispondenza PARZIALE per i campi
        ///   DenominazioneCommerciale, Impiego e Macrocategoria.
        /// </summary>

        public int ScoreByMultipleSearchKey(string key)
        {
            //se la stringa in input è vuota o contiene spazi posso ritornare il valore 1 poichè non effettuo
            //nessuna ricerca (non ritorno 0 per via dell'implementazione del filtro sulle
            //categorie di GetProdottiByTestoLibero)

            if (String.IsNullOrWhiteSpace(key) == true)
            {
                return 1;
            }

            string[] keys = key.Split(' ');
            int score = 0;

            foreach (string k in keys)
            {
                string toLower = k.ToLower();

                //se la Key è uguale alla DenominazioneCommerciale allora lo score ha peso +2
                if (toLower == DenominazioneCommerciale.ToLower())
                {
                    score += 5;
                }

                //se la Key è uguale alla Ditta allora lo score ha peso +3
                if (toLower == this.Ditta.ToLower())
                {
                    score += 3;
                }

                //se la Key è contenuta nella Ditta allora lo score ha peso +1
                if (this.Ditta.ToLower().Contains(toLower))
                {
                    score += 1;
                }

                //se la Key è contenuta nella DenominazioneCommerciale allora lo score ha peso +1
                if (DenominazioneCommerciale.ToLower().Contains(toLower))
                {
                    score += 1;
                }

                //se la Key è uguale ad Impiego o Macrogruppo allora lo score ha peso +2
                if (toLower == Impiego.ToLower() || toLower == MacroGruppo.ToLower())
                {
                    score += 2;
                }
                //se la Key è parzialmente contenuta in uno dei campi Impiego o MacroGruppo allora lo score ha peso 1
                if (Impiego.ToLower().Contains(toLower) || MacroGruppo.ToLower().Contains(toLower))
                {
                    score += 1;
                }
            }

            return score;
        }

        /// <summary>
        ///   La categora del prodotto (la differenza con Impiego è che questo campo presenta dei
        ///   raggruppamenti di record Impiego
        /// </summary>
        public string MacroGruppo { get; set; }

        /// <summary>
        ///   Rappresenta la data in cui è stata rilasciata l'omologazione del prodotto
        /// </summary>
        public DateTime Firma { get; set; }

        /// <summary>
        ///   Rappresenta la data di scadenza dell'omologazione associata al prodotto
        /// </summary>
        public DateTime Scadenza { get; set; }
    }
}
