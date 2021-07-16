using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using my_books.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _publishersService;

        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers(string sortBy, string searchString, int pageNumber)
        {
            try
            {
                var _result = _publishersService.GetAllPublishers(sortBy, searchString, pageNumber);
                return Ok(_result);
            }
            catch (Exception ex)
            {
                return BadRequest("No Publisher available yet");
            }
        }

        [HttpGet("get-publisher-books-with-authors/{publisherId}")]
        public IActionResult GetPublisherData(int publisherId)
        {
            var response = _publishersService.GetPublisherData(publisherId);
            return Ok(response);
        }

        [HttpGet("get-publisher-by-id/{publisherId}")] //IActionResult
        public IActionResult GetPublisherById(int publisherId)
        {
            //throw new Exception("This is an Exception that will be handled by middleware");
            var _response = _publishersService.GetPublisherById(publisherId);
            if(_response != null)
            {
                return Ok(_response);
            }
            return NotFound();
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            try
            {
                var newPublisher = _publishersService.AddPublisher(publisher);
                return Created(nameof(AddPublisher), newPublisher);
            }
            catch (PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Publisher name: {ex.PublisherName}");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            //return StatusCode(201, "Publisher Created Successfully");
        }

        [HttpDelete("delete-publisher-by-Id/{publisherId}")]
        public IActionResult DeletePublisherById(int publisherId)
        {
            try
            {
                _publishersService.DeletePublisherById(publisherId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }
    }
}
