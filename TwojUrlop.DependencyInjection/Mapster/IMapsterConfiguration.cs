namespace AIA.DependencyInjection.Mapster
{
    public interface IMapsterConfiguration
    {
        MapsterConfiguration Scan();
        MapsterConfiguration Compile();
    }
}
