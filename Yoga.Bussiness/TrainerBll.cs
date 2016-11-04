﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga.Entity;
using Yoga.Entity.Enums;

namespace Yoga.Bussiness
{
    public class TrainerBll
    {
        private YogaContext _context = new YogaContext();

        public List<Trainer> GetAll()
        {
            return _context.Trainers.Where(x => x.StatusId == StatusEnum.ACTIVE.ToString()).ToList();
        }

        public Trainer GetById(int trainerId)
        {
            var trainer = _context.Trainers.SingleOrDefault(x => x.TrainerId == trainerId);
            return trainer;
        }

        public bool Delete(int trainerId)
        {
            try
            {
                Trainer entity = _context.Trainers.SingleOrDefault(x => x.TrainerId == trainerId);
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

        public bool SaveOrUpdate(Trainer trainer)
        {
            try
            {
                Trainer entity = _context.Trainers.SingleOrDefault(x => x.TrainerId == trainer.TrainerId);
                if (entity == null)
                {
                    trainer.StatusId = StatusEnum.ACTIVE.ToString();
                    _context.Trainers.Add(trainer);

                }
                else
                {
                    entity.TrainerName = trainer.TrainerName;
                    entity.Phone = trainer.Phone;
                    entity.Email = trainer.Email;
                    entity.Address = trainer.Address;
                    entity.Experience = trainer.Experience;
                    entity.Subject = trainer.Subject;
                    entity.StatusId = trainer.StatusId;
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