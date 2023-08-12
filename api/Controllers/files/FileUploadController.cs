using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using hrm_api.Models;
using hrm_api.Data;
using log4net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hrm_api.Controllers.files
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly ILog log = LogManager.GetLogger(typeof(FileUploadController));

        [HttpPost("avatar/{empId}"), DisableRequestSizeLimit]
        public IActionResult UploadAvatar(string empId)
        {

            try
            {
                var files = Request.Form.Files;
                Console.WriteLine(files);
                var file = Request.Form.Files[0];

                var folderName = Path.Combine("storage", "avatar");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var d = fileName.Split('.');
                    var filetype = d[d.Length-1].ToString();
                    var newName = string.Format("{0}.{1}", empId, filetype);
                    var fullPath = Path.Combine(pathToSave, newName);
                    var dbPath = Path.Combine(folderName, newName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        if (!empId.StartsWith("TEMP"))
                        {
                            using (var db = new hrm_projectContext())
                            {
                                var emp = (from c in db.Tbemployees where c.Id == empId select c).FirstOrDefault();
                                emp.Avatar = dbPath;
                                db.SaveChanges();
                            }
                        }

                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost("documents/{empId}"), DisableRequestSizeLimit]
        public IActionResult UploadDocuments(string empId)
        {

            try
            {
                var files = Request.Form.Files;
                foreach (var file in files)
                {
                    Console.WriteLine(files);

                    var folderName = Path.Combine("storage", "files", empId);
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    var dir = new DirectoryInfo(pathToSave);
                    if (!dir.Exists)
                    {
                        dir.Create();
                    }

                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var filetype = fileName.Split('.')[1].ToString();
                        var rand = new Random(900000);
                        var numb = NumberConstrol.RandomString(50);
                        var newName = string.Format("{0}.{1}", numb, filetype);
                        var fullPath = Path.Combine(pathToSave, newName);
                        var dbPath = Path.Combine(folderName, newName);

                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                            var l = stream.Length;

                            using (var db = new hrm_projectContext())
                            {

                                string ID = NumberConstrol.GetNextNumber("F");

                                var filex = new Tbfile
                                {
                                    Id = ID,
                                    DisplayName = fileName,
                                    FileName = fileName,
                                    FileSize = (int)l,
                                    FileType = filetype,
                                    Owner = empId,
                                    Path = dbPath,
                                    CreatedAt = DateTime.Now,
                                    UpdatedAt = DateTime.Now
                                };
                                db.Tbfiles.Add(filex);
                                db.SaveChanges();
                            }
                        }


                    }
                    else
                    {
                        return BadRequest();
                    }
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }

            var list = new List<Tbfile>();

            using (var db = new hrm_projectContext())
            {
                list = (from c in db.Tbfiles where c.Owner == empId select c).ToList();
            }

            return Ok(list);
        }

        [HttpGet("documents/{empId}")]
        public IActionResult GetDocuments(string empId)
        {
            var list = new List<Tbfile>();

            try
            {
                using (var db = new hrm_projectContext())
                {
                    list = (from c in db.Tbfiles where c.Owner == empId select c).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

            return Ok(list);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFile(string id)
        {

            try
            {
                using (var db = new hrm_projectContext())
                {
                    var d = (from c in db.Tbfiles where c.Id == id select c).FirstOrDefault();
                    var empId = d.Owner;

                    var folderName = Path.Combine("storage", "files", d.Owner);
                    if (d.Path != null)
                    {
                        var fullPath = Path.Combine(Directory.GetCurrentDirectory(), d.Path);
                        FileInfo file = new FileInfo(fullPath);
                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }

                    db.Tbfiles.Remove(d);
                    db.SaveChanges();

                    return this.GetDocuments(empId);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

            return Ok();

        }

    }
}
