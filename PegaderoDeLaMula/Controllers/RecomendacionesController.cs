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
    public class RecomendacionesController : ControllerBase
    {

        private readonly IRecomendacionesRepository _recomendacionesRepository;
        protected ResponseDto _response;

        public RecomendacionesController(IRecomendacionesRepository recomendacionesRepository)
        {
            _recomendacionesRepository = recomendacionesRepository;
            _response = new ResponseDto();
        }

        // GET: api/TiposProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recomendaciones>>> GetRECOMENDACIONES()
        {
            try
            {
                var lista = await _recomendacionesRepository.GetRecomendaciones();
                _response.Result = lista;
                _response.DisplayMessage = "Recomendaciones";
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
        public async Task<ActionResult<Recomendaciones>> GetRecomendaciones(int id)
        {
            var recomendaciones = await _recomendacionesRepository.GetRecomendacionesById(id);
            if (recomendaciones == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "No Existente";
                return NotFound(_response);
            }
            _response.Result = recomendaciones;
            _response.DisplayMessage = "Información";
            return Ok(_response);
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecomendaciones(int id, RecomendacionesDto recomendaciones)
        {
            try
            {
                RecomendacionesDto model = await _recomendacionesRepository.CreateUpdate(recomendaciones);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al comentario";
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoProducto>> PostRecomendaciones(RecomendacionesDto recomendaciones)
        {
            try
            {
                RecomendacionesDto model = await _recomendacionesRepository.CreateUpdate(recomendaciones);
                _response.Result = model;
                return CreatedAtAction("GetRecomendaciones", new { id = model.ID_RECOMENDACIONES }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Error al actualizar COMENTARIO";
                _response.ErrorMessage = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecomendaciones(int id)
        {
            try
            {
                bool estaEliminado = await _recomendacionesRepository.DeleteRecomendaciones(id);
                if (estaEliminado)
                {
                    _response.Result = estaEliminado;
                    _response.DisplayMessage = "Comentario eliminado con exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar el comentario";
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