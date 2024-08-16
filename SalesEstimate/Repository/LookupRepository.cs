using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesEstimate.Data;
using SalesEstimate.Interface;
using SalesEstimate.Models;
using SalesEstimate.ViewModels;

public class LookupRepository : ILookupRepository
{
    private readonly ApplicationDbContext _context;

    public LookupRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<LookupValue>> GetAllLookupData(LookupTypes.LookupType type)
    {
        return await _context.LookupValues.Where(x => x.LookupTypeId == (int)type).ToListAsync();
    }
    public async Task<SelectList> LookupSelectList(LookupTypes.LookupType type)
    {
        var data = await GetAllLookupData(type);
        var selectList = new SelectList(data, "Id", "Name");
        return selectList;

    }
}
