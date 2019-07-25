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
                new Prodotto() { Prog  =  "38628", CodiceOmol = "PS1045D20D1IM00018", Tipo = new Tipo { Nome =  "O"}, Ditta = "MORFEUS S.p.A.", Classe = new Classe {Nome = " 1 IM"}, Firma = new DateTime(2010, 8, 18) ,  Scadenza  = DateTime.Parse ("27-06-2021"),  Impiego  =  "MATERASSO",  MacroGruppo  =  "LETTI E DIVANI",  DenominazioneCommerciale  =  "SERIE LARA FR"},
                new Prodotto() { Prog ="39377", CodiceOmol = "MI1481A70D200011", Tipo = new Tipo { Nome = "O"} , Ditta = "BIANCHI PAOLO S.r.l.", Classe = new Classe {Nome = " 2"}, Firma  =  new DateTime(2021, 12, 06), Scadenza = new DateTime(2016, 12, 06), Impiego = "STRUTTURE PRESSOSTATICHE, TENDONI, TELONI", MacroGruppo = "TELI E TENDAGGI", DenominazioneCommerciale = "BIATEX COIBENTATO"},
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
