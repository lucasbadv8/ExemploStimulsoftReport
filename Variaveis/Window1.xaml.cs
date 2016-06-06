using System.Windows;
using Stimulsoft.Report;

namespace Variaveis
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1
    {
        private readonly StiReport stiReport1 = new StiReport();

        public Window1()
        {
            StiOptions.Wpf.CurrentTheme = StiOptions.Wpf.Themes.Office2013Theme;
            Stimulsoft.Report.Wpf.StiThemesHelper.LoadTheme(this);
            InitializeComponent();
        }

        private void Design_Click(object sender, RoutedEventArgs e)
        {
            stiReport1.Load("..\\..\\Variaveis.mrt");
            stiReport1.DesignWithWpf();
        }

        private void Imprimir_Click(object sender, RoutedEventArgs e)
        {
            stiReport1.Load("..\\..\\Variaveis.mrt");
            stiReport1.Compile();

            stiReport1["Nome"] = TbNome.Text;
            stiReport1["Sobrenome"] = TbSobrenome.Text;
            stiReport1["Email"] = TbEmail.Text;
            stiReport1["Endereco"] = TbEndereco.Text;
            stiReport1["Sexo"] = RbM.IsChecked.GetValueOrDefault();

            stiReport1.ShowWithWpf();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
