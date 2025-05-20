using ChatApi.Interface;
using ChatApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace ChatApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageController(MessageRepository messageRepository) : ControllerBase
{
    private readonly MessageRepository _messageRepository = messageRepository;
    
    [HttpGet]
    public async Task<IActionResult> GetMessages()
    {
        var messages = await _messageRepository.GetMessageAsync();
        return Ok(messages);
    }
    [HttpPost]
    public async Task<IActionResult> PostMessage(IMessage message)
    {
        if (message == null)
        {
            return BadRequest("Message cannot be null");
        }

        var createdMessage = await _messageRepository.PostMessageAsync(message);
        return CreatedAtAction(nameof(GetMessages), new { id = createdMessage.Id }, createdMessage);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> EditMessage(Guid id, IMessage message)
    {
        if (id != message.Id)
        {
            return BadRequest("Message ID mismatch");
        }

        var updatedMessage = await _messageRepository.EditMessageAsync(message);
        if (updatedMessage == null)
        {
            return NotFound();
        }

        return Ok(updatedMessage);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage(Guid id)
    {
        var deleted = await _messageRepository.DeleteMessageAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}