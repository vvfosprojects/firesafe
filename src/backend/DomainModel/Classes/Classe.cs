namespace DomainModel.Classes
{
    class Classe
    {
        /*
         * Questo oggetto rappresenta la Classe associata ad ogni prodotto. I valori possibili per nome sono:
         *  [0; 0 - 0; 0 - 1; 1; 1 - 0; 1 - 1; 1 IM; 2; 2 IM; 3 IM; 5; A1; 
         *  A2s1d0; Bfl-s1; Bs1d0; Bs2d0; Cfl-s1; Cs2d0; Cs3d0]
         */

        public int Id { get; }
        public string Nome { get; set; }

    }
}
