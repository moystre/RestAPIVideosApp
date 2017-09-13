﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoAppBLL;
using VideoAppUI.VideoAppBLL.BusinessObjects;

namespace VideoRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Videos")]
    public class VideosController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/Video
        [HttpGet]
        public IEnumerable<VideoBO> Get()
        {
            return facade.VideoService.GetAll();
        }

        // GET: api/Video/5
        [HttpGet("{id}", Name = "Get")]
        public VideoBO Get(int id)
        {
            return facade.VideoService.Get(id);
        }
        
        // POST: api/Video
        [HttpPost]
        public IActionResult Post([FromBody]VideoBO video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(facade.VideoService.Create(video));
        }

        // PUT: api/Video/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]VideoBO video)
        {
            if (id != video.Id)
            {
                return BadRequest("Path id does not match the Id passed by Json.");
            }
            try
            {
                var videoo = facade.VideoService.Update(video);
                return Ok(videoo);
            }
            catch(InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
            
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.VideoService.Delete(id);
        }
    }
}
