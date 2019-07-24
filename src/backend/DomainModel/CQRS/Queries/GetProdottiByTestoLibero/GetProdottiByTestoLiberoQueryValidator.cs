using CQRS.Queries.Validators;
using CQRS.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.GetProdottiByTestoLibero
{
    public class GetProdottiByTestoLiberoQueryValidator : IQueryValidator<GetProdottiByTestoLiberoQuery, GetProdottiByTestoLiberoQueryResult>
    {
        /// <summary>
        ///   Il metodo Validate verifica 3 condizioni: che la proprietà query.Key non sia più lunga
        ///   di 100 caratteri; che la proprietà query.PageSize non sia maggiore di 20 (se superiore
        ///   viene imposta a 20); che la proprietà query.Categorie[i] non sia più lunga di 100 caratteri;
        /// </summary>
        /// <param name="query">DTO di input</param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(GetProdottiByTestoLiberoQuery query)
        {
            if (query.Key.Length > 100)
            {
                yield return new ValidationResult("Errore, chiave in input troppo lunga");
            }

            string[] keys = query.Key.Split(' ');
            foreach (string key in keys)
            {
                if (key.Length < 2)
                {
                    yield return new ValidationResult("Errore, ogni chiave di input deve avere almeno 2 caratteri");
                }
            }

            foreach (string categoria in query.Categorie)
            {
                if (categoria.Length > 100)
                {
                    yield return new ValidationResult("Errore, categoria di input troppo lunga");
                }
            }
        }
    }
}
