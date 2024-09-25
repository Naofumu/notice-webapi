using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using System.Security.Claims;
using NoticeApi.Models;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class NoticeController : ControllerBase
{
    private readonly NoticeContext _context;
    public NoticeController(NoticeContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Notice>> PostNotice(Notice notice)
    {

        _context.Notices.Add(notice);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostNotice), new { id = notice.Id}, notice);
    }
}

public class MyDateTimeConverter : IsoDateTimeConverter
{
    public MyDateTimeConverter()
    {
        base.DateTimeFormat = "dd-MM-yyyy";
    }
}