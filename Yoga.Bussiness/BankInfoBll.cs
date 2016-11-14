using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga.Entity;
using Yoga.Entity.Enums;

namespace Yoga.Bussiness
{
    public class BankInfoBll
    {
        YogaContext _context = new YogaContext();

        public BankInfo GetById(int bankInfoId)
        {
            return _context.BankInfos.SingleOrDefault(x => x.BankInfoId == bankInfoId);
        }

        public List<BankInfo> GetAll()
        {
            return _context.BankInfos.Where(x=>x.StatusId != StatusEnum.DELETED.ToString()).ToList();
        }

        public List<BankInfo> GetByTrainerId(int trainerId)
        {
            return _context.BankInfos.Where(x=>x.TrainerId == trainerId).ToList();
        }

        public bool Delete(int bankInfoId)
        {
            try
            {
                BankInfo entity = _context.BankInfos.SingleOrDefault(x => x.BankInfoId == bankInfoId);
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

        public bool SaveOrUpdate(BankInfo bankInfo)
        {
            try
            {
                BankInfo entity = _context.BankInfos.SingleOrDefault(x => x.BankInfoId == bankInfo.BankInfoId);
                if (entity == null)
                {
                    bankInfo.CreatedDate = DateTime.Now;
                    _context.BankInfos.Add(bankInfo);

                }
                else
                {
                    entity.BankId = bankInfo.BankId;
                    entity.BankNumber = bankInfo.BankNumber;
                    entity.BankBrand = bankInfo.BankBrand;
                    entity.StatusId = bankInfo.StatusId;
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
