using ChatApi.Interface;
using ChatApi.Model;
using Supabase;

namespace ChatApi.Repository;

public class ConversationRepository
{
    private readonly Client _client;

    // Constructor where DI will inject the Client
    public ConversationRepository(Client client)
    {
        _client = client;
    }

    public async Task<List<IConversation>> GetConversationsAsync()
{
    // Get conversations from Supabase
    var conversations = await _client.From<Conversation>().Get();
    
    // Convert to a List and return
    return conversations.Models.Cast<IConversation>().ToList();
}

    public async Task<IConversation> AddConversationAsync(IConversation conversation)
    {
        var conversationModel = conversation as Conversation ?? new Conversation
        {
            Id = conversation.Id,
            Name = conversation.Name,
            Is_Group = conversation.Is_Group,
            CreatedAt = conversation.CreatedAt
        };

        var result = await _client.From<Conversation>().Insert(new List<Conversation> { conversationModel });
        return result.Models.FirstOrDefault();
    }

    public async Task<IConversation> EditConversationAsync(IConversation conversation)
    {
        var conversationModel = conversation as Conversation ?? new Conversation
        {
            Id = conversation.Id,
            Name = conversation.Name,
            Is_Group = conversation.Is_Group,
            CreatedAt = conversation.CreatedAt
        };

        var result = await _client.From<Conversation>().Where(x => x.Id == conversationModel.Id).Update();
        return result.Models.FirstOrDefault();
    }

    public async Task<bool> DeleteConversationAsync(Guid id)
    {
        await _client.From<Conversation>().Where(x => x.Id == id).Delete();
        return true;
    }
}
