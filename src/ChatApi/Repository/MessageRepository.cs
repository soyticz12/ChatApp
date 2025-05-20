using ChatApi.Interface;
using ChatApi.Model;
using Supabase;

namespace ChatApi.Repository;

public class MessageRepository(Client client)
{
    private readonly Client _client = client;

    public async Task<List<IMessage>> GetMessageAsync()
    {
        var message = await _client.From<Message>().Get();
        return message.Models.Cast<IMessage>().ToList();
    }

    public async Task<IMessage> PostMessageAsync(IMessage message)
    {
        // Convert IMessage to Message and wrap in a collection
        var messageModel = message as Message ?? new Message
        {
            Id = message.Id,
            Content = message.Content,
            SenderId = message.SenderId,
            SentAt = message.SentAt
        };

        var result = await _client.From<Message>().Insert(new List<Message> { messageModel });
        return result.Models.FirstOrDefault();
    }

    public async Task<IMessage> EditMessageAsync(IMessage message)
    {
        var messageModel = message as Message ?? new Message
        {
            Id = message.Id,
            Content = message.Content,
            SenderId = message.SenderId,
            SentAt = message.SentAt
        };

        var result = await _client.From<Message>().Where(x => x.Id == messageModel.Id).Update();
        return result.Models.FirstOrDefault();
    }
    
    public async Task<bool> DeleteMessageAsync(Guid id)
    {
        await _client.From<Message>().Where(x => x.Id == id).Delete();
        return true;
    }
}