using ChatApi.Interface;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ChatApi.Model;
[Table("conversation_participants")]
public class ConversationParticipant : BaseModel, IConversationParticipant
{
    [PrimaryKey("conversation_id", false)]
    public Guid ConversationID { get; set; }

    [PrimaryKey("user_id", false)]
    public Guid UserID { get; set; }

    public DateTime JoinedAt { get; set; }
}