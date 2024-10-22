using BussinessObject.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers
{
    public class UsersController : Controller
    {
        private readonly HttpClient client;
        private string UsersApiUrl = "https://localhost:5001/api/Users";

        public UsersController()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Users/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Users/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string emailAddress, string password)
        {
            if (!string.IsNullOrEmpty(emailAddress) && !string.IsNullOrEmpty(password))
            {
                var response = await client.GetAsync($"{UsersApiUrl}?emailAddress={emailAddress}&password={password}");
                if (response.IsSuccessStatusCode)
                {
                    var user = await response.Content.ReadFromJsonAsync<User>();
                    if (user != null)
                    {
                        // Optionally store user information in session or cookies
                        HttpContext.Session.SetString("UserEmail", user.EmailAddress);
                        return RedirectToAction("Index", "Books"); // Redirect to home or another appropriate action
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            return View(); // Return to the login view if the model state is invalid
        }
        // GET: Users/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Users/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                var response = await client.PostAsJsonAsync(UsersApiUrl, user);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<User>();
                    // Handle successful registration (e.g., redirect to login or welcome page)
                    return RedirectToAction("Index", "Home"); // Redirect to home or another appropriate action
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
                }
            }
            return View(user); // Return to the registration view with the current user data if model state is invalid
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserEmail"); // Clear the user session
            return RedirectToAction("Index", "Home"); // Redirect to home or another action
        }
    }

}
