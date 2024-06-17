using FileServiceAPI.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using FileServiceAPI.Interfaces;
using System.Collections.ObjectModel;
using Consul;
using System.Text;

namespace FileServiceAPI.Repos
{
    public class FileRepo : IFileRepo
    {
        private readonly IMongoCollection<FileModel> _fileCollection;
        private const string consulkey = "MONGODB_CONNECTION_STRING";

        public FileRepo(IConfiguration config)
        {
            MongoClient client = new MongoClient(config["MongoConnection"]); // giving connectionstring to client

            IMongoDatabase database = client.GetDatabase("FileService"); // Gets the file database

            _fileCollection = database.GetCollection<FileModel>("Files"); // Gets the file collection
        }

        public async Task CreateFile(FileModel file)
        {
           await _fileCollection.InsertOneAsync(file);
        }

        public async Task DeleteFile(string id)
        {
            await _fileCollection.DeleteOneAsync(file => file.Id == id);
        }

        public async Task<FileModel?> GetFile(string id)
        {
            return await _fileCollection.Find(file => file.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<FileModel>> GetFiles()
        {
            return await _fileCollection.Find(_ => true).ToListAsync();
        }

        public async Task UpdateFile(string id, FileModel updatedFile)
        {
            await _fileCollection.ReplaceOneAsync(file => file.Id == id, updatedFile);
        }

        public async void AddCommentCount(string fileid)
        {
            var file = GetFile(fileid).Result;
            if (file == null) return;
            file.AddCommentCount();
            await UpdateFile(fileid, file);
        }
    }
}
