using CQRS.Validation;
using System;
using System.Collections.Generic;

namespace DomainModel.CQRS.Queries.GetProdottiByTestoLiberoPerCategoriaENome
{
    public class GetProdottiByTestoLiberoPerCategoriaENomeValidator
    {
        /// <summary>
        ///   Il metodo Validate verifica che la proprietà query.Key non sia più lunga
        ///   di 100 caratteri
        /// </summary>
        /// <param name="query">DTO di input</param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(GetProdottiByTestoLiberoPerCategoriaENomeQuery query)
        {
            if (!String.IsNullOrWhiteSpace(query.Key) && query.Key.Length > 100)
            {
                yield return new ValidationResult("Errore, chiave in input troppo lunga");
            }
        }
    }
}
