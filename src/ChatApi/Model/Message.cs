using ChatApi.Interface;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ChatApi.Model;
[Table("messages")]
public class Message : BaseModel, IMessage
{
    [Column("conversation_id")]
    public Guid ConversationId { get; set; }

    [Column("sender_id")]
    public Guid SenderId { get; set; }

    [Column("content")]
    public string Content { get; set; }

    [Column("sent_at")]
    public DateTime SentAt { get; set; }

    [PrimaryKey("id", false)]
    [Column("id")]
    public Guid Id { get; set; }
}