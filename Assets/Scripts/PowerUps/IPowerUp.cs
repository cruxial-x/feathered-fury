public interface IPowerUp
{
    string PowerUpName { get; }
    int PointsRequired { get; }
    void Apply(BirdController bird);
    void Remove(BirdController bird);
    void Update();
}