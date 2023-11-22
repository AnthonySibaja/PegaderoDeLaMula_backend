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
    public class DetallesController : ControllerBase
    {
        private readonly IDetallesRepository _detallesRepository;
        protected ResponseDto _response;

        public DetallesController(IDetallesRepository detallesRepository)
        {
            _detallesRepository = detallesRepository;
            _response = new ResponseDto();
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Detalles>>> GetDDA()
        {
            try
            {
                var lista = await _detallesRepository.GetDetalles();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de productos";
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
        public async Task<ActionResult<Detalles>> GetDetalle(int id)
        {
            var detalles = await _detallesRepository.GetDetalleById(id);
            if (detalles == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Producto no existe";
                return NotFound(_response);
            }
            _response.Result = detalles;
            _response.DisplayMessage = "Información del producto";
            return Ok(_response);
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalle(int id, DetallesDto detallesDto)
        {
            try
            {
                DetallesDto model = await _detallesRepository.CreateUpdate(detallesDto);
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
        public async Task<ActionResult<Detalles>> PostDetalle(DetallesDto detallesDto)
        {
            try
            {
                DetallesDto model = await _detallesRepository.CreateUpdate(detallesDto);
                _response.Result = model;
                return CreatedAtAction("GetDetalle", new { id = model.NUMERO_PRODUCTO }, _response);
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
        public async Task<IActionResult> DeleteDetalle(int id)
        {
            try
            {
                bool estaEliminado = await _detallesRepository.DeleteDetalle(id);
                if (estaEliminado)
                {
                    _response.Result = estaEliminado;
                    _response.DisplayMessage = "Producto eliminado con exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar el Producto";
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
