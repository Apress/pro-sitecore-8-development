using Glass.Mapper.Sc.Maps;

namespace SitecoreDev.Feature.Media.Models.Configuration
{
   public class IHeroSliderMap : SitecoreGlassMap<IHeroSlider>
   {
      public override void Configure()
      {
         Map(config =>
         {
            config.AutoMap();
            config.Id(f => f.Id);
         });
      }
   }
}