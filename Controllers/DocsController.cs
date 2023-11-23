using DBSQLite.Data;
using DBSQLite.Models;
using DBSQLite.Services;
using Microsoft.AspNetCore.Mvc;

namespace DBSQLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocsController : ControllerBase
    {
        const string baseUrl = "http://api.plos.org";
        const string endPoint = "/search?q=title:DNA";
        private readonly AppDbContext _context;
        private readonly IHttpService _httpService;

        public DocsController(AppDbContext context, IHttpService httpService)
        {
            _context = context;
            _httpService = httpService;
        }

        [HttpGet]
        public ActionResult<List<Models.Doc>> Get()
        {
            try
            {
                // fetch data from db
                List<Models.Doc> dtos = new List<Models.Doc>();
                var data = _context.Docs.ToList();
                dtos.AddRange(data.Select(d => new Models.Doc(d)));
                return Ok(dtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<APIResponse>> PullData()
        {
            try
            {
                // fetch data from api
                _httpService.SetBaseUri(baseUrl);
                RawResponse response = await _httpService.GetAsync<RawResponse>(endPoint);
                APIResponse apiResponse = response.Response;

                // save to db
                List<Data.Doc> dataDocs = new List<Data.Doc>();
                dataDocs.AddRange(apiResponse.Docs.Select(d => d.MapToDataModel()));
                await _context.AddRangeAsync(dataDocs);
                await _context.SaveChangesAsync();

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            // Delete all data
            _context.Docs.RemoveRange(_context.Docs);
            await _context.SaveChangesAsync();
            return Ok("Deleted All Data");
        }
    }
}
