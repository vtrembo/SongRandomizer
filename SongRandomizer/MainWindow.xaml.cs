using SongRandomizer.Helper;
using SongRandomizer.MVVM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace SongRandomizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<string> words = new List<string>();

        public static Hashtable recordingInfo = new Hashtable();

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
                    await LoadWord(amountOfWords);
                }
                else
             {
                    ErrorMessage.Visibility = Visibility.Visible;
             }
          } else
          {
                ErrorMessage.Visibility = Visibility.Visible;
          }
            await LoadRecording();
        }
        private async Task LoadWord(int amountOfWords)
        {

            if(recordingInfo != null)
            {
                recordingInfo.Clear();
            }
            for (int i = 0; i < amountOfWords; i++)
            {
                RandomWord randomWord = await RandomWordProcessor.LoadRandomWord();
                if(recordingInfo != null)
                {
                    if (!recordingInfo.ContainsKey(randomWord.Word))
                    {
                        recordingInfo.Add(randomWord.Word, null);
                    } else
                    {
                        i--;
                    }
                } else
                {
                    recordingInfo.Add(randomWord.Word, null);
                }
            }
            foreach (string word in recordingInfo.Keys)
            {
                TestMsg.Content = TestMsg.Content + word + " ";
            }
        }

        private async Task LoadRecording()
        {
            foreach (string recording in recordingInfo.Keys)
            {
                recordingInfo[recording] = await RecordProcessor.LoadRecording(recording);
            }
        }


        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
