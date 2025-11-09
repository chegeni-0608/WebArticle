using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.Linq;
using System.Web;
using AutoMapper;
using WebArticle.ModelLayer;
using WebArticle.Views.ViewModels;

namespace WebArticle.App_Start
{
    public class AutoMapperConfig
    {
        public static IMapper mapper;

        public static void Configuration()
        {
            MapperConfiguration configuration = new MapperConfiguration(t =>
            {
                t.CreateMap<Category, CategoryViewModel>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();
                t.CreateMap<CategoryViewModel, Category>().IgnoreAllSourcePropertiesWithAnInaccessibleSetter();

            }, new NullLoggerFactory());
            mapper = configuration.CreateMapper();
        }
    }
}