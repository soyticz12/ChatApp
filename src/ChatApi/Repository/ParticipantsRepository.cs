using ChatApi.Interface;
using ChatApi.Model;
using Supabase;

namespace ChatApi.Repository;

public class ParticipantsRepository(Client client)
{
    private readonly Client _client = client;

    public async Task<List<IConversationParticipant>> GetParticipantsAsync(Guid Id)
    {
        var participants = await _client.From<ConversationParticipant>().Where(cp => cp.ConversationID == Id).Get();
        return participants.Models.Cast<IConversationParticipant>().ToList();
    }

    public async Task<IConversationParticipant> AddParticipantAsync(IConversationParticipant participant)
    {
        var participantModel = participant as ConversationParticipant ?? new ConversationParticipant
        {
            ConversationID = participant.ConversationID,
            UserID = participant.UserID,
            JoinedAt = participant.JoinedAt
        };

        var result = await _client.From<ConversationParticipant>().Insert(new List<ConversationParticipant> { participantModel });
        return result.Models.FirstOrDefault();
    }

    public async Task<bool> DeleteParticipantAsync(Guid conversationId, Guid userId)
    {
        await _client.From<ConversationParticipant>()
            .Where(x => x.ConversationID == conversationId && x.UserID == userId)
            .Delete();
        return true;
    }
}