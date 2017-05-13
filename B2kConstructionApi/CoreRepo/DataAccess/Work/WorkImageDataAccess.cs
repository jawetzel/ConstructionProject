using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepo.Data;
using CoreRepo.Data.Work;

namespace CoreRepo.DataAccess.Work
{
    public class WorkImageDataAccess
    {
        private readonly Context DbContext;
        public WorkImageDataAccess(Context dbContext)
        {
            DbContext = dbContext;
        }

        public List<WorkImage> GetListOfAllWorkImages()
        {
            return DbContext.WorkImages.Where(workImage => workImage.IsActive).ToList();
        }

        public List<WorkImage> GetListOfWorkImagesByImageTypeId(int id)
        {
            return DbContext.WorkImages.Where(wrkSess => wrkSess.IsActive && wrkSess.ImageTypeId == id).ToList();
        }

        public List<WorkImage> GetListOfWorkImagesByImageTypeDescription(string description)
        {
            return DbContext.WorkImages.Where(wrkSess => wrkSess.IsActive && wrkSess.Description.ToLower().Contains(description.ToLower())).ToList();
        }

        public List<WorkImage> GetListOfWorkImagesByWorkSessionId(int id)
        {
            return DbContext.WorkImages.Where(workImage => workImage.IsActive && workImage.WorkSessionId == id).ToList();
        }

        public WorkImage GetWorkImageById(int id)
        {
            try
            {
                return DbContext.WorkImages.First(wrkImg => wrkImg.IsActive && wrkImg.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public WorkImage UpdateWorkImage(WorkImage workImage)
        {
            try
            {
                workImage.LastEditedDateTime = DateTime.UtcNow;
                DbContext.WorkImages.Update(workImage);
                DbContext.SaveChanges();
                return workImage;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public WorkImage DeleteWorkImage(WorkImage workImage)
        {
            try
            {
                workImage.LastEditedDateTime = DateTime.UtcNow;
                workImage.IsActive = false;
                DbContext.WorkImages.Update(workImage);
                DbContext.SaveChanges();
                return workImage;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
