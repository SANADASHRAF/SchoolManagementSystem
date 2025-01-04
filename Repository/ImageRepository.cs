using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Image = Entities.Models.Image;

namespace Repository
{
    public class ImageRepository : RepositoryBase<Entities.Models.Image>, IImageRepository
    {
        public ImageRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void CheckDirectoryExist(string directoryPath)
        {
            // Check if the directory exists, and create it if it doesn't
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        public async Task<string> UploadImageToServer(IFormFile image, string fileName)
        {
            try
            {
                string directory = @"h:\root\home\sanad01092001 - 001\www\schoolmanagment\wwwroot\image\";
                CheckDirectoryExist(directory);

                var path = Path.Combine(directory, fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
      
        public async Task<string> AddUserImageToDatabase(ApplicationUser user, string imageFileName)
        {
            try
            {
               
                var newImage = new Entities.Models.Image
                {
                    ImageUrl = $"https://hawisports.com/wwwroot/image/" + imageFileName, 
                    imagename = Path.GetFileNameWithoutExtension(imageFileName), 
                    CreateDate = DateTime.Now
                };

                RepositoryContext.Images.Add(newImage);
                await RepositoryContext.SaveChangesAsync();

               

                var userImage = new ApplicationUserImage
                {
                    UserID = user.Id,
                    ImageId = newImage.ImageID,
                    CreateDate = DateTime.Now
                };

                RepositoryContext.applicationUserImages.Add(userImage);
               
               
                user.ApplicationUserImageID = userImage.ApplicationUserImageId;

                await RepositoryContext.SaveChangesAsync();

                return null;
            }
            catch (Exception ex)
            {
                return $"Error adding image to database: {ex.Message}";
            }
        }

        public async Task<string> DeleteExistingUserImage(ApplicationUser user)
        {
            if (user.ApplicationUserImage == null)
                return null;

            var oldImagePath = Path.Combine(@"h:\root\home\sanad01092001 - 001\www\schoolmanagment\wwwroot\image\", user.ApplicationUserImage.Image.ImageUrl);
            if (File.Exists(oldImagePath))
            {
                File.Delete(oldImagePath);
            }


            RepositoryContext.Images.Remove(user.ApplicationUserImage.Image);
            RepositoryContext.applicationUserImages.Remove(user.ApplicationUserImage);
            await RepositoryContext.SaveChangesAsync();

            return null;
        }

        public async Task<Image> GetImageByIdAsync(long imageId, bool trackChanges)
        {
            return await FindByCondition(i => i.ImageID == imageId, trackChanges)
                .FirstOrDefaultAsync();
        }


    }
}
