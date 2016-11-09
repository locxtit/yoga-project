﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga.Entity;
using Yoga.Entity.Enums;
using Yoga.Entity.Models;

namespace Yoga.Bussiness
{
    public class OrderInternalBll
    {
        private YogaContext _context = new YogaContext();

        public List<OrderInternal> GetAll()
        {
            return _context.OrderInternals.ToList();
        }

        public IEnumerable<OrderInternal> Search(SearchOrderInternalCriteriaModel criteria)
        {
            var query = _context.OrderInternals.AsEnumerable();
            if (criteria.OperatorId.HasValue)
            {
                query = query.Where(x => x.OperatorId == criteria.OperatorId.Value);
            }
            
            return query;
        }

        public OrderInternal GetById(int orderInternalId)
        {
            var orderInternal = _context.OrderInternals.SingleOrDefault(x => x.OrderInternalId == orderInternalId);
            return orderInternal;
        }

        public bool Delete(int orderInternalId)
        {
            try
            {
                OrderInternal entity = _context.OrderInternals.SingleOrDefault(x => x.OrderInternalId == orderInternalId);
                if (entity != null)
                {
                    _context.OrderInternals.Remove(entity);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public bool SaveOrUpdate(OrderInternal orderInternal)
        {
            try
            {
                var entity = _context.OrderInternals.SingleOrDefault(x => x.OrderInternalId == orderInternal.OrderInternalId);
                if (entity == null)
                {
                    orderInternal.CreatedDate = DateTime.Now;
                    _context.OrderInternals.Add(orderInternal);
                    
                }
                else
                {
                    entity.Total = orderInternal.Total;
                    entity.Note = orderInternal.Note;
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
