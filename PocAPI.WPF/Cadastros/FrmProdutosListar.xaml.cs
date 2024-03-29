﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PocAPI.WPF.Cadastros
{
    /// <summary>
    /// Lógica interna para FrmProdutosListar.xaml
    /// </summary>
    public partial class FrmProdutosListar : Window
    {
        public FrmProdutosListar()
        {
            InitializeComponent();
        }

        private void btnIncluir_Click(object sender, RoutedEventArgs e)
        {
            ExibirCadastroProduto();
        }

        private bool ExibirCadastroProduto()
        {
            FrmCadastroProduto frmCadastroProduto = new FrmCadastroProduto();
            frmCadastroProduto.Owner = this;
            bool? resultado = frmCadastroProduto.ShowDialog();
            return resultado == true;
        }
    }
}