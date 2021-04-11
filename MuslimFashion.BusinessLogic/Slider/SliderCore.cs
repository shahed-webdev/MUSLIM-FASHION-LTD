using AutoMapper;
using DevMaker.FileStorage;
using Microsoft.AspNetCore.Http;
using MuslimFashion.BusinessLogic;
using MuslimFashion.Repository;
using MuslimFashion.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuslimFashion
{
    public class SliderCore : Core, ISliderCore
    {
        public SliderCore(IUnitOfWork db, IMapper mapper) : base(db, mapper)
        {
        }

        public async Task<DbResponse<SliderCrudModel>> AddAsync(SliderCrudModel model, IFormFile imageFile)
        {
            try
            {

                if (imageFile == null)
                    return new DbResponse<SliderCrudModel>(false, $"No Slider Image Added");

                var fileName = await FileStorage.UploadFileAsync(imageFile, "slider-image");
                model.ImageFileName = fileName;

                if (string.IsNullOrEmpty(model.ImageFileName))
                    return new DbResponse<SliderCrudModel>(false, $"No Slider Image Added");

                return _db.Slider.Add(model);

            }
            catch (Exception e)
            {
                return new DbResponse<SliderCrudModel>(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public DbResponse Delete(int id)
        {
            try
            {
                if (_db.Slider.IsNull(id)) return new DbResponse(false, "No data Found");
                return _db.Slider.Delete(id);
            }
            catch (Exception e)
            {
                return new DbResponse(false, $"{e.Message}. {e.InnerException?.Message ?? ""}");
            }
        }

        public List<SliderCrudModel> List()
        {
            return _db.Slider.List();
        }

        public List<SliderSlideModel> Slide()
        {
            return _db.Slider.Slide();
        }
    }
}