using BussinessObject.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace eAuthorStore.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly HttpClient client;
        private string AuthorsApiUrl = "";

        public AuthorsController()
        {
            client = new HttpClient();
            AuthorsApiUrl = "https://localhost:5001/api/Authors";
            var contentType = "application/json";
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(contentType));

        }

        public async Task<IActionResult> Index()
        {
            List<Author> Authors = new List<Author>();

            try
            {
                // Call the API to get the Author list
                HttpResponseMessage response = await client.GetAsync(AuthorsApiUrl + "/getAll");

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content and deserialize it into a list of Authors
                    var jsonData = await response.Content.ReadAsStringAsync();
                    Authors = JsonConvert.DeserializeObject<List<Author>>(jsonData);
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

            // Pass the Authors list to the view
            return View(Authors);
        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Author Author = null;
            HttpResponseMessage response = await client.GetAsync($"{AuthorsApiUrl}/getById/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                Author = JsonConvert.DeserializeObject<Author>(jsonData);
            }
            else
            {
                return NotFound();
            }

            return View(Author);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author Author)
        {
            if (ModelState.IsValid)
            {
                var jsonData = JsonConvert.SerializeObject(Author);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"{AuthorsApiUrl}/create", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(Author);
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Author Author = null;
            HttpResponseMessage response = await client.GetAsync($"{AuthorsApiUrl}/getById/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                Author = JsonConvert.DeserializeObject<Author>(jsonData);
            }
            else
            {
                return NotFound();
            }

            return View(Author);
        }

        // POST: Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Author Author)
        {
            if (id != Author.AuthorId || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var jsonData = JsonConvert.SerializeObject(Author);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync($"{AuthorsApiUrl}/update/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(Author);
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Author Author = null;
            HttpResponseMessage response = await client.GetAsync($"{AuthorsApiUrl}/getById/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                Author = JsonConvert.DeserializeObject<Author>(jsonData);
            }
            else
            {
                return NotFound();
            }

            return View(Author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{AuthorsApiUrl}/delete/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }
    }

}
