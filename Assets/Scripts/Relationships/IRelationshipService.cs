
public interface IRelationshipService : IService
{
    public uint MaxPoints { get; } //los puntos de cada relacion van de 0 a MaxPoints y comienzan en MaxPoints / 2
    public uint GetPoints(Relationships relationship);
    public void AddPoints(Relationships relationship, uint points);
    public void RemovePoints(Relationships relationship, uint points);
}
