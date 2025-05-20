using ChatApi.Interface;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace ChatApi.Model;
[Table("conversations")]
public class Conversation : BaseModel, IConversation
{
    [PrimaryKey("id", false)]
    public Guid Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("is_group")]
    public bool Is_Group { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}