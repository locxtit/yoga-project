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
    public class CustomerBll
    {
        private YogaContext _context = new YogaContext();

        public List<Customer> GetAll()
        {
            return _context.Customers.Where(x => x.StatusId == StatusEnum.ACTIVE.ToString()).ToList();
        }

        public IEnumerable<Customer> Search(SearchCustomerCriteriaModel criteria)
        {
            var query = _context.Customers.AsEnumerable();
            if (string.IsNullOrEmpty(criteria.CustomerName))
            {
                query = query.Where(x => x.Name.Contains(criteria.CustomerName));
            }
            if (string.IsNullOrEmpty(criteria.Phone))
            {
                query = query.Where(x => x.Phone == criteria.Phone);
            }
            if (string.IsNullOrEmpty(criteria.CustomerStatusId))
            {
                query = query.Where(x => x.CustomerTypeId == criteria.CustomerStatusId);
            }
            if (string.IsNullOrEmpty(criteria.CustomerTypeId))
            {
                query = query.Where(x => x.CustomerTypeId == criteria.CustomerTypeId);
            }
            return query;
        }

        public Province GetById(int provinceId)
        {
            var province = _context.Provinces.SingleOrDefault(x => x.ProvinceId == provinceId);
            return province;
        }

        public bool Delete(int customerId)
        {
            try
            {
                Customer entity = _context.Customers.SingleOrDefault(x => x.CustomerId == customerId);
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

        public bool SaveOrUpdate(Customer customer)
        {
            try
            {
                Customer entity = _context.Customers.SingleOrDefault(x => x.CustomerId == customer.CustomerId);
                if (entity == null)
                {
                    customer.StatusId = StatusEnum.ACTIVE.ToString();
                    _context.Customers.Add(customer);
                    
                }
                else
                {
                    entity.Name = customer.Name;
                    entity.Phone = customer.Phone;
                    entity.Email = customer.Email;
                    entity.CustomerStatusId = customer.CustomerStatusId;
                    entity.CustomerTypeId = customer.CustomerTypeId;
                    entity.Note = customer.Note;
                    entity.ProvinceId = customer.ProvinceId;
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