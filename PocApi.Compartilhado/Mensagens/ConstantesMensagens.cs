﻿namespace PocApi.Compartilhado.Menssagens
{
    public static class ConstantesMensagens
    {
        public const string OperacaoConcluidaComSucesso = "Operação concluída com sucesso!";
        public const string NenhumRegistroLocalizado = "Nenhum registro localizado!";
        public const string ClienteNaoLocalizado = "Cliente não localizado";
        public const string PedidoNaoEncontrado = "Pedido não encontrado";
        public const string SenhaInvalida = "Senha inválida";
        public const string NenhumRegistroSelecionado = "Nenhum registro selecionado!";
        public const string NaoFoiPossivelConcluirOperacao = "Não foi possivel concluir operação";

        public static string EmailJaExiste(string email) => $"Email {email} já cadastrado!";
    }
}