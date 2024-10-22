using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using BussinessObject.DataAccess;
using Newtonsoft.Json;

namespace eBookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly HttpClient client;
        private string BooksApiUrl = "";

        public BooksController()
        {
            client = new HttpClient();
            BooksApiUrl = "https://localhost:5001/api/Books";
            var contentType = "application/json";
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(contentType));

        }

        public async Task<IActionResult> Index()
        {
            List<Book> books = new List<Book>();

            try
            {
                // Call the API to get the book list
                HttpResponseMessage response = await client.GetAsync(BooksApiUrl+"/getAll");

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content and deserialize it into a list of books
                    var jsonData = await response.Content.ReadAsStringAsync();
                    books = JsonConvert.DeserializeObject<List<Book>>(jsonData);
                }
                else
                {
                    // Handle error response
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
            }

            // Pass the books list to the view
            return View(books);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Book book = null;
            HttpResponseMessage response = await client.GetAsync($"{BooksApiUrl}/getById/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                book = JsonConvert.DeserializeObject<Book>(jsonData);
            }
            else
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                var jsonData = JsonConvert.SerializeObject(book);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"{BooksApiUrl}/create", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Book book = null;
            HttpResponseMessage response = await client.GetAsync($"{BooksApiUrl}/getById/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                book = JsonConvert.DeserializeObject<Book>(jsonData);
            }
            else
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (id != book.BookId || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var jsonData = JsonConvert.SerializeObject(book);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync($"{BooksApiUrl}/update/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Book book = null;
            HttpResponseMessage response = await client.GetAsync($"{BooksApiUrl}/getById/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                book = JsonConvert.DeserializeObject<Book>(jsonData);
            }
            else
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{BooksApiUrl}/delete/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }

}
