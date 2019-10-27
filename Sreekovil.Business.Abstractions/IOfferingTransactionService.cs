using Sreekovil.Models.Models;
using System;
using System.Collections.Generic;
using Sreekovil.Models.Common;
using System.Text;

namespace Sreekovil.Business.Abstractions
{
    public interface IOfferingTransactionService : IGenericService<OfferingTransaction>
    {

        List<OfferingTransaction> GetOfferingTransactionByFilters(Filters filters);
        ///// <summary>
        ///// A method to get the offering by its Id.
        ///// </summary>
        ///// <param name="id">The offering id</param>
        ///// <returns>An offering object.</returns>
        //Offering Get(int id);

        ///// <summary>
        ///// Gets a list of all the Offerings.
        ///// </summary>
        ///// <returns>A list of Offering entity.</returns>
        //List<Offering> GetAll();

        ///// <summary>
        ///// The method to save/update the Offering entity.
        ///// </summary>
        ///// <param name="temple">The Offering entity to save or update</param>
        ///// <returns>An updated or saved entity.</returns>
        //Offering Save(Offering offering);

        ///// <summary>
        ///// Deletes the Offering entity.
        ///// </summary>
        ///// <param name="Offering">The entity to delete.</param>
        //void Delete(Offering offering);
    }
}
