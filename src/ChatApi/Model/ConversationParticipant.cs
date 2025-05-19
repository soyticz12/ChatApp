using ChatApi.Interface;

namespace ChatApi.Model;

public record ConversationParticipant : IConversationParticipant
{
    public Guid ConversationID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Guid UserID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime JoinedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}