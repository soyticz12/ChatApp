using ChatApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ParticipantsController(ParticipantsRepository participantsRepository) : ControllerBase
{
    private readonly ParticipantsRepository _participantsRepository = participantsRepository;

    [HttpGet("{conversationId:guid}")]
    public async Task<IActionResult> GetParticipants(Guid conversationId)
    {
        var participants = await _participantsRepository.GetParticipantsAsync(conversationId);
        if (participants == null || !participants.Any())
        {
            return NotFound("No participants found for this conversation.");
        }
        return Ok(participants);
    }
}