using MuslimFashion.ViewModel;
using System.Collections.Generic;

namespace MuslimFashion.Repository
{
    public interface ISliderRepository
    {
        DbResponse<SliderCrudModel> Add(SliderCrudModel model);
        List<SliderCrudModel> List();
        string[] Slide();
    }
}