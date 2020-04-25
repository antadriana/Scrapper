using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfClient.Model;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        InfoWindowViewModel _viewModel;
        CollectionViewSource _infosCollection;
        public InfoWindow()
        {
            _viewModel = new InfoWindowViewModel();
            DataContext = _viewModel;
            InitializeComponent();

            _infosCollection = (CollectionViewSource)(Resources["InfosCollection"]);
        }

     

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _infosCollection.View.Refresh();
        }

        private void FeedbackClick(Info inf, bool like)
        {
            _viewModel.Like(inf, like);
            _viewModel.Update();
        }

        private void Like_Click(object sender, RoutedEventArgs e)
        {
            var n = ((FrameworkElement)sender).DataContext as Model.Info;
            FeedbackClick(n, true);
        }

        private void Dislike_Click(object sender, RoutedEventArgs e)
        {
            var n = ((FrameworkElement)sender).DataContext as Model.Info;
            FeedbackClick(n, false);
        }
    }
}
