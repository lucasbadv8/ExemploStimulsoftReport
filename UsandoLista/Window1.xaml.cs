using System.Linq;
using System.Windows;
using Stimulsoft.Report;

namespace UsandoLista
{
    public partial class Window1 : Window
    {
        private StiReport report = new StiReport();
        public Window1()
        {
            StiOptions.Wpf.CurrentTheme = StiOptions.Wpf.Themes.Office2013Theme;
            Stimulsoft.Report.Wpf.StiThemesHelper.LoadTheme(this);
            InitializeComponent();

            Item[] items = { new Book{Id = 1, Preco = 13.50, Genero = "Comédia", Autor = "Jão Neves"},
                             new Book{Id = 2, Preco = 8.50, Genero = "Drama", Autor = "John Snow"},
                             new Movie{Id = 4, Preco = 22.99, Genero = "Comédia", Diretor = "Woody Allen"},
                             new Movie{Id = 3, Preco = 13.40, Genero = "Ação", Diretor = "Spielberg"}};


            var consulta = from i in items
                           orderby i.Preco
                           select i;

            report.Load("..\\..\\Report.mrt");

            report.RegBusinessObject("MyData", "MyData", consulta);
        }



        private void Imprimir_Click(object sender, RoutedEventArgs e)
        {
            report.ShowWithWpf();
        }

        private void Design_Click(object sender, RoutedEventArgs e)
        {
            report.DesignWithWpf();
        }

        private void Fechar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}