namespace DomainModel.Classes
{
    internal class Tipo
    {
        /*
         * Questo oggetto rappresenta il Tipo associato ad ogni prodotto. I valori possibili per nome sono:
         *  [E, O, U]
         */
        public int Id { get; }
        public string Nome { get; set; }
    }
}
