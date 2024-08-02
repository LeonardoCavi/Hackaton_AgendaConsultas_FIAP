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
                                    INotificador notificador) : ControllerBase
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

                return Created("", "Paciente cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                var resposta = mapper.Map<ErroViewModel>(ex);
                return StatusCode(resposta.StatusCode, resposta);
            }
        }

        [Authorize(Roles = "Paciente")]
        [HttpGet("buscar-medicos")]
        public async Task<IActionResult> BuscarMedicos(DateTime dia)
        {
            try
            {
                var retorno = await applicationService.BuscarMedicos(dia);

                if (notificador.TemNotificacao())
                {
                    var resposta = mapper.Map<ErroViewModel>(notificador.ObterNotificacoes());
                    return StatusCode(resposta.StatusCode, resposta);
                }

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                var resposta = mapper.Map<ErroViewModel>(ex);
                return StatusCode(resposta.StatusCode, resposta);
            }
        }

        [Authorize(Roles = "Paciente")]
        [HttpPost("{id}/agendar-consulta")]
        public async Task<IActionResult> AgendarConsulta(int id, AgendaConsultaViewModel agendaConsulta)
        {
            try
            {
                await applicationService.AgendarConsulta(id, agendaConsulta);

                if (notificador.TemNotificacao())
                {
                    var resposta = mapper.Map<ErroViewModel>(notificador.ObterNotificacoes());
                    return StatusCode(resposta.StatusCode, resposta);
                }

                return Created("", "Consulta agendada com sucesso!");
            }
            catch (Exception ex)
            {
                var resposta = mapper.Map<ErroViewModel>(ex);
                return StatusCode(resposta.StatusCode, resposta);
            }
        }
    }
}
