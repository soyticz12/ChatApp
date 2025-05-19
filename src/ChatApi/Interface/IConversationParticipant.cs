namespace ChatApi.Interface;

public interface IConversationParticipant
{
    public Guid ConversationID { get; set; }
    public Guid UserID { get; set; }
    public DateTime JoinedAt { get; set; }
   
}