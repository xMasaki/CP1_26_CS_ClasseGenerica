using System.Text;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CP1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Cadastro<Pessoa> cadastro = new Cadastro<Pessoa>();
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Realiza leitura dos campos
        /// Adiciona uma nova pessoa no cadastro
        /// </summary>
        private void BtnAdicionarClick(object sender, RoutedEventArgs e)
        {
            try
            {
                // Lê id e transforma em int
                int id = int.Parse(EntradaID.Text);

                // Lê nome e armazena
                string nome = EntradaNome.Text;

                // Cria novo objeto Pessoa
                Pessoa pessoa = new Pessoa(nome, 0);

                // Adiciona no cadastro
                if(cadastro.Adicionar(id, pessoa))
                {
                    MessageBox.Show("Pessoa adicionada!");

                    // Atualiza DataGrid
                    AtualizarTabela();
                }
                else
                {
                    MessageBox.Show("Id existente");
                }
            }
            catch
            {
                MessageBox.Show("Digite um Id válido");
            }
        }

        /// <summary>
        /// Atualiza dados do cadastro no DataGrid
        /// </summary>
        private void BtnListarClick(object sender, RoutedEventArgs e)
        {
            AtualizarTabela();
        }

        /// <summary>
        /// Busca por um Id cadastrado e exibe no MessageBox 
        /// </summary>
        private void BtnBuscarClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(EntradaID.Text);

                // Busca pelo Id
                Pessoa pessoa = cadastro.Buscar(id);
                if(pessoa!=null)
                {
                    MessageBox.Show(pessoa.ToString());
                }
                else
                {
                    MessageBox.Show("Pessoa não encontrada");
                }
            }
            catch
            {
                MessageBox.Show("Digite um Id válido");
            }
        }

        /// <summary>
        /// Remove um dado cadastrado pelo Id
        /// </summary>
        private void BtnRemoverClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(EntradaID.Text);
                if(cadastro.Remover(id))
                {
                    MessageBox.Show("Pessoa Removida!");
                    AtualizarTabela();
                }
                else
                {
                    MessageBox.Show("Pessoa não encontrada");
                }
            }
            catch
            {
                MessageBox.Show("Digite um Id válido");
            }
        }

        /// <summary>
        /// Limpa os campos de Id e nome
        /// </summary>
        private void BtnLimparClick(object sender, RoutedEventArgs e)
        {
            EntradaID.Text = "";
            EntradaNome.Text = "";
        }

        /// <summary>
        /// Método para atualizar dados do DataGrid
        /// </summary>
        private void AtualizarTabela()
        {
            List<dynamic> lista = new List<dynamic>();

            foreach(var item in cadastro.Listar())
            {
                lista.Add(new 
                { 
                    Id = item.Key, Info = item.Value.ToString() 
                });
            }

            TabelaDados.ItemsSource = lista;
        }

        /// <summary>
        /// Busca por Id cadastrado, dessa vez mostrado no DataGrid
        /// </summary>
        private void BtnBuscarTabelaClick(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(EntradaBuscaId.Text);
                Pessoa pessoa = cadastro.Buscar(id);
                List<dynamic> lista = new List<dynamic>();

                if (pessoa != null)
                {
                    lista.Add(new
                    {
                        Id = id,
                        Info = pessoa.ToString()
                    });
                }
                else
                {
                    MessageBox.Show("Pessoa não encontrada");
                    return;
                }

                    TabelaDados.ItemsSource = lista;
            }
            catch
            {
                MessageBox.Show("Digite um Id válido");
            }
        }
    }
}