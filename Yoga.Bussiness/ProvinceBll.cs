using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga.Entity;
using Yoga.Entity.Enums;

namespace Yoga.Bussiness
{
    public class ProvinceBll
    {
        private YogaContext _context = new YogaContext();

        public List<Province> GetAll()
        {
            return _context.Provinces.Where(x=>x.StatusId != StatusEnum.ACTIVE.ToString()).ToList();
        }

        public List<Province> GetProvinceActive()
        {
            return _context.Provinces.Where(x => x.StatusId == StatusEnum.ACTIVE.ToString()).ToList();
        }

        public Province GetById(int provinceId)
        {
            var province = _context.Provinces.SingleOrDefault(x => x.ProvinceId == provinceId);
            return province;
        }

        public bool Delete(int provinceId)
        {
            try
            {
                Province entity = _context.Provinces.SingleOrDefault(x=>x.ProvinceId == provinceId);
                if (entity != null)
                {
                    entity.StatusId = StatusEnum.DELETED.ToString();
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public bool SaveOrUpdate(Province province)
        {
            try
            {
                Province entity = _context.Provinces.SingleOrDefault(x => x.ProvinceId == province.ProvinceId);
                if (entity == null)
                {
                    province.StatusId = StatusEnum.ACTIVE.ToString();
                    _context.Provinces.Add(province);
                    
                }
                else
                {
                    entity.ProvinceName = province.ProvinceName;
                    entity.StatusId = province.StatusId;
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
    }
}
