using CQRS.Queries.Validators;
using CQRS.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.GetProdottoPerCodice
{
    public class GetProdottoPerCodiceQueryValidator : IQueryValidator<GetProdottoPerCodiceQuery, GetProdottoPerCodiceQueryResult>
    {
        /// <summary>
        ///   Il metodo Validate, ritorna un'eccezione se la stringa in input è vuota o se la stringa
        ///   in input contiene caratteri non numerici
        /// </summary>
        /// <param name="query">DTO di input</param>
        /// <returns>Ritorna un'eccezione nel caso in cui l'input sia malformato</returns>
        public IEnumerable<ValidationResult> Validate(GetProdottoPerCodiceQuery query)
        {
            for (int i = 0; i < query.Codice.Length; i++)
            {
                if (Char.IsNumber(query.Codice[i]) == false)
                {
                    yield return new ValidationResult("Errore, input non valido");
                }
            }
        }
    }
}
