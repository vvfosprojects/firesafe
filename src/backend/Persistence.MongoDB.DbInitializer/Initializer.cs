using DomainModel.Classes;
using NUnit.Framework;
using System;

namespace Tests
{
    public class Initializer
    {
        //[Test]
        public void InitializeDb()
        {
            var dbContext = new Persistence.MongoDB.DbContext("mongodb://localhost:27017/firesafe");

            var prodotti = new[]
            {
                new Prodotto() { Prog = "1", Tipo = new Tipo {Nome = "E"}, Ditta = "ditta1", Classe = new Classe { Nome = "1 IM"}, CodiceOmol = "codiceOmol", Firma = new DateTime(), Scadenza = new DateTime() , MacroGruppo = "Sedie", Impiego = "Sedie", DenominazioneCommerciale = "Sedia carina"},
                new Prodotto() { Prog = "2", Tipo = new Tipo {Nome = "E"}, Ditta = "ditta1", Classe = new Classe { Nome = "1 IM"}, CodiceOmol = "codiceOmol", Firma = new DateTime(), Scadenza = new DateTime() , MacroGruppo = "Sedie", Impiego = "Sedie", DenominazioneCommerciale = "Sedia Gialla"},
                new Prodotto() { Prog = "3", Tipo = new Tipo {Nome = "E"}, Ditta = "ditta1", Classe = new Classe { Nome = "1 IM"}, CodiceOmol = "codiceOmol", Firma = new DateTime(), Scadenza = new DateTime() , MacroGruppo = "Poltrone", Impiego = "Poltrone", DenominazioneCommerciale = "Poltrona comoda"},
                new Prodotto() { Prog = "4", Tipo = new Tipo {Nome = "E"}, Ditta = "ditta1", Classe = new Classe { Nome = "1 IM"}, CodiceOmol = "codiceOmol", Firma = new DateTime(), Scadenza = new DateTime() , MacroGruppo = "Tende", Impiego = "Tende", DenominazioneCommerciale = "Tendased rossa"},
                new Prodotto() { Prog = "5", Tipo = new Tipo {Nome = "E"}, Ditta = "ditta1", Classe = new Classe { Nome = "1 IM"}, CodiceOmol = "codiceOmol", Firma = new DateTime(), Scadenza = new DateTime() , MacroGruppo = "Tende", Impiego = "test", DenominazioneCommerciale = "Tenda test"},
                new Prodotto() { Prog = "30187", Tipo = new Tipo {Nome = "E"}, Ditta = "ditta1", Classe = new Classe { Nome = "1 IM"}, CodiceOmol = "codiceOmol", Firma = new DateTime(), Scadenza = new DateTime() , MacroGruppo = "CONTROSOFFITTO", Impiego = "CONTROSOFFITTO", DenominazioneCommerciale = "ISOLIMPIA DENS 40 kg/m³" },
                new Prodotto() { Prog = "26246", Tipo = new Tipo {Nome = "E"}, Ditta = "ditta1", Classe = new Classe { Nome = "1 IM"}, CodiceOmol = "codiceOmol", Firma = new DateTime(), Scadenza = new DateTime() , MacroGruppo = "COPERTURE", Impiego = "CONTROSOFFITTO", DenominazioneCommerciale = "ISOPET IG"},
                new Prodotto() { Prog = "36764", Tipo = new Tipo {Nome = "E"}, Ditta = "ditta1", Classe = new Classe { Nome = "1 IM"}, CodiceOmol = "codiceOmol", Firma = new DateTime(), Scadenza = new DateTime() , MacroGruppo = "COPERTURE", Impiego = "COPERTURA", DenominazioneCommerciale = "TETTOPACK"},
                new Prodotto() { Prog = "36533", Tipo = new Tipo {Nome = "E"}, Ditta = "ditta1", Classe = new Classe { Nome = "1 IM"}, CodiceOmol = "codiceOmol", Firma = new DateTime(), Scadenza = new DateTime() , MacroGruppo = "COPERTURE", Impiego = "COPERTURA", DenominazioneCommerciale = "TOPLIGHT"},
                new Prodotto() { Prog= "24529", Tipo = new Tipo {Nome = "E"}, Ditta = "ditta1", Classe = new Classe { Nome = "1 IM"}, CodiceOmol = "codiceOmol", Firma = new DateTime(), Scadenza = new DateTime() , MacroGruppo="BIANCHERIA DA LETTO", Impiego = "COPRILETTO, COPERTA", DenominazioneCommerciale="8683"},
                new Prodotto() { Prog="42493", Tipo = new Tipo {Nome = "E"}, Ditta = "ditta1", Classe = new Classe { Nome = "1 IM"}, CodiceOmol = "codiceOmol", Firma = new DateTime(), Scadenza = new DateTime() , MacroGruppo="BIANCHERIA DA LETTO", Impiego = "COPRILETTO, COPERTA, BEDDING", DenominazioneCommerciale="TR20-190"},
                new Prodotto() { Prog= "42158", Tipo = new Tipo {Nome = "E"}, Ditta = "ditta1", Classe = new Classe { Nome = "1 IM"}, CodiceOmol = "codiceOmol", Firma = new DateTime(), Scadenza = new DateTime() , MacroGruppo="BIANCHERIA DA LETTO", Impiego = "COPRIMATERASSO", DenominazioneCommerciale="COPRIMATERASSI IDROREPELLENTI AUTOESTINGUENTI/1"},
                new Prodotto() { Prog="39648", Tipo = new Tipo {Nome = "E"}, Ditta = "ditta1", Classe = new Classe { Nome = "1 IM"}, CodiceOmol = "codiceOmol", Firma = new DateTime(), Scadenza = new DateTime() , MacroGruppo="BIANCHERIA DA LETTO", Impiego = "COPRIMATERASSO", DenominazioneCommerciale="SERIE COPRIMATERASSO COM01"},
                new Prodotto() { Prog="42770", Tipo = new Tipo {Nome = "E"}, Ditta = "ditta1", Classe = new Classe { Nome = "1 IM"}, CodiceOmol = "codiceOmol", Firma = new DateTime(), Scadenza = new DateTime() , MacroGruppo="GUANCIALI", Impiego = "CUSCINO", DenominazioneCommerciale="SERIE CUSCINI E-AU ISO"},
                new Prodotto() { Prog="37643", Tipo = new Tipo {Nome = "E"}, Ditta = "ditta1", Classe = new Classe { Nome = "1 IM"}, CodiceOmol = "codiceOmol", Firma = new DateTime(), Scadenza = new DateTime() , MacroGruppo="LETTI E DIVANI", Impiego = "DIVANO-LETTO", DenominazioneCommerciale="SERIE S"},
                new Prodotto() { Prog="42670", Tipo = new Tipo {Nome = "E"}, Ditta = "ditta1", Classe = new Classe { Nome = "1 IM"}, CodiceOmol = "codiceOmol", Firma = new DateTime(), Scadenza = new DateTime() , MacroGruppo="LETTI E DIVANI", Impiego = "DIVANO-LETTO", DenominazioneCommerciale="SERIE SOFA' BED"}
            };

            dbContext.ProdottiCollection.InsertMany(prodotti);

            Assert.Pass();
        }
    }
}
