using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration.Conventions;

namespace AutoMapperPractice
{

    public class Mapper
    {
        public static class MyMapper
        {
            public static TDestination Map<TDestination, TSource>(TSource source) // T是指泛型3
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TSource, TDestination>(); // 掃描所有 Profile 類別
                });

                var mapper = config.CreateMapper();

                return mapper.Map<TDestination>(source);
            }

            public static TDestination Map<TDestination, TSource>(TSource source, Action<IMappingExpression<TSource, TDestination>> mappingConfig = null) 
            {
                var config = new MapperConfiguration(cfg =>
                {
                    var map = cfg.CreateMap<TSource, TDestination>();
                    mappingConfig?.Invoke(map);

                });

                var mapper = config.CreateMapper();
                return mapper.Map<TDestination>(source);
            }      
        }

        //public static Dest Map<Dest, Source>(Source source)
        //{
        //    用現成automapper做到就好，不用要用到formember
        //    另外:思考formember真正的用途，然後用封裝的東西可以支援formember

        //     autoprofile功能在轉換上並非絕對必要，相較之下，直接寫在要轉換的地方標明轉換的模式
        //    var config = new MapperConfiguration(cfg =>
        //    cfg.CreateMap<Student, User>()// createMap有存在必要性，因為要知道載明的對應關係(ForMember),讓指定類型可以做對應轉換
        //    .ForMember(x => x.UserName, y => y.MapFrom(z => "Student:" + z.Name))
        //    .ForMember(x => x.Phone, y => y.MapFrom(z => z.phoneNumber))
        //    ); // 註冊Model間的對映
        //    IMapper mapper = config.CreateMapper(); // 建立 Mapper
        //    User result = mapper.Map<Student, User>(student); // SETUP好，就可以真正執行MAP
        //}
    }
}
