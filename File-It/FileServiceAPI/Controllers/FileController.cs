using FileServiceAPI.Interfaces;
using FileServiceAPI.Messaging;
using FileServiceAPI.Models;
using FileServiceAPI.Repos;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace FileServiceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : Controller
    {
        private readonly IFileRepo _filerepo;
        private readonly SendMessage _sendMessage;
        public FileController(IFileRepo fileRepo, IConfiguration configuration)
        {
            _filerepo = fileRepo;
            _sendMessage = new SendMessage();
            _sendMessage.createChannel(configuration);
        }

        [HttpGet("All")]
        public async Task<List<FileModel>> GetFiles()
        {
            return await _filerepo.GetFiles();
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<FileModel>> GetFile(string id)
        {
            var file = await _filerepo.GetFile(id);

            if(file == null) { return NotFound(); }

            return file;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateFile(FileModel newFile)
        {
            await _filerepo.CreateFile(newFile);

            return CreatedAtAction(nameof(GetFile), new { id = newFile.Id }, newFile);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateFile(string id, FileModel updatedFile)
        {
            var file = await _filerepo.GetFile(id);

            if(file == null) { return NotFound();}

            updatedFile.Id = file.Id;

            await _filerepo.UpdateFile(id, updatedFile);

            return NoContent();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteFile(string id)
        {
            var file = await _filerepo.GetFile(id);

            if (file == null) { return NotFound(); }

            await _filerepo.DeleteFile(id);

            _sendMessage.FileDeleted(id);  

            return NoContent();
        }
    }
}
