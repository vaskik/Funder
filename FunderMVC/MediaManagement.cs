using Funder.Models;
using Funder.Options;
using Funder.Repository;
using System;
using System.Collections.Generic;
using System.Text;


namespace Funder.Services
{
    public class MediaManagement : IMediaManager
    {
        private FunderDbContext db;

        public MediaManagement(FunderDbContext _db)
        {
            db = _db;
        }


        //CRUD
        // create read update delete
        public Media CreateMedia(MediaOption medOption)
        {
            Media media = new Media
            {
                MediaPath = medOption.MediaPath,
                Type = medOption.Type,
                Date = medOption.Date,
                
            };


            db.Medias.Add(media);
            db.SaveChanges();

            return media;
        }


        public Media Update(MediaOption medOption, int mediaId)
        {

            Media media = db.Medias.Find(mediaId);

            if (medOption.MediaPath != null)
                media.MediaPath = medOption.MediaPath;
            if (medOption.Type != null)
                media.Type = medOption.Type;
            if (medOption.Date != new DateTime())
                media.Date = medOption.Date;

            db.SaveChanges();
            return media;
        }

        public bool DeleteMediaById(int id)
        {
            Media media = db.Medias.Find(id);
            if (media != null)
            {
                db.Medias.Remove(media);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
