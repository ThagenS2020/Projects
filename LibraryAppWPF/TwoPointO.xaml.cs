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
    /// Interaction logic for TwoPointO.xaml
    /// </summary>
    public partial class TwoPointO : Window
    {
        private List<QuestionMatching> questions;
        private int currentQuestionIndex;
        private int correctAnswers;
        public TwoPointO()
        {
            InitializeComponent();
            InitializeQuestions();
            LoadNextQuestion();
        }

        private void LoadNextQuestion()
        {
            if (currentQuestionIndex < questions.Count)
            {
                QuestionMatching question = questions[currentQuestionIndex];
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

        private void InitializeQuestions()
        {
            questions = new List<QuestionMatching>
            {
                 new QuestionMatching
            {
                Text = "Under which top-level Dewey Decimal category would you find books related to philosophy and psychology?",
                CorrectAnswer = "100 - Philosophy & Psychology",
                Options = new List<string> { "200 - Religion", "100 - Philosophy & Psychology", "300 - Social Sciences", "900 - History & Geography" }
            },
            new QuestionMatching
            {
                Text = "In the Dewey Decimal Classification system, which top-level category encompasses books on technology, applied sciences, and engineering?",
                CorrectAnswer = "600 - Technology",
                Options = new List<string> { "600 - Technology", "500 - Natural Sciences & Mathematics", "300 - Social Sciences", "700 - Arts & Recreation" }
            },
                new QuestionMatching
            {
                Text = "Under which top-level Dewey Decimal category would you locate books about history and geography?",
                CorrectAnswer = "900 - History & Geography",
                Options = new List<string> { "400 - Language", "300 - Social Sciences", "900 - History & Geography", " 700 - Arts & Recreation" }
            },
                    new QuestionMatching
            {
                Text = "Books related to social sciences, including sociology and political science, fall under which top-level Dewey Decimal category?",
                CorrectAnswer = "300 - Social Sciences",
                Options = new List<string> { "500 - Natural Sciences & Mathematics", "600 - Technology", "300 - Social Sciences", "200 - Religion" }
            },
                        new QuestionMatching
            {
                Text = "In the Dewey Decimal system, which top-level category is designated for books covering language and literature?",
                CorrectAnswer = "400 - Language",
                Options = new List<string> { "700 - Arts & Recreation", "400 - Language", "100 - Philosophy & Psychology", "800 - Literature" }
            },
            };
            currentQuestionIndex = 0;
            correctAnswers = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (currentQuestionIndex < questions.Count)
            {
                QuestionMatching question = questions[currentQuestionIndex];
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow an = new MainWindow();
            an.Show();
            this.Close();
        }
    }
}
