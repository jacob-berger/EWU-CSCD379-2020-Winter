using SecretSanta.Data;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Reflection;

namespace SecretSanta.Business
{
    public class AutomapperConfigurationProfile : Profile
    {
        public static IMapper CreateMapper()
        {
            var mapperConfiguration = new MapperConfiguration(configuration => configuration.AddMaps(Assembly.GetExecutingAssembly()));
            return mapperConfiguration.CreateMapper();
        }
        public AutomapperConfigurationProfile()
        {
            CreateMap<Gift, Gift>().ForMember(prop => prop.Id, option => option.Ignore());
            CreateMap<User, User>().ForMember(prop => prop.Id, option => option.Ignore());
        }
    }
}
