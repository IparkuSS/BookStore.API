using BookStore.API.Models;
using BookStore.API.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
namespace BookStore.API.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        public BooksController(IBooksService booksService) =>
            _booksService = booksService;
        /// <summary>
        /// Returns all books 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Book>> Get() =>
            await _booksService.GetAsync();

        /// <summary>
        /// Return specified books by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Book>> Get(string id)
        {
            var book = await _booksService.GetAsync(id);
            if (book is null)
            {
                return NotFound();
            }
            return book;
        }
        /// <summary>
        /// Creates a new book
        /// </summary>
        /// <param name="newBook"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(Book newBook)
        {
            await _booksService.CreateAsync(newBook);
            return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
        }
        /// <summary>
        ///  Updates a book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedBook"></param>
        /// <returns></returns>
        [HttpPut("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(string id, Book updatedBook)
        {
            var book = await _booksService.GetAsync(id);
            if (book is null)
            {
                return NotFound();
            }
            updatedBook.Id = book.Id;
            await _booksService.UpdateAsync(id, updatedBook);
            return NoContent();
        }
        /// <summary>
        /// Deletes a book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _booksService.GetAsync(id);
            if (book is null)
            {
                return NotFound();
            }
            await _booksService.RemoveAsync(book.Id);
            return NoContent();
        }
    }
}
