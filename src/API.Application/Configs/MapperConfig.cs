using API.CrossCutting.Mappings;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace API.Application.Configs
{
    public class MapperConfig
    {
        private readonly IServiceCollection _service;
        public MapperConfig(IServiceCollection service)
        {
            _service = service;
        }

        public void ConfigureMapper()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserDtoToModelProfile());
                cfg.AddProfile(new UserEntityToDtoProfile());
                cfg.AddProfile(new UserModelToEntity());
            });

            IMapper mapper = config.CreateMapper();
            _service.AddSingleton(mapper);
        }
    }
}
