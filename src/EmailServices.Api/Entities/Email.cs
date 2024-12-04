using EmailServices.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EmailServices.Api.Entities;

public class Email
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    public List<string> To { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string From { get; set; } = string.Empty;
    public DateTime Create_at { get; set; }
    public DateTime? Send_at { get; set; }
    public StatusEmail EmailStatus { get; set; }
}