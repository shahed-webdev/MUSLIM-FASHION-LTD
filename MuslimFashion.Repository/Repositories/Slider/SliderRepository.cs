using AutoMapper;
using AutoMapper.QueryableExtensions;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace MuslimFashion.Repository
{
    public class SliderRepository : Repository, ISliderRepository
    {
        public SliderRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public DbResponse<SliderCrudModel> Add(SliderCrudModel model)
        {
            var slider = _mapper.Map<Slider>(model);
            Db.Slider.Add(slider);
            Db.SaveChanges();
            model.SliderId = slider.SliderId;

            return new DbResponse<SliderCrudModel>(true, $"Added Successfully", model);
        }

        public List<SliderCrudModel> List()
        {
            return Db.HomeMenu
                .ProjectTo<SliderCrudModel>(_mapper.ConfigurationProvider)
                .OrderBy(a => a.Sn)
                .ToList();
        }

        public string[] Slide()
        {
            return Db.Slider.OrderBy(a => a.Sn).Select(s => s.ImageFileName).ToArray();
        }
    }
}