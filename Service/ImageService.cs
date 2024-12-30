using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ImageService : IImageService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public ImageService(IRepositoryManager repository, ILoggerManager logger, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<string> UpdateuserImage(UserImageDto userImage)
        {

            var user = await _userManager.FindByIdAsync(userImage.Id);
            if (user == null)
                return "User not found!";


            var deleteResult = await _repository.Image.DeleteExistingUserImage(user);
            if (!string.IsNullOrEmpty(deleteResult))
                return deleteResult;


            var imageFileName = $"{Guid.NewGuid()}_{userImage.Image.FileName}";
            var uploadResult = await _repository.Image.UploadImageToServer(userImage.Image, imageFileName);
            if (!string.IsNullOrEmpty(uploadResult))
                return $"Error uploading image: {uploadResult}";


            var addResult = await _repository.Image.AddUserImageToDatabase(user, imageFileName);
            if (!string.IsNullOrEmpty(addResult))
                return addResult;

            return "Image updated successfully!";

        }

    }
}
