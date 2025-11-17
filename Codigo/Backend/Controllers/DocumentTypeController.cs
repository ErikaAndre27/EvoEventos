using BackEvoEventos.Models;
using BackEvoEventos.Repositories.Implementations;
using BackEvoEventos.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEvoEventos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeRepository _DocumentTypeRepository;

        public DocumentTypeController(IDocumentTypeRepository DocumentTypeRepository)
        {
            _DocumentTypeRepository = DocumentTypeRepository;
        }

        [HttpGet("GetAllDocumentTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllDocumentTypes() // IActionResult es un tipo de retorno genérico para una acción de controlador
        {
            try
            {
                var DocumentTypes = await _DocumentTypeRepository.GetAllDocumentTypes();
                if (DocumentTypes == null || !DocumentTypes.Any())
                {
                    return NotFound("No se encontraron tipos de documentos.");
                }

                return Ok(DocumentTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los usuarios: " + ex.Message);
            }
        }

        [HttpGet("GetDocumentTypeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDocumentTypeById(Guid Id)
        {
            try
            {
                var DocumentType = await _DocumentTypeRepository.GetDocumentTypeById(Id);
                if (DocumentType == null)
                {
                    return NotFound("No se encontró el tipo de documento.");
                }

                return Ok(User);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el tipo de documento: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPost("CreateDocumentType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateDocumentType([FromBody] DocumentType DocumentType)
        {
            try
            {
                var Result = await _DocumentTypeRepository.CreateDocumentType(DocumentType);
                if (!Result)
                {
                    return BadRequest("No se pudo crear tipo de documento.");
                }

                return Ok("Tipo de documento creado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el tipo de documento: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpPut("UpdateDocumentType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateDocumentType(Guid Id, [FromBody] DocumentType UpdateDocumentType)
        {
            try
            {
                var Result = await _DocumentTypeRepository.UpdateDocumentType(Id, UpdateDocumentType);
                if (!Result)
                {
                    return BadRequest("No se pudo actualizar el tipo de documento.");
                }
                return Ok("Tipo de documento actualizado correctamemnte");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el tipo de documento: " + ex.Message);
            }
        }

        [Authorize(Policy = "RequireAdmin")]
        [HttpDelete("DeleteDocumentType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteUser(Guid Id)
        {
            try
            {
                var Result = await _DocumentTypeRepository.DeleteDocumentType(Id);
                if (!Result)
                {
                    return BadRequest("No se pudo eliminar el tipo de documento.");
                }

                return Ok("Tipo de documento eliminado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el tipo de documento: " + ex.Message);
            }
        }


    }
}
