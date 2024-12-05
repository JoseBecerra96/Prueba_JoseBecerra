using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            Model.DataResult<Model.Usuario> dataResult = Business.Usuario.GetAll();
            if (dataResult.Result)
            {
                return Ok(dataResult);
            }
            else { 
                return BadRequest(dataResult);
            }
        }

        [HttpPost]
        public IActionResult Add(Model.Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Model.DataResult<Model.Usuario> dataResult = Business.Usuario.Add(usuario);
            if (dataResult.Result)
            {
                return Ok(dataResult);
            }
            else
            {
                return BadRequest(dataResult);
            }

        }

        [HttpPut]
        public IActionResult Update(Model.Usuario usuario)
        {
            Model.DataResult<Model.Usuario> dataResult = Business.Usuario.Update(usuario);
            if (dataResult.Result)
            {
                return Ok(dataResult);
            }
            else
            {
                return BadRequest(dataResult);
            }

        }

        [HttpDelete]
        [Route("{idUsuario}")]
        public IActionResult Delete([FromRoute] int idUsuario)
        {
            Model.DataResult<Model.Usuario> dataResult = Business.Usuario.Delete(idUsuario);
            if (dataResult.Result)
            {
                return Ok(dataResult);
            }
            else
            {
                return BadRequest(dataResult);
            }

        }

        [HttpGet]
        [Route("{idUsuario}")]
        public IActionResult GetById([FromRoute] int idUsuario)
        {
            Model.DataResult<Model.Usuario> dataResult = Business.Usuario.GetById(idUsuario);
            if (dataResult.Result)
            {
                return Ok(dataResult);
            }
            else
            {
                return BadRequest(dataResult);
            }

        }
    }
}
