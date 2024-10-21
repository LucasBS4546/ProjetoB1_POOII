using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz_Game_WPF_MOO_ICT
{
    public partial class MainWindow : Window
    {
        // create a new list of integers called question numbers
        // this interger will hold how many questions we have for this quiz and we will shuffle this inside the start game function
        List<int> questionNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        // create 3 more integers called qNum that will control which question shows on the screen, i and score
        int qNum = 0;
        int i;
        string writtenSubmission = "";
        string writtenAnswer = "";

        string ans1AltContent = "";
        string ans2AltContent = "";
        string ans3AltContent = "";
        string ans4AltContent = "";

        string ans1OgContent = "";
        string ans2OgContent = "";
        string ans3OgContent = "";
        string ans4OgContent = "";

        public MainWindow()
        {
            InitializeComponent();

            // inside of the main constructor we will run the start game and next question function

            StartGame();
            NextQuestion();
        }

        private void checkAnswer(object sender, RoutedEventArgs e)
        {
            // this is the check answer event, this event is linked to each button on the canvas
            // when either of the buttons will be pressed we will run this event

            Button senderButton = sender as Button; // first check which button sent this event and link it to a local button inside of this event

            // in the if statement below we will check if the button clicked on has a 1 tag inside of it, if it does then we will add 1 to the score
            if (senderButton.Tag.ToString() != "1")
            {
                RestartGame();
            }

            // if the qnum is less than 0 then we will reset the qnum integer to 0
            if (qNum < 0)
            {
                qNum = 0;
            }
            else
            {
                // if the qnum is greater than 0 then we will add 1 to the qnum integer
                qNum++;
            }

            // update the score text label each time the buttons are pressed
            currentQuestionText.Content = "Questão " + (qNum + 1) + "/" + questionNumbers.Count;

            // run the next question function
            NextQuestion();

        }

        private void checkWrittenAnswer(object sender, RoutedEventArgs e)
        {
            writtenSubmission = TextboxAnswer.Text;
            if (!writtenAnswer.Equals(writtenSubmission))
            {
                TextboxAnswer.Text = "";
                writtenSubmission = "";
                writtenAnswer = "";
                RestartGame();
            }

            writtenSubmission = "";
            writtenAnswer = "";
            TextboxAnswer.Text = "";

            if (qNum < 0)
            {
                qNum = 0;
            }
            else
            {
                qNum++;
            }

            currentQuestionText.Content = "Questão " + (qNum + 1) + "/" + questionNumbers.Count;


            NextQuestion();
        }

        private void RestartGame()
        {
            // restart game function will load all of the default values for this game
            qNum = -1; // set qnum to -1
            i = 0; // set i to 0
            GameOver(); // mostra a janela de "Você perdeu!" para o jogador
        }

        private void NextQuestion()
        {
            // this function will check which question to show next and it will have all of the question and answer definitions

            // in the if statement below it will checking if the qnum integer is less than the total number of questions if it then we will set the value of i to the value of qnum

            if (qNum < questionNumbers.Count)
            {
                i = questionNumbers[qNum];
            }
            else
            {
                // Se chegamos ao fim do quiz, quer dizer que o jogador venceu
                currentQuestionText.Content = "Questão " + qNum + "/" + questionNumbers.Count;
                new Venceu().Show();
                this.Close();
            }

            // below we are running a foreach loop where will check for each button inside of the canvas and when we find them we will set their tag to 0 and background to dakr salmon colour
            foreach (var x in myCanvas.Children.OfType<Button>())
            {
                x.Tag = "0";
                x.Background = Brushes.DarkSalmon;
                x.Foreground = Brushes.Black;
                x.FontWeight = FontWeights.Normal;
                x.Visibility = Visibility.Visible;
            }

            ans5.Background = Brushes.Transparent;
            ans5.Visibility = Visibility.Collapsed;
            ButtonSubmitWrittenAnswer.Visibility = Visibility.Collapsed;
            TextboxAnswer.Visibility = Visibility.Collapsed;
            TextboxAnswer.Text = "";

            ans1OgContent = "";
            ans2OgContent = "";
            ans3OgContent = "";
            ans4OgContent = "";

            ans1AltContent = "";
            ans2AltContent = "";
            ans3AltContent = "";
            ans4AltContent = "";

            // below you have all of the question and answers template
            // you can add your own questions to the txtQuestion section
            // and add your own answers inside of the ans1, ans2, ans3 content and so. 

            // this switch statement will check what value is inside of i integer and show the questions based on that value

            switch (i)
            {
                case 1:

                    txtQuestion.Text = "Questão 1"; // this the question for the quiz

                    ans1.Content = "IL"; // each of the buttons can have their own answers in this game
                    ans2.Content = "XLIX";
                    ans3.Content = "XXXXIX";
                    ans4.Content = "LIX";

                    ans2.Tag = "1"; // here we tell the program which one of the answers above is the right answer by adding the 1 inside of the tag for the button. 
                    // in this example we adding 1 inside of ans2 or button 2
                    // so when the button is clicked the game will know which is the correct answer and it add 1 to the score for the game

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/1.jpg")); // here we will load the 1st image inside of the qimage 

                    break; // when this condition is met the program will break the switch statement here and wait for the next one
                           // rest of the condition will follow the same principle as this one

                case 2:

                    txtQuestion.Text = "Questão 2";

                    ans1.Content = "←";
                    ans2.Content = "→";
                    ans3.Content = "Que?";
                    ans4.Content = "↑";

                    ans1.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/2.jpg"));

                    break;

                case 3:

                    txtQuestion.Text = "Questão 3";

                    ans1.Content = "3:49";
                    ans2.Content = "15:41";
                    ans3.Content = "2:51";
                    ans4.Content = "00:00";

                    ans3.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/3.jpg"));

                    break;

                case 4:

                    txtQuestion.Text = "Questão 4";

                    foreach (var x in myCanvas.Children.OfType<Button>())
                    {
                        x.FontWeight = FontWeights.Bold;
                    }

                    ans1.Content = "Essa!";
                    ans1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7093ff"));
                    ans2.Content = "Essa";
                    ans2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5673ca"));
                    ans3.Content = "Essa.";
                    ans3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4a6fe2"));
                    ans4.Content = "ESSA";
                    ans4.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6383e4"));

                    ans4.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/4.jpg"));

                    break;

                case 5:

                    txtQuestion.Text = "Questão 5";

                    currentQuestionText.Content = "Questão " + (qNum + 1) + "/?";

                    ans1.Content = "" + questionNumbers.Count;
                    ans2.Content = "" + (questionNumbers.Count + 1);
                    ans3.Content = "" + (questionNumbers.Count + 2);
                    ans4.Content = "" + (questionNumbers.Count - 2);

                    ans1.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/5.jpg"));

                    break;

                case 6:

                    txtQuestion.Text = "Qual é a alternativa certa?";

                    ans1.Content = "@";
                    ans2.Content = "Ç";
                    ans3.Content = "©";
                    ans4.Content = "0";

                    ans3.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/6.jpg"));

                    break;

                case 7:

                    txtQuestion.Text = "Qual é a alternativa certa?";


                    ans1.Content = "Sim";
                    ans2.Content = "Não há resposta";
                    ans3.Content = "Não";
                    ans4.Content = "Responderei";

                    ans2.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/7.jpg"));

                    break;

                case 8:

                    txtQuestion.Text = "Qual é a alternativa certa?";

                    currentQuestionText.Content = "Questão ?/" + questionNumbers.Count;

                    ans1.Content = "" + qNum;
                    ans2.Content = "" + (qNum - 1);
                    ans3.Content = "" + (qNum + 3);
                    ans4.Content = "" + (qNum + 1);

                    ans4.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/8.jpg"));

                    break;

                case 9:

                    txtQuestion.Text = "Questão 9";

                    ans1.Content = "Camelo";
                    ans2.Visibility = Visibility.Collapsed;
                    ans3.Content = "Dromedário";
                    ans4.Visibility = Visibility.Collapsed;

                    ans3.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/9.jpg"));

                    break;

                case 10:

                    txtQuestion.Text = "Questão 10";

                    ans1.Content = "∅";
                    ans2.Content = "∄";
                    ans3.Content = "Não existe";
                    ans4.Content = "0";

                    ans3.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/10.jpg"));

                    break;

                case 11:

                    txtQuestion.Text = "Questão 11";

                    ans1.Content = "ESSA";
                    ans2.Content = "essa";
                    ans3.Content = "Essa";
                    ans4.Content = "essa?";

                    ans1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#c48069"));
                    ans2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e8b9a9"));
                    ans4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e9ac7a"));

                    ans3.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/11.jpg"));

                    break;

                case 12:

                    txtQuestion.Text = "Questão 12";

                    ans1.Visibility = Visibility.Collapsed;
                    ans2.Visibility = Visibility.Collapsed;
                    ans3.Visibility = Visibility.Collapsed;
                    ans4.Visibility = Visibility.Collapsed;

                    ButtonSubmitWrittenAnswer.Visibility = Visibility.Visible;
                    TextboxAnswer.Visibility = Visibility.Visible;

                    writtenAnswer = "42";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/12.jpg"));

                    break;

                case 13:

                    txtQuestion.Text = "Questão 13";

                    ans5.Visibility = Visibility.Visible;

                    ans1.Content = "6,5";
                    ans2.Content = "52";
                    ans3.Content = "208";
                    ans4.Content = "26?";

                    ans5.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/13.jpg"));

                    break;

                case 14:

                    txtQuestion.Text = "Questão 14";

                    ans1.Content = "Sim";
                    ans2.Visibility = Visibility.Collapsed;
                    ans3.Content = "Não";
                    ans4.Visibility = Visibility.Collapsed;

                    ans3.Tag = "1";

                    ans1AltContent = "Não";
                    ans3AltContent = "Sim";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/14.jpg"));

                    break;

                case 15:

                    txtQuestion.Text = "Onde estava a resposta da primeira questão?";


                    ans1.Content = "3";
                    ans2.Content = "1";
                    ans3.Content = "2";
                    ans4.Content = "4";

                    ans3.Tag = "1";

                    qImage.Source = new BitmapImage(new Uri("pack://application:,,,/images/15.jpg"));

                    break;

            }
        }

        private void StartGame()
        {
            // this is the start game function
            new Introducao().ShowDialog();
            currentQuestionText.Content = "Questão " + (qNum + 1) + "/" + questionNumbers.Count;
        }

        private void GameOver()
        {
            new GameOver().ShowDialog();
        }

        private void mouseEnter(object sender, MouseEventArgs e)
        {
            Button senderButton = sender as Button;

            switch (senderButton.Name)
            {
                case "ans1":

                    if (!String.IsNullOrEmpty(ans1AltContent))
                    {
                        ans1OgContent = senderButton.Content.ToString();
                        senderButton.Content = ans1AltContent;
                    }

                    break;

                case "ans2":

                    if (!String.IsNullOrEmpty(ans2AltContent))
                    {
                        ans2OgContent = senderButton.Content.ToString();
                        senderButton.Content = ans2AltContent;
                    }

                    break;

                case "ans3":

                    if (!String.IsNullOrEmpty(ans3AltContent))
                    {
                        ans3OgContent = senderButton.Content.ToString();
                        senderButton.Content = ans3AltContent;
                    }

                    break;

                case "ans4":

                    if (!String.IsNullOrEmpty(ans4AltContent))
                    {
                        ans4OgContent = senderButton.Content.ToString();
                        senderButton.Content = ans4AltContent;
                    }

                    break;
            }

        }
        private void mouseLeave(object sender, MouseEventArgs e)
        {
            Button senderButton = sender as Button;

            switch (senderButton.Name)
            {
                case "ans1":

                    if (!String.IsNullOrEmpty(ans1OgContent))
                    {
                        ans1AltContent = senderButton.Content.ToString();
                        senderButton.Content = ans1OgContent;
                    }

                    break;

                case "ans2":

                    if (!String.IsNullOrEmpty(ans2OgContent))
                    {
                        ans2AltContent = senderButton.Content.ToString();
                        senderButton.Content = ans2OgContent;
                    }

                    break;

                case "ans3":

                    if (!String.IsNullOrEmpty(ans3OgContent))
                    {
                        ans3AltContent = senderButton.Content.ToString();
                        senderButton.Content = ans3OgContent;
                    }

                    break;

                case "ans4":

                    if (!String.IsNullOrEmpty(ans4AltContent))
                    {
                        ans4AltContent = senderButton.Content.ToString();
                        senderButton.Content = ans4OgContent;
                    }

                    break;
            }
        }
    }
}