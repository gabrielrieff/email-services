namespace EmailServices.Domain.Entities;

public class BaseEntity
{
    public long Id { get; set; }

    public DateTime Create_at { get; set; }

    public DateTime Update_at { get; set; }
}
