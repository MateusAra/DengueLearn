namespace DengueLearn.Messages
{
    public static class Messages
    {
        public const string NotFoundPacient = "Paciente não encontrado!";
        public const string NotFoundUser = "User não encontrado!";
        public const string CompletedRegister = "Cadastro realizado com sucesso!";
        public const string CompletedConsult = "Consulta agendada com sucesso!";
        public const string CompletedUpdate = "Atualização realizada com sucesso!";
        public const string CompletedDelete = "Exclusão realizada com sucesso!";
        public const string ErrorRegister = "Erro ao realizar cadastro!";
        public const string ErrorUpdate = "Erro ao realizar atualização!";
        public const string ErrorDelete = "Erro ao realizar exclusão!";
        public const string UserNameExists = "Email já cadastrado, tente outro.";
        public const string PacientExists = "Paciente já cadastrado com este cpf/cnpj.";
        public const string LoginError = "Verifique as informações de login e tente novamente!";
        public const string ResetSuccess = "Senha resetada com sucesso! Enviamos a nova senha para o email cadastrado.";
        public const string NotFoundConsult = "Consulta não encontrada.";
        public const string ConsultExists = "Já existe consulta marcada para o mesmo horário.";
        public const string TaxNumberRequired = "Insira o CPF do paciente.";
        public const string ScheduleHourRequired = "A hora da consulta deve ser após a atual.";
        public const string ScheduleDayRequired = "O dia da consulta deve ser maior ou igual o atual.";
        public const string StatusRequired = "Selecione o status da consulta.";
        public const string ConsultFinalized = "Consulta finalizada com sucesso.";
        public const string ConsultErrorFinalized = "Erro ao finalizar consulta.";
    }
}
