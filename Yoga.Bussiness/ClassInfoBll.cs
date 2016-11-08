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
    public class ClassInfoBll
    {
        private YogaContext _context = new YogaContext();

        public List<ClassInfo> GetAll()
        {
            return _context.ClassInfos.Where(x => x.StatusId == StatusEnum.ACTIVE.ToString()).ToList();
        }

        public IEnumerable<ClassInfo> Search(SearchClassInfoCriteriaModel criteria)
        {
            var query = _context.ClassInfos.Where(x=>x.StatusId != StatusEnum.DELETED.ToString());
            if (!string.IsNullOrEmpty(criteria.CustomerName))
            {
                query = query.Where(x => x.Customer.Name.Contains(criteria.CustomerName));
            }
            if (criteria.TrainerId.HasValue)
            {
                query = query.Where(x => x.TrainerId == criteria.TrainerId);
            }
            return query;
        }

        public ClassInfo GetById(int classInfoId)
        {
            var classInfo = _context.ClassInfos.SingleOrDefault(x => x.ClassInfoId == classInfoId);
            return classInfo;
        }

        public bool Delete(int classInfoId)
        {
            try
            {
                ClassInfo entity = _context.ClassInfos.SingleOrDefault(x => x.ClassInfoId == classInfoId);
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

        public bool SaveOrUpdate(ClassInfo classInfo)
        {
            try
            {
                ClassInfo entity = _context.ClassInfos.SingleOrDefault(x => x.ClassInfoId == classInfo.ClassInfoId);
                if (entity == null)
                {
                    classInfo.CreatedDate = DateTime.Now;
                    _context.ClassInfos.Add(classInfo);
                    
                }
                else
                {
                    entity.ClassName = classInfo.ClassName;
                    entity.TrainerId = classInfo.TrainerId;
                    entity.StartDate = classInfo.StartDate;
                    entity.EndDate = classInfo.EndDate;
                    entity.NumDaysOfWeek = classInfo.NumDaysOfWeek;
                    entity.TotalDays = classInfo.TotalDays;
                    entity.Price = classInfo.Price;
                    entity.TrainerPrice = classInfo.TrainerPrice;
                    entity.StatusId = classInfo.StatusId;
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