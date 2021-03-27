using AutoMapper;
using AutoMapper.QueryableExtensions;
using MuslimFashion.Data;
using MuslimFashion.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace MuslimFashion.Repository
{
    public class SizeRepository : Repository, ISizeRepository
    {
        public SizeRepository(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public DbResponse<SizeCrudModel> Add(SizeCrudModel model)
        {
            var size = _mapper.Map<Size>(model);
            Db.Size.Add(size);
            Db.SaveChanges();
            model.SizeId = size.SizeId;

            return new DbResponse<SizeCrudModel>(true, $"{model.SizeName} Added Successfully", model);
        }

        public DbResponse Edit(SizeCrudModel model)
        {
            var size = Db.Size.Find(model.SizeId);
            size.SizeName = model.SizeName;
            size.Description = model.Description;
            Db.Size.Update(size);
            Db.SaveChanges();
            return new DbResponse(true, $"{size.SizeName} Updated Successfully");
        }

        public DbResponse Delete(int id)
        {
            var size = Db.Size.Find(id);
            Db.Size.Remove(size);
            Db.SaveChanges();
            return new DbResponse(true, $"{size.SizeName} Deleted Successfully");
        }

        public DbResponse<SizeCrudModel> Get(int id)
        {
            var menu = Db.Size.Where(r => r.SizeId == id)
                .ProjectTo<SizeCrudModel>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
            return new DbResponse<SizeCrudModel>(true, $"{menu.SizeName} Get Successfully", menu);
        }

        public bool IsExistName(string name)
        {
            return Db.Size.Any(r => r.SizeName == name);
        }

        public bool IsExistName(string name, int updateId)
        {
            return Db.Size.Any(r => r.SizeName == name && r.SizeId != updateId);
        }

        public bool IsNull(int id)
        {
            return Db.Size.Any(r => r.SizeId == id);
        }

        public bool IsRelatedDataExist(int id)
        {
            return false;
        }

        public List<SizeCrudModel> List()
        {
            return Db.Size
                .ProjectTo<SizeCrudModel>(_mapper.ConfigurationProvider)
                .OrderBy(a => a.SizeName)
                .ToList();
        }

        public List<DDL> ListDdl()
        {
            return Db.Size
                .OrderBy(a => a.SizeName)
                .Select(m => new DDL
                {
                    value = m.SizeId.ToString(),
                    label = m.SizeName
                }).ToList();
        }
    }
}