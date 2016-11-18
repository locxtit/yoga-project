using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga.Entity;
using Yoga.Entity.Enums;
using Yoga.Entity.Models;

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

        public Trainer GetByEmail(string email)
        {
            var trainer = _context.Trainers.SingleOrDefault(x => x.Email == email);
            return trainer;
        }

        public IEnumerable<Trainer> Search(SearchTrainerCriteriaModel criteria)
        {
            var query = _context.Trainers.Where(x => x.StatusId != StatusEnum.DELETED.ToString());
            if (!string.IsNullOrEmpty(criteria.TrainerName))
            {
                query = query.Where(x => x.TrainerName.Contains(criteria.TrainerName));
            }
            if (!string.IsNullOrEmpty(criteria.Phone))
            {
                query = query.Where(x => x.Phone == criteria.Phone);
            }
            if (!string.IsNullOrEmpty(criteria.Email))
            {
                query = query.Where(x => x.Email == criteria.Email);
            }
            return query;
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
                    trainer.CreatedDate = DateTime.Now;
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
