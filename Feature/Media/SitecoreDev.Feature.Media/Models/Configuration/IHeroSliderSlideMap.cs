using Glass.Mapper.Sc.Maps;

namespace SitecoreDev.Feature.Media.Models.Configuration
{
   public class IHeroSliderSlideMap : SitecoreGlassMap<IHeroSliderSlide>
   {
      public override void Configure()
      {
         Map(config =>
         {
            config.AutoMap();
            config.Id(f => f.Id);
            config.Field(f => f.Image).FieldName("Image");
         });
      }
   }
}