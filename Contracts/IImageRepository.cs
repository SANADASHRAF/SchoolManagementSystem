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

        public void CheckDirectoryExist(string directoryPath);

        public Task<string> UploadImageToServer(IFormFile image, string fileName);

        public Task<string> DeleteExistingUserImage(ApplicationUser user);

        public Task<string> AddUserImageToDatabase(ApplicationUser user, string imageFileName);


    }
}
