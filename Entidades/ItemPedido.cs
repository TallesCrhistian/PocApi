﻿namespace Entidades
{
    public class ItemPedido
    {
        public int IdItemPedido { get; set; }
        public int IdPedido { get; set; }
        public int Ordem { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public Pedido Pedido { get; set; }
    }
}