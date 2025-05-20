using ChatApi.Model;
using ChatApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Supabase;

namespace ChatApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ConversationsController(ConversationRepository conversationRepository) : ControllerBase
{
    private readonly ConversationRepository _conversationRepository = conversationRepository;

    [HttpGet]
    public async Task<IActionResult> GetConversations()
    {
        var conversations = await _conversationRepository.GetConversationsAsync();
        return Ok(conversations);
    }

    [HttpPost]
    public async Task<IActionResult> AddConversation(Conversation conversation)
    {
        if (conversation == null)
        {
            return BadRequest("Conversation cannot be null");
        }

        var createdConversation = await _conversationRepository.AddConversationAsync(conversation);
        return CreatedAtAction(nameof(GetConversations), new { id = createdConversation.Id }, createdConversation);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditConversation(Guid id, Conversation conversation)
    {
        if (id != conversation.Id)
        {
            return BadRequest("Conversation ID mismatch");
        }

        var updatedConversation = await _conversationRepository.EditConversationAsync(conversation);
        if (updatedConversation == null)
        {
            return NotFound();
        }

        return Ok(updatedConversation);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConversation(Guid id)
    {
        var deleted = await _conversationRepository.DeleteConversationAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
