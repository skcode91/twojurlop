namespace TwojUrlop.Mapster
{
    public interface IMapsterConfiguration
    {
        MapsterConfiguration Scan();
        MapsterConfiguration Compile();
    }
}
