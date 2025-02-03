﻿using KwikFitTestCentreApi.Data;
using KwikFitTestCentreApi.Interfaces;
using KwikFitTestCentreApi.Models;

namespace KwikFitTestCentreApi.Repository
{
    public class MOTStatusDetailsRepository : IMOTStatusDetailsRepository
    {
        private readonly DataContext _context;
        public MOTStatusDetailsRepository(DataContext context)
        {
            _context = context;
        }

        public bool Add(MOTStatusDetails details)
        {
            _context.MOTStatus.Add(details);
            return Save();
        }

        public bool Delete(MOTStatusDetails details)
        {
            _context.MOTStatus.Remove(details);
            return Save();
        }

        public MOTStatusDetails GetRegistrationNumber(string registrationNumber)
        {
            return _context.MOTStatus.Where(mots => mots.RegistrationNumber == registrationNumber).FirstOrDefault();
        }

        public MOTStatusDetails GetStatusDetail(int Id)
        {
            return _context.MOTStatus.Where(mots => mots.Id == Id).FirstOrDefault();
        }

        public ICollection<MOTStatusDetails> GetStatusDetails()
        {
            return _context.MOTStatus.OrderBy(mots => mots.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool StatusDetailExists(int Id)
        {
            return _context.MOTStatus.Any(mots => mots.Id == Id);
        }

        public bool StatusDetailExists(string registrationNumber)
        {
            return _context.MOTStatus.Any(mots => mots.RegistrationNumber.Equals(registrationNumber));
        }

        public bool Update(MOTStatusDetails details)
        {
            _context.MOTStatus.Update(details);
            return Save();
        }
    }
}
