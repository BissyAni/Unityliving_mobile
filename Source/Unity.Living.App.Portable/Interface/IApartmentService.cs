using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Living.App.Portable.Models.Apartment;

namespace Unity.Living.App.Portable.Interface
{
   public interface IApartmentService
   {
     Task<List<ApartmentModel>> GetApartments();
   }
}
