using MuslimFashion.ViewModel;
using System.Collections.Generic;

namespace MuslimFashion.Repository
{
    public interface ISliderRepository
    {
        DbResponse<SliderCrudModel> Add(SliderCrudModel model);
        DbResponse Delete(int id);

        bool IsNull(int id);
        List<SliderCrudModel> List();
        List<SliderSlideModel> Slide();
    }
}