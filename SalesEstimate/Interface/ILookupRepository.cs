using Microsoft.AspNetCore.Mvc.Rendering;
using SalesEstimate.Models;
using SalesEstimate.ViewModels;
using System.Linq;

namespace SalesEstimate.Interface
{
    public interface ILookupRepository
    {
        Task<List<LookupValue>> GetAllLookupData(LookupTypes.LookupType type);
        Task<SelectList> LookupSelectList(LookupTypes.LookupType type);

    }
}
