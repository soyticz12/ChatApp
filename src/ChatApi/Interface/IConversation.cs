using ChatApi.Interface;

namespace ChatApi.Interface;
public interface IConversation : IEntity
{
    public string Name { get; set; }
    public bool Is_Group { get; set; }
    public DateTime CreatedAt { get; set; }
}