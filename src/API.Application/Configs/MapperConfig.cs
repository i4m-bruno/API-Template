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
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntity());
            });

            IMapper mapper = config.CreateMapper();
            _service.AddSingleton(mapper);
        }
    }
}
