using System;
using API.CrossCutting.Mappings;
using AutoMapper;

namespace Api.Service.Test
{
    public class BaseServiceTest
    {
        public IMapper _mapper { get; set; }
        public BaseServiceTest()
        {
            _mapper = new AutoMapperFixture().GetMapper();
        }
    }

    public class AutoMapperFixture : IDisposable
    {
        public void Dispose()
        {
        }

        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new ModelToEntity());
                cfg.AddProfile(new EntityToDtoProfile());
            });

            return config.CreateMapper();
        }
    }
}
