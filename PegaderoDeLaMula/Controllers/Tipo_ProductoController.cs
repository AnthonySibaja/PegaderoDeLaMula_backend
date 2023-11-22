using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PegaderoDeLaMula.Data;
using PegaderoDeLaMula.Models;
using PegaderoDeLaMula.Models.Dto;
using PegaderoDeLaMula.Repository;

namespace PegaderoDeLaMula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class Tipo_ProductoController : ControllerBase
    {

        private readonly ITipoProductoRepository _tipoProductoRepository;
        protected ResponseDto _response;

        public Tipo_ProductoController(ITipoProductoRepository tipoProductoRepository)
        {
            _tipoProductoRepository = tipoProductoRepository;
            _response = new ResponseDto();
        }

        // GET: api/TiposProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoProducto>>> GetTIPO_PRODUCTO()
        {
            try
            {
                var lista = await _tipoProductoRepository.GetTiposProductos();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Productos";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
            }

            return Ok(_response);
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoProducto>> GetTipoProducto(int id)
        {
            var tipoProducto = await _tipoProductoRepository.GetTipoProductoById(id);
            if (tipoProducto == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Producto No Existente";
                return NotFound(_response);
            }
            _response.Result = tipoProducto;
            _response.DisplayMessage = "Información Producto";
            return Ok(_response);
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoProducto(int id, TipoProductoDto tipoProductoDto)
        {
            try
            {
                TipoProductoDto model = await _tipoProductoRepository.CreateUpdate(tipoProductoDto);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el registro";
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoProducto>> PostTipoProducto(TipoProductoDto tipoProductoDto)
        {
            try
            {
                TipoProductoDto model = await _tipoProductoRepository.CreateUpdate(tipoProductoDto);
                _response.Result = model;
                return CreatedAtAction("GetTipoProducto", new { id = model.ID_TIPO_PRODUCTO}, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el registro";
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoProducto(int id)
        {
            try
            {
                bool estaEliminado = await _tipoProductoRepository.DeleteTipoProducto(id);
                if (estaEliminado)
                {
                    _response.Result = estaEliminado;
                    _response.DisplayMessage = "Tipo de producto eliminado con exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar el tipo de producto";
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
    }
}
