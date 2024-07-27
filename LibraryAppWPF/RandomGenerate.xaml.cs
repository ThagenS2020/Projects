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
    /// Interaction logic for RandomGenerate.xaml
    /// </summary>
    public partial class RandomGenerate : Window
    {
        public static List<double> numbers = new List<double>();
        private List<double> selectedItems = new List<double>();
        public static string gen = "";
        public RandomGenerate()
        {
            InitializeComponent();
            lsbView.Items.Clear();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            lsbView.Items.Clear();
            numbers.Clear();
            for (int i = 0; i < 10; i++)
            {

                Random random = new Random();

                int wholePart = random.Next(1000);  // Generate a random whole number between 0 and 999
                int decimalPart = random.Next(1000); // Generate a random decimal number between 0 and 999

                double randomDecimal = wholePart + (decimalPart / 1000.0); // Combine whole and decimal parts

                numbers.Add(randomDecimal);
            }

          

            foreach (double num in numbers)
            {
                lsbView.Items.Add(num);
            }
        }
        //Adapted: Gamification elements and mechanics
        //Author:Mambo
        //Date:07 June 2023
        //Link:https://mambo.io/blog/gamification-elements-and-mechanics
        //Mambo.com

        //Adapted: How to develop your app gamification strategy
        //Author:Adjust
        //Date:02 July
        //Link:https://www.adjust.com/blog/how-to-develop-your-app-gamification-strategy/
        //Adjust.com

        //Adapted: What are gamification features
        //Author:Spinify
        //Date:27 November 2022
        //Link:https://spinify.com/blog/gamification-features/#:~:text=Gamification%20includes%20various%20features%2C%20such,%2C%20motivation%2C%20and%20attention%20span.
        //Spinify.com

        //Adapted: Wpd listbox tutorial
        //Author:Mahesh Chand
        //Link:https://www.c-sharpcorner.com/members/mahesh-chand
        //Date:08 November 2021
        //Link:https://www.c-sharpcorner.com/uploadfile/mahesh/listbox-in-wpf/
        //C#Corner.com

        //Adapted: Working with wpf RadioButtons using C# and XAML
        //Author:Mahesh Chand
        //Link:https://www.c-sharpcorner.com/members/mahesh-chand
        //Date:09 December 2018
        //Link:https://www.c-sharpcorner.com/UploadFile/mahesh/radiobutton-in-wpf/
        //C#Corner.com
        private void btnCorrect_Click(object sender, RoutedEventArgs e)
        {
            if (selectedItems.Count == 0)
            {
                MessageBox.Show("The selected items list is empty.", "Empty List", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                // Sort the numbers list in ascending order
                numbers.Sort();

                // Check if selectedItems matches the sorted numbers list
                bool Match = selectedItems.SequenceEqual(numbers);

                if (Match)
                {
                    MessageBox.Show("The order is Correct!", "Matching Result", MessageBoxButton.OK, MessageBoxImage.Information);
                    List<string> combinedList = new List<string>();

                    // Generate a separate Random object for letters
                    Random letterRandom = new Random();

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        double num = numbers[i];

                        // Generate three random letters for each value
                        StringBuilder randomLetters = new StringBuilder();
                        for (int j = 0; j < 3; j++)
                        {
                            char randomLetter = (char)letterRandom.Next('A', 'Z' + 1); // Generate a random letter
                            randomLetters.Append(randomLetter);
                        }

                        // Combine the number and random letters
                        string combinedValue = $"{num} {randomLetters.ToString()}";

                        combinedList.Add(combinedValue);
                    }
                    lsbCorrect.ItemsSource = combinedList;
                }
                else
                {
                    MessageBox.Show("The order is wrong!", "Matching Result", MessageBoxButton.OK, MessageBoxImage.Error);
                    //foreach (double num in numbers)
                    //{
                    //    lsbCorrect.Items.Add(num);
                    //}
                    List<string> combinedList = new List<string>();

                    // Generate a separate Random object for letters
                    Random letterRandom = new Random();

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        double num = numbers[i];

                        // Generate three random letters for each value
                        StringBuilder randomLetters = new StringBuilder();
                        for (int j = 0; j < 3; j++)
                        {
                            char randomLetter = (char)letterRandom.Next('A', 'Z' + 1); // Generate a random letter
                            randomLetters.Append(randomLetter);
                        }

                        // Combine the number and random letters
                        string combinedValue = $"{num} {randomLetters.ToString()}";

                        combinedList.Add(combinedValue);
                    }
                    lsbCorrect.ItemsSource = combinedList;
                    lblCorrect.Content = "The correct order:";
                    lblCorrect.Visibility = Visibility.Visible;
                }
            }

        

        }

        private void lsbView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (lsbView.SelectedItem != null)
            {
                double selectedValue = (double)lsbView.SelectedItem;

                // Add the selected item to the tracking list
                selectedItems.Add(selectedValue);

                // Update the lsbOrder ListBox with all selected items
                lsbOrder.Items.Clear();
                foreach (double item in selectedItems)
                {
                    lsbOrder.Items.Add(item);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            game g = new game();
            g.Show();

            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
