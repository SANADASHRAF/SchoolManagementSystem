using Entities.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IImageRepository
    {

        void CheckDirectoryExist(string directoryPath);

        Task<string> UploadImageToServer(IFormFile image, string fileName);

        Task<string> DeleteExistingUserImage(ApplicationUser user);

        Task<string> AddUserImageToDatabase(ApplicationUser user, string imageFileName);
        Task<Image> GetImageByIdAsync(long imageId, bool trackChanges);


    }
}
