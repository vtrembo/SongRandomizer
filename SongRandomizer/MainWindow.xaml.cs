using SongRandomizer.Helper;
using SongRandomizer.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace SongRandomizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ButtonGenerateSong_Click(object sender, RoutedEventArgs e)
        {

         if (!String.IsNullOrEmpty(userInput.Text.ToString()))
         {
            int amountOfWords = Int32.Parse(userInput.Text);
            if(amountOfWords > 5 && amountOfWords < 20)
            {
                    RandomWord randomWord = await RandomWordProcessor.LoadRandomWord();
                    ErrorMessage.Content = randomWord.Word;
                } else
             {
                    ErrorMessage.Visibility = Visibility.Visible;
             }
          } else
          {
                ErrorMessage.Visibility = Visibility.Visible;
          }
        }
        private async Task LoadWord(int amountOfWords)
        {

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
