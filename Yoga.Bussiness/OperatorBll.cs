using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga.Entity;
using Yoga.Entity.Enums;

namespace Yoga.Bussiness
{
    public class OperatorBll
    {
        private YogaContext _context = new YogaContext();

        public List<Operator> GetAll()
        {
            return _context.Operators.Where(x=>x.StatusId == StatusEnum.ACTIVE.ToString()).ToList();
        }

        public Operator GetById(int operatorId)
        {
            var oper = _context.Operators.SingleOrDefault(x => x.OperatorId == operatorId);
            return oper;
        }

        public Operator GetByEmail(string email)
        {
            var oper = _context.Operators.SingleOrDefault(x => x.Email == email);
            return oper;
        }

        public bool Delete(int operatorId)
        {
            try
            {
                Operator entity = _context.Operators.SingleOrDefault(x => x.OperatorId == operatorId);
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

        public bool SaveOrUpdate(Operator oper)
        {
            try
            {
                Operator entity = _context.Operators.SingleOrDefault(x => x.OperatorId == oper.OperatorId);
                if (entity == null)
                {
                    oper.CreatedDate = DateTime.Now;
                    _context.Operators.Add(oper);
                    
                }
                else
                {
                    entity.Email = oper.Email;
                    entity.Phone = oper.Phone;
                    if (!string.IsNullOrEmpty(oper.Password))
                        entity.Password = oper.Password;
                    entity.OperatorName = oper.OperatorName;
                    entity.StatusId = oper.StatusId;
                    entity.OperatorTypeId = oper.OperatorTypeId;
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
