using ChatApi.Model;
using ChatApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Supabase;

namespace ChatApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConversationsController : ControllerBase
{
   private readonly ConversationRepository _conversationRepository;

    // DI will inject the ConversationRepository here
    public ConversationsController(ConversationRepository conversationRepository)
    {
        _conversationRepository = conversationRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetConversations()
    {
        var conversations = await _conversationRepository.GetConversationsAsync();
        return Ok(conversations);
    }
}
