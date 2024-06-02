using Bl.Bo;
using Bo;
using Dal.Do;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
     public class ToMathControl: ControllerBase
    {
            private BlManager _bl;
            public ToMathControl(BlManager bl)
            {
                this._bl = bl;
            }
            [Route("GetAll")]
            [HttpGet]
            public List<BToMatch>? GetAll() =>
                _bl.blToMatch.GetAll();

            [Route("Post")]
            [HttpPost]
            public int Post(BToMatch t) =>
                _bl.blToMatch.Post(t);
            [Route("Put")]
            [HttpPut]
            public bool Put(BToMatch t) =>
                _bl.blToMatch.Put(t);
        [HttpPost("ImportFile")]
        public async Task<bool> ImportFile( IFormFile file)
        {
            string name = file.FileName.Split('.')[0];
            string extension = Path.GetExtension(file.FileName);
            var writer = new FileStream($"D:/C#/bbbbb/ProjectStaz/Server/wwwroot/files/{name}{extension}", FileMode.OpenOrCreate);
            var stream = file.OpenReadStream();
            stream?.CopyToAsync(writer);
            writer.Close();
            return true;
        }
        //[HttpPost("ReadFromFile")]
        //public async static Task<List<string>> ReadFromFile()
        //{
        //    List<string> list = new List<string>();
        //    StreamReader Reader = new StreamReader("https://localhost:7061/files/z.txt");
        //    while (!Reader.EndOfStream)
        //    {
        //        list.Add(Reader.ReadLine()!);
        //        await Task.Delay(100);
        //    }
        //    Reader.Close();
        //    return list;
        //}

    }
}
