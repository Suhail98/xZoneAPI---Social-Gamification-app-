﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xZoneAPI.Data;
using xZoneAPI.Models.RoadmapModel;

namespace xZoneAPI.Repositories.RoadmapRepo
{
    public class RoadmapRepository : IRoadmapRepository
    {
        ApplicationDBContext db;
        private readonly AppSettings appSettings;
        public RoadmapRepository(ApplicationDBContext _db, IOptions<AppSettings> _appSettings)
        {
            db = _db;
            appSettings = _appSettings.Value;
        }
        public bool addRoadmap(Roadmap Roadmap)
        {
            db.Roadmaps.Add(Roadmap);
            return Save();
        }

        public Roadmap FindRoadmapById(int id)
        {
            Roadmap Roadmap = db.Roadmaps.SingleOrDefault(x => x.Id == id);
            return Roadmap;
        }
        public ICollection<Roadmap> GetAllRoadmaps()
        {

            return db.Roadmaps.ToList();
        }
        public bool DeleteRoadmap(Roadmap Roadmap)
        {
            db.Roadmaps.Remove(Roadmap);
            return Save();
        }
        public bool UpdateRoadmap(Roadmap Roadmap)
        {
            db.Roadmaps.Update(Roadmap);
            return Save();
        }

        public bool Save()
        {
            return db.SaveChanges() >= 0;
        }

    }
}