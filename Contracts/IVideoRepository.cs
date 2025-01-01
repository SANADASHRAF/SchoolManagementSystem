using Entities.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IVideoRepository
    {
        Task<Video> GetVideoByIdAsync(long videoId, bool trackChanges);
        Task<string> UploadVideoToServer(IFormFile video, string fileName);
        void CreateVideo(Video videoEntity);
        void DeleteVideo(Video videoEntity);
    }
}
