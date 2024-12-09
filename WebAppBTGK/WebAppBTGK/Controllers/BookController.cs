using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebAppBTGK.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unit;
        public BookController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        // GET: Book/Index
        public async Task<IActionResult> Index()
        {
            // Lấy danh sách sách từ cơ sở dữ liệu
            var books = await _unit.Book.GetAllAsync();
            return View(books); // Trả về view Index với danh sách sách
        }

        // GET: Book/Create
        public async Task<IActionResult> Create()
        {
            var genres = await _unit.Genre.GetAllAsync();
            var book = new Book
            {
                Title = string.Empty, // Initialize required property
                Author = string.Empty // Initialize required property
            };
            // You can pass the list of genres to the view as well if needed
            ViewBag.Genres = genres;
            return View(book); // Trả về view tạo sách
        }

        // POST: Book/Create
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (book == null)
            {
                return BadRequest("Book cannot be null");
            }
            if (!ModelState.IsValid)
                return View(book); // Nếu dữ liệu không hợp lệ, trả về lại form tạo sách

            // Thêm sách vào cơ sở dữ liệu
            _unit.Book.Add(book);

            if (await _unit.Complete())
                return RedirectToAction("Index"); // Sau khi lưu thành công, chuyển hướng về trang danh sách sách

            return View(book); // Nếu lưu thất bại, trả về lại form tạo sách
        }

        // GET: Book/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            // Lấy thông tin sách cần chỉnh sửa
            var book = await _unit.Book.GetAsync(b => b.Id == id);
            if (book == null)
                return NotFound("Book not found"); // Nếu không tìm thấy sách, trả về lỗi
            var genres = await _unit.Genre.GetAllAsync();
            ViewBag.Genres = genres;
            return View(book); // Trả về form chỉnh sửa sách với dữ liệu
        }

        // POST: Book/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            if (!ModelState.IsValid)
                return View(book); // Nếu dữ liệu không hợp lệ, trả về form chỉnh sửa sách

            // Lấy thông tin sách từ cơ sở dữ liệu
            var bookFromDb = await _unit.Book.GetAsync(b => b.Id == book.Id);
            if (bookFromDb == null)
                return BadRequest("Book not found"); // Nếu không tìm thấy sách trong cơ sở dữ liệu, trả về lỗi

            // Cập nhật sách
            _unit.Book.Update(book);

            if (await _unit.Complete())
                return RedirectToAction("Index"); // Sau khi cập nhật thành công, chuyển hướng về trang danh sách sách

            return View(book); // Nếu cập nhật thất bại, trả về form chỉnh sửa sách
        }

        // GET: Book/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            // Lấy thông tin sách cần xóa
            var book = await _unit.Book.GetAsync(b => b.Id == id);
            if (book == null)
                return NotFound("Book not found"); // Nếu không tìm thấy sách, trả về lỗi

            return View(book); // Trả về form xác nhận xóa sách
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Lấy thông tin sách cần xóa
            var book = await _unit.Book.GetAsync(b => b.Id == id);
            if (book == null)
                return NotFound("Book not found"); // Nếu không tìm thấy sách, trả về lỗi

            // Xóa sách
            _unit.Book.Remove(book);

            if (await _unit.Complete())
                return RedirectToAction("Index"); // Sau khi xóa thành công, chuyển hướng về trang danh sách sách

            return View(book); // Nếu xóa thất bại, trả về lại form xác nhận xóa
        }

    }
}
