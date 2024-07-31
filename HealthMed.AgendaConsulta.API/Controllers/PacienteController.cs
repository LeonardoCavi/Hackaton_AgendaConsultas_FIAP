using AutoMapper;
using HealthMed.AgendaConsulta.Application.Services.Interface;
using HealthMed.AgendaConsulta.Application.ViewModels;
using HealthMed.AgendaConsulta.Application.ViewModels.Paciente;
using HealthMed.AgendaConsulta.Domain.Interfaces.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthMed.AgendaConsulta.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController(IMapper mapper,
                                    IPacienteApplicationService applicationService,
                                    INotificador notificador)  : ControllerBase
    {
        [HttpPost("autenticar")]
        public async Task<IActionResult> Autenticar(AutenticacaoViewModel autenticacao)
        {
            try
            {
                var token = await applicationService.AutenticarPaciente(autenticacao);

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

        [Authorize]
        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar(CadastraPacienteViewModel paciente)
        {
            try
            {
                await applicationService.CadastrarPaciente(paciente);

                if (notificador.TemNotificacao())
                {
                    var resposta = mapper.Map<ErroViewModel>(notificador.ObterNotificacoes());
                    return StatusCode(resposta.StatusCode, resposta);
                }

                return Created();
            }
            catch (Exception ex)
            {
                var resposta = mapper.Map<ErroViewModel>(ex);
                return StatusCode(resposta.StatusCode, resposta);
            }
        }

        [Authorize]
        [HttpGet("buscar-medicos")]
        public async Task<IActionResult> BuscarMedicos(DateTime inicio, DateTime fim)
        {
            try
            {
                var retorno = await applicationService.BuscarMedicos(inicio, fim);

                if (notificador.TemNotificacao())
                {
                    var resposta = mapper.Map<ErroViewModel>(notificador.ObterNotificacoes());
                    return StatusCode(resposta.StatusCode, resposta);
                }

                return Created();
            }
            catch (Exception ex)
            {
                var resposta = mapper.Map<ErroViewModel>(ex);
                return StatusCode(resposta.StatusCode, resposta);
            }
        }

        [Authorize]
        [HttpPost("{id}/agendar-consulta")]
        public async Task<IActionResult> AgendarConsulta(AgendaConsultaViewModel agendaConsulta)
        {
            try
            {
                var retorno = await applicationService.AgendarConsulta(agendaConsulta);

                if (notificador.TemNotificacao())
                {
                    var resposta = mapper.Map<ErroViewModel>(notificador.ObterNotificacoes());
                    return StatusCode(resposta.StatusCode, resposta);
                }

                return Created();
            }
            catch (Exception ex)
            {
                var resposta = mapper.Map<ErroViewModel>(ex);
                return StatusCode(resposta.StatusCode, resposta);
            }
        }
    }
}
