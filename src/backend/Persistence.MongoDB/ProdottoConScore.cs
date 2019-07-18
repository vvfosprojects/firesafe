using DomainModel.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.MongoDB
{
    public class ProdottoConScore
    {
        public Prodotto prodotto;
        public int score;

        public ProdottoConScore(Prodotto prodotto, int score)
        {
            this.prodotto = prodotto;
            this.score = score;
        }
    }
}
