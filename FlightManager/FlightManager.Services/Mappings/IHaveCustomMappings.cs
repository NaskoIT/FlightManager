using AutoMapper;

namespace FlightManager.Services.Mappings
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
