using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class VideoRepository : RepositoryBase<Video>, IVideoRepository
    {
       
        public VideoRepository(RepositoryContext repositoryContext )
        : base(repositoryContext)
        {
        }

        public async Task<Video> GetVideoByIdAsync(long videoId, bool trackChanges) =>
            await FindByCondition(v => v.VideoID == videoId, trackChanges)
                .FirstOrDefaultAsync();

        public async Task<string> UploadVideoToServer(IFormFile video, string fileName)
        {
            try
            {
                string directory = @"h:\root\home\hattanfjh-001\www\hawisports\wwwroot\videos\";
               CheckDirectoryExist(directory);

                var path = Path.Combine(directory, fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await video.CopyToAsync(stream);
                }

                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public void CreateVideo(Video videoEntity) => Create(videoEntity);

        public void DeleteVideo(Video videoEntity) => Delete(videoEntity);

        public void UpdateVideo(Video videoEntity) => Update(videoEntity);

        private void CheckDirectoryExist(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
