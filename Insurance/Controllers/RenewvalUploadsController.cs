using Insurance.Data;
using Insurance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RenewvalUploadsController : ControllerBase
    {
        private readonly DataContext _Context;

        public RenewvalUploadsController(DataContext Context)
        {
            if (Context == null) throw new ArgumentException();

            this._Context = Context;

        }



        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                var _issueimages = from img in _Context.renewvalUploads
                                   select new
                                   {
                                       img.imgId,
                                       img.imgPath,
                                       img.imgSource,
                                       img.CreatedDate,
                                       img.GroupId

                                   };
                return Ok(_issueimages);
            }
            catch (Exception ex)
            {
                return Ok("Contact Admin.." + Environment.NewLine + ex.Message.ToString());
            }
        }


        [HttpGet("id")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _Context.renewvalUploads.Where(x => x.GroupId == id).Select(x => x).ToListAsync();
            return Ok(result);
        }

      

        public class uploadfile
        {
            public string groupid { get; set; }
            public IFormFile? imgfile { get; set; }
            public string? createdby { get; set; }
            public string? updatedby { get; set; }
        }

        [HttpPost()]
        public IActionResult Post([FromForm] uploadfile value)
        {
            try
            {
                string imgpath = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["ImageUrl"];
                string issid = "";

                if (value.imgfile != null)
                {
                    
                    var extension = Path.GetExtension(value.imgfile.FileName);
                    var saveimg = Path.Combine(imgpath, "renewval", DateTime.Now.ToString("yyyyMMddHHmmss") + issid.Replace("/", "_") + extension);
                   
                    using (Stream fileStream = new FileStream(saveimg, FileMode.Create))
                    {
                        value.imgfile.CopyTo(fileStream);
                    }
                    RenewvalUploads _issue = new RenewvalUploads()
                    {

                        imgPath = saveimg,
                        imgSource = value.imgfile.FileName,
                        GroupId = value.groupid,
                        CreatedDate = DateTime.Now,
                    };
                    _Context.renewvalUploads.Add(_issue);
                    _Context.SaveChanges();



                    return Ok(ErrorModel.ErrorMessage("1", "File Upload Successfully..!"));
                }
                else
                    return Ok(ErrorModel.ErrorMessage("0", "No Records Found..!"));
            }
            catch (Exception ex)
            {
                return Ok("Contact Admin.." + Environment.NewLine + ex.Message.ToString());
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _Context.renewvalUploads.Where(x => x.imgId == id).Select(x => x).FirstOrDefaultAsync();
            if (result != null)
            {
                _Context.renewvalUploads.Remove(result);

                _Context.SaveChanges();
            }
            return Ok(ErrorModel.ErrorMessage("1", "File Delete Successfully..!"));
        }
   


}
}
