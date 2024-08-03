<h1 align="left">[Hackaton] - Agendador de Consultas - 🧪Health&Med💉 - FIAP 2024 - Pós Tech</h1>
😷 O projeto "Agendador de Consultas - Health&Med" é uma aplicação voltada para o cadastro e a gestão dos horários de trabalho de médicos e prestadores de serviços de saúde. Além disso, permite que os pacientes consultem a disponibilidade dos médicos para os dias e horários desejados e façam o agendamento de consultas, bloqueando a agenda do profissional. Ao final, o médico receberá uma notificação sobre o novo agendamento.

<img width="300" src="https://github.com/LeonardoCavi/Hackaton_AgendaConsultas_FIAP/blob/developer/Documentos/Banco%20de%20Dados/gatinho-medico.png" alt="Gatinho Médico" align="center"></img>

<h2 align="left">Integrantes</h3>
- 🤢 <a href="https://github.com/talles2512">Hebert Talles de Jesus Silva</a> - RM352000 </br> 
- 🤕 <a href="https://github.com/LeonardoCavi">Leonardo Cavichiolli de Oliveira</a> - RM351999 </br>

<h2 align="left">Projetos</h3>
- 🩻 HealthMed.AgendaConsulta.API</br>

<h2 align="left">🩼 Vídeo de Apresentação</h2>
<a href="https://www.youtube.com/watch?v=ERQXNPA3bnY">Apresentação do Projeto</a></br> 

<h2 align="left">Requisitos do Sistema do Projeto</h2>

<h4 align="left">👩🏽‍🔬 Cadastros - Médico/Prestador</h4>
- ➤ A API deve possibilitar o cadastro de médicos e prestadores de serviço no sistema, incluindo validações para dados inválidos ou já cadastrados, como CPF, CRM e e-mail. Além disso, a API deve permitir que os médicos se autentiquem no sistema. Após a autenticação, o médico deverá ser capaz de editar os dias e horários de trabalho, incluindo horários de entrada e saída.

<h4 align="left">🤒 Agendador de Consultas Médicas - Paciente/Cliente</h4>
- ➤ O paciente deverá ser capaz de se cadastrar na API, que também deve realizar validações para CPF e e-mail. Após o cadastro, o paciente poderá consultar a disponibilidade de médicos e prestadores de serviços de saúde, especificando a data e o horário desejados. Finalmente, o paciente deve poder agendar a consulta, bloqueando assim a agenda do médico.

<h4 align="left">🏥 Notificação (e-mail)</h4>
- ➤ Se a consulta for agendada com sucesso pelo paciente, o sistema deverá enviar um e-mail ao médico notificando-o sobre a nova consulta. O e-mail deve informar o nome do paciente, bem como a data e a hora da consulta.

<h2 align="left">👩🏽‍🔬 Cadastros - Médico/Prestador</h2>
<h4 align="left">➤ Cadastro de Médico/Prestador</h4>
<h4 align="left">-➤ Critério</h4>
-- ➤ 1. A API deve permitir o cadastro de médicos e prestadores de serviço com os seguintes dados: nome completo, CPF, CRM e e-mail.</br>
-- ➤ 2. O sistema deve validar se o CPF, CRM e e-mail são válidos e se não estão já cadastrados.</br>
-- ➤ 3. Se os dados forem inválidos ou já estiverem cadastrados, o sistema deve retornar mensagens de erro/validação apropriadas.</br>
<h4 align="left">➤ Verificação</h4>
-- ➤ 1. Realizar testes funcionais.</br>
-- ➤ 2. Criação de testes unitários para facilitar a validação.</br>
<h4 align="left">➤ Autenticação - Médico/Prestador</h4>
<h4 align="left">-➤ Critério</h4>
-- ➤ 1. Médicos devem ser capazes de se autenticar no sistema usando credenciais válidas.</br>
<h4 align="left">➤ Verificação</h4>
-- ➤ 1. Realizar testes funcionais.</br>
-- ➤ 2. Criação de testes unitários para facilitar a validação.</br>
<h4 align="left">➤ Gerenciamento de Horários - Médico/Prestador</h4>
<h4 align="left">-➤ Critério</h4>
-- ➤ 1. Após a autenticação, o médico deve ser capaz de editar os dias e horários de trabalho, incluindo horários de entrada e saída.</br>
-- ➤ 2. As alterações realizadas devem ser salvas e refletidas corretamente na agenda do médico (banco de dados).</br>
<h4 align="left">➤ Verificação</h4>
-- ➤ 1. Realizar testes funcionais.</br>
-- ➤ 2. Criação de testes unitários para facilitar a validação.</br>

<h2 align="left">🤒 Agendador de Consultas Médicas - Paciente/Cliente</h2>
<h4 align="left">➤ Cadastro de Paciente</h4>
<h4 align="left">-➤ Critério</h4>
-- ➤ 1. O paciente deve ser capaz de se cadastrar na API com os seguintes dados: nome completo, CPF e e-mail.</br>
-- ➤ 2. O sistema deve validar se o CPF e o e-mail são válidos e não estão já cadastrados.</br>
-- ➤ 3. Se os dados forem inválidos ou já estiverem cadastrados, o sistema deve retornar mensagens de erro/validação apropriadas.</br>
<h4 align="left">➤ Verificação</h4>
-- ➤ 1. Realizar testes funcionais.</br>
-- ➤ 2. Criação de testes unitários para facilitar a validação.</br>
<h4 align="left">➤ Consulta de Disponibilidade</h4>
<h4 align="left">-➤ Critério</h4>
-- ➤ 1. Após o cadastro, o paciente deve poder consultar a disponibilidade de médicos e prestadores de serviços de saúde especificando a data e o horário desejados.</br>
-- ➤ 2. O sistema deve retornar a lista de médicos e prestadores disponíveis para os parâmetros especificados.</br>
<h4 align="left">➤ Verificação</h4>
-- ➤ 1. Realizar testes funcionais.</br>
-- ➤ 2. Criação de testes unitários para facilitar a validação.</br>
<h4 align="left">➤ Agendamento de Consulta</h4>
<h4 align="left">-➤ Critério</h4>
-- ➤ 1. O paciente deve poder agendar uma consulta, selecionando um médico e um horário disponível.</br>
-- ➤ 2. A agenda do médico deve ser atualizada para refletir a nova consulta e o horário deve ser bloqueado.</br>
<h4 align="left">➤ Verificação</h4>
-- ➤ 1. Realizar testes funcionais.</br>
-- ➤ 2. Criação de testes unitários para facilitar a validação.</br>

<h2 align="left">🏥 Notificação (e-mail)</h2>
<h4 align="left">➤ Envio de Notificação</h4>
<h4 align="left">-➤ Critério</h4>
-- ➤ 1. Após o agendamento bem-sucedido da consulta, o sistema deve enviar um e-mail ao médico.</br>
-- ➤ 2. O e-mail deve incluir o nome do paciente, a data e a hora da consulta.</br>
<h4 align="left">➤ Verificação</h4>
-- ➤ 1. Realizar testes funcionais.</br>
-- ➤ 2. Criação de testes unitários para facilitar a validação.</br>

<h2 align="left">🧫 Testes</h3>
➤ <a href="https://leonardocavi.github.io/Hackaton_AgendaConsultas_FIAP/HealthMed.AgendaConsulta.Test/coveragereport/index.html"> Testes de Cobertura da API</a></br>

<h2 align="left">🦠 Documentação do Projeto</h2>
<h4 align="left">Projeto - HealthMed.AgendaConsulta.API</h4>
➤ A API foi desenvolvida utilizando o framework .NET Core 8, seguindo os princípios da Arquitetura Limpa, e foi implementada na IDE Visual Studio 2022. Para o gerenciamento do banco de dados, optamos pelo Entity Framework Core com SQL Server no Azure.

Para o serviço de notificação, utilizamos dois recursos do Azure: Azure Communication Service para comunicação e Azure Email Communication Service para o envio de e-mails.

<h4 align="left">🩹 Scripts de Banco de Dados</h4>
➤ Executar o seguinte script na base de dados.: 
<a href="https://github.com/LeonardoCavi/Hackaton_AgendaConsultas_FIAP/blob/developer/Documentos/Banco%20de%20Dados/script.sql">Script das Tabelas</a></br>

<h4 align="left">🧼 Diagrama do banco de dados</h4>
<img width="1200" src="https://github.com/LeonardoCavi/Hackaton_AgendaConsultas_FIAP/blob/developer/Documentos/Banco%20de%20Dados/diagrama%20tabelas.png"></img>

