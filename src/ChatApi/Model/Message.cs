using ChatApi.Interface;

namespace ChatApi.Model;

public record Message : IMessage
{
    public Guid ConversationId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Guid SenderId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Content { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}