using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nazory.Data;

namespace Nazory.Pages;

public class NazoryListModel : PageModel
{
    readonly ApplicationDbContext DB;
    [BindProperty(SupportsGet =true)]
    public List<Nazor> Items { get; set; }


    public NazoryListModel (ApplicationDbContext db)
    {
        DB = db;
    }
    public async Task OnGetAsync()
    {
        Items = await DB.Nazory.OrderByDescending(x => x.Name).ToListAsync();
    }
}
