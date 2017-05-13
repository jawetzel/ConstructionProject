using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreRepo.Data;
using CoreRepo.Data.Work;

namespace CoreRepo.DataAccess.Work
{
    public class ImageTypeDataAccess
    {
        private readonly Context DbContext;
        public ImageTypeDataAccess(Context dbContext)
        {
            DbContext = dbContext;
        }

        public List<ImageType> GetListOfAllWorkImages()
        {
            return DbContext.ImageTypes.Where(workImage => workImage.IsActive).ToList();
        }

        public ImageType GetImageTypeByDescription(string description)
        {
            try
            {
                return DbContext.ImageTypes.First(imgType => imgType.IsActive && imgType.Description.ToLower().Contains(description.ToLower()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public ImageType UpdateImageType(ImageType imageType)
        {
            try
            {
                imageType.LastEditedDateTime = DateTime.UtcNow;
                DbContext.ImageTypes.Update(imageType);
                DbContext.SaveChanges();
                return imageType;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public ImageType DeleteImageType(ImageType imageType)
        {
            try
            {
                imageType.LastEditedDateTime = DateTime.UtcNow;
                imageType.IsActive = false;
                DbContext.ImageTypes.Update(imageType);
                DbContext.SaveChanges();
                return imageType;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
