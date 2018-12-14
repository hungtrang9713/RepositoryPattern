using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Service;

namespace BookStore.Controllers
{
    public class BooksController : ApiController
    {
        private IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [Route("books")]
        [HttpGet]
        public IHttpActionResult GetALLBooks()
        {
            return Ok(_bookService.GetAll());
        }
    }
}
