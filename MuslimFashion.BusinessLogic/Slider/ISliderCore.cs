using Microsoft.AspNetCore.Http;
using MuslimFashion.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuslimFashion
{
    public interface ISliderCore
    {
        Task<DbResponse<SliderCrudModel>> AddAsync(SliderCrudModel model, IFormFile imageFile);
        DbResponse Delete(int id);
        List<SliderCrudModel> List();
        string[] Slide();
    }
}