using ChatApi.Interface;
using Supabase.Postgrest.Models;

namespace ChatApi.Model;

public class Conversation : BaseModel, IConversation
{
    public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public bool Is_Group { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    
}