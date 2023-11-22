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
    public class InventariosController : ControllerBase
    {
        private readonly IInventarioRepository _inventarioRepository;
        protected ResponseDto _response;

        public InventariosController(IInventarioRepository inventarioRepository)
        {
            _inventarioRepository = inventarioRepository;
            _response = new ResponseDto();
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventario>>> GetINVENTARIO()
        {
            try
            {
                var lista = await _inventarioRepository.GetInventario();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Inventario";
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
        public async Task<ActionResult<Inventario>> GetInventario(int id)
        {
            var inventario = await _inventarioRepository.GetInventarioById(id);
            if (inventario == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Inventario no existe";
                return NotFound(_response);
            }
            _response.Result = inventario;
            _response.DisplayMessage = "Información del inventario";
            return Ok(_response);
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventario(int id, InventarioDto inventarioDto)
        {
            try
            {
                InventarioDto model = await _inventarioRepository.CreateUpdate(inventarioDto);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar el producto";
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inventario>> PostInventario(InventarioDto inventarioDto)
        {
            try
            {
                InventarioDto model = await _inventarioRepository.CreateUpdate(inventarioDto);
                _response.Result = model;
                return CreatedAtAction("GetInventario", new { id = model.ID_PRODUCTO }, _response);
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
        public async Task<IActionResult> DeleteInventario(int id)
        {
            try
            {
                bool estaEliminado = await _inventarioRepository.DeleteInventario(id);
                if (estaEliminado)
                {
                    _response.Result = estaEliminado;
                    _response.DisplayMessage = "Inventario eliminado con exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar el inventario";
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
