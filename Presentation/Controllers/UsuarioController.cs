using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;

namespace Presentation.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly HttpClient _httpClient;

        public UsuarioController(HttpClient _httpClient) 
        {
            this._httpClient = _httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _httpClient.GetAsync("Usuario");
                var data = await response.Content.ReadAsStringAsync();
                Model.DataResult<Model.Usuario> dataResult = JsonSerializer.Deserialize<Model.DataResult<Model.Usuario>>(data);

                if (dataResult.Message.IsNullOrEmpty())
                {
                    return View(dataResult.Values);
                }
                else
                {
                    TempData["ModalMessage"] = $"Ocurrio un error: {dataResult.Message}";
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                TempData["ModalMessage"] = $"Ocurrio un Error: {ex.Message}";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Form(int? IdUsuario)
        {
            if (IdUsuario == 0) {
                return View(new Model.Usuario());
            }
            else
            {
                try
                {
                    var response = await _httpClient.GetAsync($"Usuario/{IdUsuario}");
                    response.EnsureSuccessStatusCode();

                    var data = await response.Content.ReadAsStringAsync();
                    Model.DataResult<Model.Usuario> dataResult = JsonSerializer.Deserialize<Model.DataResult<Model.Usuario>>(data);

                    if (dataResult.Result)
                    {
                        return View(dataResult.Value);
                    }
                    else
                    {
                        TempData["ModalMessage"] = $"Ocurrio un error: {dataResult.Message}";
                        return RedirectToAction("GetAll");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ModalMessage"] = $"Ocurrio un Error: {ex.Message}";
                    return RedirectToAction("GetAll");
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Form(Model.Usuario usuario)
        {
            try
            {
                var response = new HttpResponseMessage();
              
                if (usuario.IdUsuario == 0)
                {
                    response = await _httpClient.PostAsJsonAsync("Usuario", usuario);
                }
                else
                {
                    response = await _httpClient.PutAsJsonAsync("Usuario", usuario);
                }
                if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {

                    return View();
                }

                var data = await response.Content.ReadAsStringAsync();
                Model.DataResult<Model.Usuario> dataResult = JsonSerializer.Deserialize<Model.DataResult<Model.Usuario>>(data);

                if (dataResult.Result)
                {
                    TempData["ModalMessage"] = "Operación Exitosa";
                }
                else
                {
                    TempData["ModalMessage"] = $"Ocurrio un error: {dataResult.Message}";                   
                }
            }
            catch (Exception ex)
            {
                TempData["ModalMessage"] = $"Ocurrio un Error: {ex.Message}"; 
            }
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int IdUsuario)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Usuario/{IdUsuario}");
                response.EnsureSuccessStatusCode();

                var data = await response.Content.ReadAsStringAsync();
                Model.DataResult<Model.Usuario> dataResult = JsonSerializer.Deserialize<Model.DataResult<Model.Usuario>>(data);

                if (dataResult.Result)
                {
                    TempData["ModalMessage"] = "Operación Exitosa";
                }
                else
                {
                    TempData["ModalMessage"] = $"Ocurrio un error: {dataResult.Message}";
                }
            }
            catch (Exception ex)
            {
                TempData["ModalMessage"] = $"Ocurrio un Error: {ex.Message}";
            }
            return RedirectToAction("GetAll");
        }
    }
}
