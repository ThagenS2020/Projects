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
using System.Windows.Shapes;

namespace LibraryAppWPF
{
    /// <summary>
    /// Interaction logic for game.xaml
    /// </summary>
    public partial class game : Window
    {
        private List<Question> questions;
        private int currentQuestionIndex;
        private int correctAnswers;
        public game()
        {
            InitializeComponent();
            InitializeQuestions();
            LoadNextQuestion();
        }

        //private void btnGame_Click(object sender, RoutedEventArgs e)
        //{

        //}
        private void InitializeQuestions()
        {
            questions = new List<Question>
        {
            new Question
            {
                Text = "What do the letters in '005.73 JAM' stand for?",
                CorrectAnswer = "Author",
                Options = new List<string> { "Topic of Book", "Author", "Publisher", "ISBN" }
            },
            new Question
            {
                Text = "What do the numbers in '005.73 JAM' stand for?",
                CorrectAnswer = "Topic of Book",
                Options = new List<string> { "Author", "Topic of Book", "Publisher", "ISBN" }
            },
                new Question
            {
                Text = "What skill is essential for librarians to find the correct place for a book on the library shelves?",
                CorrectAnswer = "Sorting call numbers numerically and alphabetically",
                Options = new List<string> { "Categorizing books by genre", "Sorting call numbers numerically and alphabetically", "Checking books for damage", "Writing book summaries" }
            },
                    new Question
            {
                Text = "To organize books in a library, librarians sort call numbers first by what criteria?",
                CorrectAnswer = "Numerical order",
                Options = new List<string> { "Alphabetical order", "Genre", "Author's first name", "Numerical order" }
            },
                        new Question
            {
                Text = "What is the significance of 005.73 in the call number 005.73 JAM?",
                CorrectAnswer = "It signifies the book's topic",
                Options = new List<string> { "It represents the book's edition", "It indicates the book's page count", "It signifies the book's topic", "It is the author's birthdate" }
            },

        };

            currentQuestionIndex = 0;
            correctAnswers = 0;
        }
        private void LoadNextQuestion()
        {
            if (currentQuestionIndex < questions.Count)
            {
                Question question = questions[currentQuestionIndex];
                questionLabel.Content = question.Text;
                option1.Content = question.Options[0];
                option2.Content = question.Options[1];
                option3.Content = question.Options[2];
                option4.Content = question.Options[3];
                ClearRadioButtons();
            }
            else
            {
                MessageBox.Show($"Quiz completed! You got {correctAnswers} out of {questions.Count} questions correct.", "Quiz Results", MessageBoxButton.OK, MessageBoxImage.Information);
                // Optionally, you can reset the game or close the application here.
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            if (currentQuestionIndex < questions.Count)
            {
                Question question = questions[currentQuestionIndex];
                RadioButton selectedOption = GetSelectedRadioButton();

                if (selectedOption == null)
                {
                    MessageBox.Show("Please select an option.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Stop processing the current question if no option is selected.
                }

                if (selectedOption.Content.ToString() == question.CorrectAnswer)
                {
                    correctAnswers++;
                }

                currentQuestionIndex++;
                LoadNextQuestion();
            }
            else
            {
                // Display a message or handle the end of the quiz.
                MessageBox.Show($"Quiz completed! You got {correctAnswers} out of {questions.Count} questions correct.", "Quiz Results", MessageBoxButton.OK, MessageBoxImage.Information);
                // Optionally, you can reset the game or close the application here.
            }
        }
        private RadioButton GetSelectedRadioButton()
        {
            foreach (RadioButton radioButton in new RadioButton[] { option1, option2, option3, option4 })
            {
                if (radioButton.IsChecked == true)
                {
                    return radioButton;
                }
            }
            return null;
        }

        private void ClearRadioButtons()
        {
            foreach (RadioButton radioButton in new RadioButton[] { option1, option2, option3, option4 })
            {
                radioButton.IsChecked = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RandomGenerate ran = new RandomGenerate();
            ran.Show();
            this.Close();
        }
    }
}
