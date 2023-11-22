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
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        protected ResponseDto _response;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
            _response = new ResponseDto();
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetCLIENTE()
        {
            try
            {
                var lista = await _clienteRepository.GetClientes();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Clientes";
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
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _clienteRepository.GetClienteById(id);
            if (cliente == null)
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Cliente no existe";
                return NotFound(_response);
            }
            _response.Result = cliente;
            _response.DisplayMessage = "Información del cliente";
            return Ok(_response);
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, ClienteDto clienteDto)
        {
            try
            {
                ClienteDto model = await _clienteRepository.CreateUpdate(clienteDto);
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
        public async Task<ActionResult<Cliente>> PostCliente(ClienteDto clienteDto)
        {
            try
            {
                ClienteDto model = await _clienteRepository.CreateUpdate(clienteDto);
                _response.Result = model;
                return CreatedAtAction("GetCliente", new { id = model.ID_CLIENTE }, _response);
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
        public async Task<IActionResult> DeleteCliente(int id)
        {
            try
            {
                bool estaEliminado = await _clienteRepository.DeleteCliente(id);
                if (estaEliminado)
                {
                    _response.Result = estaEliminado;
                    _response.DisplayMessage = "Cliente eliminado con exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.DisplayMessage = "Error al eliminar el cliente";
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
