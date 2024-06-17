using FileServiceAPI.Models;
using MongoDB.Bson;
using System.Collections.ObjectModel;

namespace FileServiceAPI.Interfaces
{
    public interface IFileRepo
    {
        Task<List<FileModel>> GetFiles();

        Task<FileModel?> GetFile(string id);
        Task CreateFile(FileModel file);
        Task UpdateFile(string id, FileModel updatedFile);
        Task DeleteFile(string id);
        void AddCommentCount(string fileid);
    }
}
