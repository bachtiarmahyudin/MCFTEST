using mcfBackEnd.Data;
using mcfBackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mcfBackEnd.Controllers
{
    [Route("api/MCF")]
    [ApiController]
    public class HomeController1 : ControllerBase
    {
        private readonly MyDbContext _myDbContext;
        public HomeController1(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        [HttpGet]
        [Route("getallusers")]
        public ActionResult<IEnumerable<MsUser>> GetUser()
        {
            return _myDbContext.Users;
        }

        [HttpGet]
        [Route("getuserbyid")]
        public async Task<ActionResult<MsUser>> GetUserById(int userId)
        {
            var _user = await _myDbContext.Users.FindAsync(userId);
            return _user;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<MsUser>> Login([FromBody] UserLogin userlogin)
        {
            var _user = await _myDbContext.Users.SingleAsync(p => p.UserName == userlogin.UserName && p.Password == userlogin.Password && p.IsActive);
            if (_user == null)
            {
                return NotFound();
            } else 
                { 
                return Ok(); 
            }
        }

        [HttpPost]
        [Route("createuser")]
        public async Task<ActionResult> CreateUser(MsUser user)
        {
            await _myDbContext.Users.AddAsync(user);
            await _myDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        [Route("updateuser")]
        public async Task<ActionResult> UpdateUser(MsUser user)
        {
            _myDbContext.Users.Update(user);
            await _myDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("deleteuser")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            var user = await _myDbContext.Users.FindAsync(userId);
            _myDbContext.Users.Remove(user);
            await _myDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("getall_location")]
        public ActionResult<IEnumerable<Location>> GetLocation()
        {
            return _myDbContext.Locations;
        }

        [HttpPost]
        [Route("insert_location")]
        public async Task<ActionResult> InsertLocation(Location location)
        {
            await _myDbContext.Locations.AddAsync(location);
            await _myDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("getallbpkb")]
        public ActionResult<IEnumerable<BPKB>> GetBPKB()
        {
            return _myDbContext.BPKBs;
        }

        [HttpGet]
        [Route("getbpkbbyid")]
        public async Task<ActionResult<BPKB>> GetBpkbById(string Id)
        {
            var _data = await _myDbContext.BPKBs.FindAsync(Id);
            return _data;
        }

        [HttpPost]
        [Route("insert_bpkb")]
        public async Task<ActionResult> InsertBPKB([FromBody] BPKBIN bpkb)
        {
            await _myDbContext.BPKBs.AddAsync(new BPKB {
                AgreementNumber = bpkb.AgreementNumber,
                BPKBNo = bpkb.BPKBNo,
                BranchId = bpkb.BranchId,
                BPKBDate = Convert.ToDateTime(bpkb.BPKBDate),
                FakturNo = bpkb.FakturNo,
                FakturDate = Convert.ToDateTime(bpkb.FakturDate),
                LocationId = bpkb.LocationId,
                PoliceNo = bpkb.PoliceNo,
                BPKBDateIn = Convert.ToDateTime(bpkb.BPKBDateIn),
                CreatedBy = bpkb.CreateBy,
                CreatedDate = DateTime.Now,
                UpdateBy = bpkb.CreateBy,
                UpdateDate = DateTime.Now
            });
            await _myDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        [Route("edit_bpkb")]
        public async Task<ActionResult> EditBPKB([FromBody] BPKBIN bpkb)
        {
            _myDbContext.BPKBs.Update(new BPKB
            {
                AgreementNumber = bpkb.AgreementNumber,
                BPKBNo = bpkb.BPKBNo,
                BranchId = bpkb.BranchId,
                BPKBDate = Convert.ToDateTime(bpkb.BPKBDate),
                FakturNo = bpkb.FakturNo,
                FakturDate = Convert.ToDateTime(bpkb.FakturDate),
                LocationId = bpkb.LocationId,
                PoliceNo = bpkb.PoliceNo,
                BPKBDateIn = Convert.ToDateTime(bpkb.BPKBDateIn),
                CreatedBy = bpkb.CreateBy,
                CreatedDate = DateTime.Now,
                UpdateBy = bpkb.CreateBy,
                UpdateDate = DateTime.Now
            });
            await _myDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("delete_bpkb")]
        public async Task<ActionResult> DeleteBPKB(string Id)
        {
            var data = await _myDbContext.BPKBs.FindAsync(Id);
            _myDbContext.BPKBs.Remove(data);
            await _myDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
