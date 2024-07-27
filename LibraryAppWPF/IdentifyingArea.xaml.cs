using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LibraryAppWPF
{
    public partial class IdentifyingArea : Window
    {
        public Dictionary<int, string> matching { get; set; }
        private int selectedCallNumber = -1; // Store selected CallNumber
        private string selectedDescription = null; // Store selected Description
        private Random rand = new Random();
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

        //Adapted: How to develop match making game using c# in.Net
        //Author:Anubhav Chaudhary
        //Link:https://www.c-sharpcorner.com/members/anubhav-chaudhary
        //Date:15 December 2020
        //Link:https://www.c-sharpcorner.com/UploadFile/cd7c2e/how-to-develop-match-making-game-in-C-Sharp-under-net-4-5/
        //C#Corner.com

        public IdentifyingArea()
        {
            InitializeComponent();
            InitializeQuestions();
            AddList();
            RandomlySwapListViews(); // Randomly swap ListViews initially
        }

        private void InitializeQuestions()
        {
            matching = new Dictionary<int, string>
            {
                {0, "Computer Science, Information, & General Works"},
                {100, "Philosophy & Psychology"},
                {200, "Religion"},
                {300, "Social Sciences"},
                {400, "Language"},
                {500, "Science"},
                {600, "Technology"},
                {700, "Arts & Recreation"},
                {800, "Literature"},
                {900, "History & Geography"}
            };
        }

        public void AddList()
        {
            var randomItems = matching.OrderBy(x => rand.Next()).Take(4).ToDictionary(x => x.Key, x => x.Value);

            lsbMatch.ItemsSource = randomItems.Keys; // Display only numbers
            var additionalDescriptions = matching.Values.Except(randomItems.Values).OrderBy(x => rand.Next()).Take(3).ToList();
            var allDescriptions = randomItems.Values.Concat(additionalDescriptions).ToList();
            lsbDescription.ItemsSource = allDescriptions; // Display all descriptions, including the additional ones
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            CheckMatch();
        }

        private void lsbMatch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lsbMatch.SelectedItem != null)
            {
                selectedCallNumber = (int)lsbMatch.SelectedItem;
            }
        }

        private void CheckMatch()
        {
            if (selectedCallNumber != -1 && selectedDescription != null)
            {
                if (matching.ContainsKey(selectedCallNumber) && matching[selectedCallNumber] == selectedDescription)
                {
                    MessageBox.Show("Correct :)");
                }
                else
                {
                    MessageBox.Show("Wrong, keep trying");
                }

                // Clear selections after checking
                lsbMatch.SelectedItem = null;
                lsbDescription.SelectedItem = null;
                selectedCallNumber = -1;
                selectedDescription = null;
            }
        }

        private void lsbDescription_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lsbDescription.SelectedItem != null)
            {
                selectedDescription = (string)lsbDescription.SelectedItem;
            }
        }

        private void RandomlySwapListViews()
        {
            if (rand.Next(2) == 0)
            {
                // Swap ListViews
                Grid.SetColumn(lsbMatch, 1);
                Grid.SetColumn(lsbDescription, 0);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TwoPointO to = new TwoPointO();
            to.Show();

            this.Close();
        }
    }
}
