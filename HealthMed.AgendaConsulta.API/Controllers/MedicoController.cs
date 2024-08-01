using AutoMapper;
using HealthMed.AgendaConsulta.Application.Services.Interface;
using HealthMed.AgendaConsulta.Application.ViewModels;
using HealthMed.AgendaConsulta.Application.ViewModels.Medico;
using HealthMed.AgendaConsulta.Domain.Interfaces.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthMed.AgendaConsulta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController(IMapper mapper,
                                  IMedicoApplicationService applicationService,
                                  INotificador notificador) : ControllerBase
    {
        [HttpPost("autenticar")]
        public async Task<IActionResult> Autenticar(AutenticacaoViewModel autenticacao)
        {
            try
            {
                var token = await applicationService.AutenticarMedico(autenticacao);

                if (notificador.TemNotificacao())
                {
                    var resposta = mapper.Map<ErroViewModel>(notificador.ObterNotificacoes());
                    return StatusCode(resposta.StatusCode, resposta);
                }

                return Created("", token);
            }
            catch (Exception ex)
            {
                var resposta = mapper.Map<ErroViewModel>(ex);
                return StatusCode(resposta.StatusCode, resposta);
            }
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar(CadastraMedicoViewModel medico)
        {
            try
            {
                await applicationService.CadastrarMedico(medico);

                if (notificador.TemNotificacao())
                {
                    var resposta = mapper.Map<ErroViewModel>(notificador.ObterNotificacoes());
                    return StatusCode(resposta.StatusCode, resposta);
                }

                return Created("", "Médico cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                var resposta = mapper.Map<ErroViewModel>(ex);
                return StatusCode(resposta.StatusCode, resposta);
            }
        }

        [Authorize(Roles = "Medico")]
        [HttpPut("{id}/editar-expediente")]
        public async Task<IActionResult> EditarExpediente(int id, EditaExpedienteViewModel editaExpediente)
        {
            try
            {
                await applicationService.EditarExpediente(id, editaExpediente);

                if (notificador.TemNotificacao())
                {
                    var resposta = mapper.Map<ErroViewModel>(notificador.ObterNotificacoes());
                    return StatusCode(resposta.StatusCode, resposta);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                var resposta = mapper.Map<ErroViewModel>(ex);
                return StatusCode(resposta.StatusCode, resposta);
            }
        }
    }
}
