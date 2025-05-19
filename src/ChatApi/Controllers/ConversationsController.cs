using ChatApi.Model;
using Microsoft.AspNetCore.Mvc;
using Supabase;

namespace ChatApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConversationsController(Client client) : ControllerBase
{
    private static readonly List<Message> _messages = new ();
    private readonly Client _client = client;

    [HttpGet]
    public IActionResult GetConversations()
    {
        return Ok(new { Message = "List of conversations" });
    }

}
