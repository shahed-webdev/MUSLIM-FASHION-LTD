using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevMaker.FileStorage;
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

        public DbResponse Delete(int id)
        {
            var slider = Db.Slider.Find(id);

            FileStorage.DeleteFile(slider.ImageFileName);

            Db.Slider.Remove(slider);
            Db.SaveChanges();

            return new DbResponse(true, "Deleted Successfully");


        }

        public bool IsNull(int id)
        {
            return !Db.Slider.Any(s => s.SliderId == id);
        }

        public List<SliderCrudModel> List()
        {
            return Db.Slider
                .ProjectTo<SliderCrudModel>(_mapper.ConfigurationProvider)
                .OrderBy(a => a.Sn)
                .ToList();
        }

        public List<SliderSlideModel> Slide()
        {
            return Db.Slider
                .OrderBy(a => a.Sn)
                .ProjectTo<SliderSlideModel>(_mapper.ConfigurationProvider)
                .ToList();
        }
    }
}