using AutoMapper;

namespace FlightManager.Common.Mappings
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
