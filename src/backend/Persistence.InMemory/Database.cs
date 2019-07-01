using DomainModel.Classes;
using System.Collections.Generic;

namespace Persistence.InMemory
{
    internal class Database
    {
        private readonly List<Prodotto> prodotti;

        public Database()
        {
            this.prodotti = new List<Prodotto>()
            {
                new Prodotto() { Prog = "1", MacroGruppo = "Sedie", Impiego = "Sedie", DenominazioneCommerciale = "Sedia carina"},
                new Prodotto() { Prog = "2", MacroGruppo = "Sedie", Impiego = "Sedie", DenominazioneCommerciale = "Sedia Gialla"},
                new Prodotto() { Prog = "3", MacroGruppo = "Poltrone", Impiego = "Poltrone", DenominazioneCommerciale = "Poltrona comoda"},
                new Prodotto() { Prog = "4", MacroGruppo = "Tende", Impiego = "Tende", DenominazioneCommerciale = "Tenda rossa"},
            };
        }

        public IEnumerable<Prodotto> Prodotti
        {
            get
            {
                return this.prodotti;
            }
        }
    }
}