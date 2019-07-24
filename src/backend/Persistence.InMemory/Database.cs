using DomainModel.Classes;
using System;
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
                new Prodotto() { Prog  =  "38628", CodiceOmol = "PS1045D20D1IM00018", Tipo = new Tipo { Nome =  "O"}, Ditta = "MORFEUS S.p.A.", Classe = new Classe {Nome = " 1 IM"}, Firma  =  DateTime.Parse ("27-06-2016") ,  Scadenza  = DateTime.Parse ("27-06-2021"),  Impiego  =  "MATERASSO",  MacroGruppo  =  "LETTI E DIVANI",  DenominazioneCommerciale  =  "SERIE LARA FR"},
            };
        }

        public List<Prodotto> Prodotti
        {
            get
            {
                return this.prodotti;
            }
        }
    }
}
