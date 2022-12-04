using AutoMapper;

namespace NZWalksapi.Profiles
{
    public class RegionProfile :Profile
    {
        public RegionProfile()
        {
            CreateMap<Models.Domain.Region , Models.DTO.Region>();
        }
    }
}
