using DomainModel.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Persistence.InMemory
{
    internal class Database_hardcoded
    {
        private readonly List<Prodotto> prodotti;

        //private string path = @"C:\Users\Utente\Desktop\ProdottiOmologati\DB\InMemory.json";
        private string path = @"InMemory.json";

        public Database_hardcoded()
        {
            this.prodotti = new List<Prodotto>();

            var json = JsonConvert.DeserializeObject<Prodotto[]>(File.ReadAllText(path), new JsonSerializerSettings
            {
                DateFormatString = "dd/MM/yyyy"
            });

            foreach (var obj in json)
            {
                prodotti.Add(
                new Prodotto(obj.Classe.Nome, obj.Tipo.Nome)
                {
                    Prog = obj.Prog,
                    Ditta = obj.Ditta,
                    CodiceOmol = obj.CodiceOmol,
                    Firma = obj.Firma,
                    Scadenza = obj.Scadenza,
                    MacroGruppo = obj.MacroGruppo,
                    Impiego = obj.MacroGruppo,
                    DenominazioneCommerciale = obj.DenominazioneCommerciale
                });
            }
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
