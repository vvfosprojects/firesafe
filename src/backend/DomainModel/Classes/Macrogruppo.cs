namespace DomainModel.Classes
{
    /*
     * Questo oggetto rappresenta il Macrogruppo (agglomerato di valori per Impiego) associato ad ogni prodotto.
    */

    public class Macrogruppo
    {
        /// <summary>
        /// Rappresenta l'ID del macrogruppo
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Rappresenta il nome del macrogruppo
        /// </summary>
        public string Nome { get; set; }
    }
}
