using AutoMapper;
using AutoMapper.QueryableExtensions;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace MuslimFashion.Repository
{
    public class ColorRepository : Repository, IColorRepository
    {
        public ColorRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public DbResponse<ColorCrudModel> Add(ColorCrudModel model)
        {
            var color = _mapper.Map<Color>(model);
            Db.Color.Add(color);
            Db.SaveChanges();
            model.ColorId = color.ColorId;

            return new DbResponse<ColorCrudModel>(true, $"{model.ColorName} Added Successfully", model);
        }

        public DbResponse Edit(ColorCrudModel model)
        {
            var color = Db.Color.Find(model.ColorId);
            color.ColorName = model.ColorName;
            color.ColorCode = model.ColorCode;
            Db.Color.Update(color);
            Db.SaveChanges();
            return new DbResponse(true, $"{color.ColorName} Updated Successfully");
        }

        public DbResponse Delete(int id)
        {
            var color = Db.Color.Find(id);
            Db.Color.Remove(color);
            Db.SaveChanges();
            return new DbResponse(true, $"{color.ColorName} Deleted Successfully");
        }

        public DbResponse<ColorCrudModel> Get(int id)
        {
            var menu = Db.Color.Where(r => r.ColorId == id)
                .ProjectTo<ColorCrudModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new DbResponse<ColorCrudModel>(true, $"{menu.ColorName} Get Successfully", menu);
        }

        public bool IsExistName(string name)
        {
            return Db.Color.Any(r => r.ColorName == name);
        }

        public bool IsExistName(string name, int updateId)
        {
            return Db.Color.Any(r => r.ColorName == name && r.ColorId != updateId);
        }

        public bool IsExistCode(string code)
        {
            if (string.IsNullOrEmpty(code)) return false;
            return Db.Color.Any(r => r.ColorCode == code);
        }

        public bool IsExistCode(string code, int updateId)
        {
            if (string.IsNullOrEmpty(code)) return false;
            return Db.Color.Any(r => r.ColorCode == code && r.ColorId != updateId);
        }

        public bool IsNull(int id)
        {
            return Db.Color.Any(r => r.ColorId == id);
        }

        public bool IsRelatedDataExist(int id)
        {
            return false;
        }

        public List<ColorCrudModel> List()
        {
            return Db.Color
                .ProjectTo<ColorCrudModel>(_mapper.ConfigurationProvider)
                .OrderBy(a => a.ColorName)
                .ToList();
        }

        public List<DDL> ListDdl()
        {
            return Db.Color
                .OrderBy(a => a.ColorName)
                .Select(m => new DDL
                {
                    value = m.ColorId.ToString(),
                    label = m.ColorName
                }).ToList();
        }
    }
}