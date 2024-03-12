using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nazory.Data;

namespace Nazory.Areas.Editor.Pages;

public class NazoryListEditModel : PageModel
{
    readonly ApplicationDbContext DB;
    [BindProperty(SupportsGet =true)]
    public int NazorId { get; set; }
    [BindProperty]
    public Nazor Input {  get; set; }

    public NazoryListEditModel(ApplicationDbContext db)
    {
        DB = db;    
    }
    public async Task OnGetAsync()
    {
        if (NazorId == 0)
            Input = new Nazor();
        else
            await DB.Nazory.FindAsync(NazorId);
    }
    public async Task OnPostAsync()
    {
        if (Input == null || !TryValidateModel(Input))
            return;
        if (NazorId == 0)
            await DB.AddAsync(Input);
        else if (NazorId > 0)
            DB.Update(Input);
        else if(Input.Id < 0)
        {
            Input.Id = NazorId;
            DB.Remove(Input);
        }
        await DB.SaveChangesAsync();
        Response.Redirect("/nazory");
    }
}
