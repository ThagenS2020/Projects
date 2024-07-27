using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for MultiLevelQuiz.xaml
    /// </summary>
  
    public partial class MultiLevelQuiz : Window
    {
        public Dictionary<int, string> categoryDictionary;
        private TreeNode<int,string> root;
        public MultiLevelQuiz()
        {
            InitializeComponent();
            CreateCategoryDictionary();
            LoadDataFromFile();
            adding();
            btnTwo.Visibility = Visibility.Collapsed;


        }
      
        private void CreateCategoryDictionary()
        {
            categoryDictionary = new Dictionary<int, string>
            {
                {200, "Religion"},
                {600, "Technology"},
                {500, "Science"},
                {700, "Arts & Recreation"},
                {000, "Computer Science,Information, & General Work"},
                {800, "Literature"}
            };
        }

        public class TreeNode<T1,T2>
        {
            public T1 Number { get; set; }
            public T2 Description { get; set; }
            public List<TreeNode<T1,T2>> Children { get; set; }

            public TreeNode(T1 number,T2 description)
            {
                Number = number;
                Description = description;
                Children = new List<TreeNode<T1,T2>>();
            }

            public void AddChild(TreeNode<T1,T2> child)
            {
                Children.Add(child);
            }
        }

        private void LoadDataFromFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"informations.txt"))
                {
                    string line;
                    TreeNode<int, string> currentNode = null;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        int number;
                        if (int.TryParse(parts[0], out number))
                        {
                            TreeNode<int, string> newNode = new TreeNode<int, string>(number, parts[1]);

                            if (root == null)
                            {
                                root = newNode; // Set the root node
                                currentNode = newNode;
                            }
                            else if (number % 100 == 0)
                            {
                                root.AddChild(newNode); // Add to the root node
                                currentNode = newNode;
                            }
                            else
                            {
                                currentNode?.AddChild(newNode); // Add as a child to the current node
                            }
                        }
                    }
                }


            }
            catch (Exception e)
            {
                MessageBox.Show($"An error occured: {e.Message}","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }

        }

       
      


        public void adding()
        {
            listOption.Items.Clear();
            listRandom.Items.Clear();

            // Add root to listOption
            ListViewItem rootItem = new ListViewItem();
            rootItem.Content = $"{root.Number}  {root.Description}";
            listOption.Items.Add(rootItem);

            // Collect descriptions of eligible child nodes
            var eligibleChildDescriptions = root.Children
                .Where(child => Convert.ToInt32(child.Number) % 100 != 0 && child != root)
                .Select(child => child.Description)
                .ToList();

            // Randomly select one description from eligible child nodes and add it to listOption
            if (eligibleChildDescriptions.Count > 0)
            {
                var rand = new Random();
                var selectedDescription = eligibleChildDescriptions[rand.Next(eligibleChildDescriptions.Count)];

                ListViewItem selectedChildItem = new ListViewItem();
                selectedChildItem.Content = selectedDescription;
                listRandom.Items.Add(selectedChildItem);
            }
            var random = new Random();

            var randomItems = categoryDictionary.OrderBy(x => random.Next()).Take(3);

            foreach(var item in randomItems)
            {
                ListViewItem listViewItem = new ListViewItem();

                listViewItem.Content = $"{item.Key}  {item.Value}";

                listOption.Items.Add(listViewItem);
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

        //Adapted: How to develop match making game using c# in.Net
        //Author:Anubhav Chaudhary
        //Link:https://www.c-sharpcorner.com/members/anubhav-chaudhary
        //Date:15 December 2020
        //Link:https://www.c-sharpcorner.com/UploadFile/cd7c2e/how-to-develop-match-making-game-in-C-Sharp-under-net-4-5/
        //C#Corner.com

        public void second()
        {
            // Second Level
            listOption.Items.Clear();

            // Populate listOption with nodes having a tenth value but no unit value
            var validChildNodes = root.Children
                .Where(child => object.Equals(child.Number % 100, 10) && !object.Equals(child.Number % 10, 0))
                .OrderBy(x => Guid.NewGuid())
                .Take(3);

            foreach (var childNode in validChildNodes)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Content = $"{childNode.Number}  {childNode.Description}";
                listOption.Items.Add(listViewItem);
            }
        }
        public void third()
        {
            // Third Level
            listOption.Items.Clear();

            // Get the selected item from listRandom
            if (listRandom.SelectedItem != null)
            {
                string selectedDescription = ((ListViewItem)listRandom.SelectedItem).Content.ToString();

                // Find the child node where the description matches the selected description
                var selectedChildNode = root.Children
                    .FirstOrDefault(child => object.Equals(child.Description, selectedDescription));

                // If found, add it to listOption
                if (selectedChildNode != null)
                {
                    ListViewItem selectedChildItem = new ListViewItem();
                    selectedChildItem.Content = $"{selectedChildNode.Number},{selectedChildNode.Description}";
                    listOption.Items.Add(selectedChildItem);
                }
            }

            // Collect eligible child nodes (where tenth and unit values are not equal to 0)
            var eligibleChildNodes = root.Children
                .Where(child => !object.Equals(child.Number % 100, 0) && !object.Equals(child.Number % 10, 0))
                .ToList();

            // Randomly select three child nodes from the remaining eligible nodes
            var randomChildNodes = eligibleChildNodes.OrderBy(x => Guid.NewGuid()).Take(3);

            foreach (var childNode in randomChildNodes)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Content = $"{childNode.Number},{childNode.Description}";
                listOption.Items.Add(listViewItem);
            }
        }



        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (listOption.SelectedItem == null || listRandom.SelectedItem == null)
            {
                MessageBox.Show("Please select items from both ListViews.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            // Get the selected item from listOption
            string selectedRoot = ((ListViewItem)listOption.SelectedItem).Content.ToString();

            // Check if the selected item in listOption is equal to the root node
            if (selectedRoot == $"{root.Number}  {root.Description}")
            {
                MessageBox.Show("Correct!", "Result", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
            {
                MessageBox.Show("Incorrect!", "Result", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
            third();
            btnEnter.Visibility = Visibility.Collapsed;
            btnTwo.Visibility = Visibility.Visible;

        }

        private void listOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listRandom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnGame_Click(object sender, RoutedEventArgs e)
        {
            TwoPointO o = new TwoPointO();
            o.Show();
            this.Close();
        }

        private void btnTwo_Click(object sender, RoutedEventArgs e)
        {
            string optionNumber;
            string optionDescription = "";

            // Check if both ListViews have selected items
            if (listOption.SelectedItem == null || listRandom.SelectedItem == null)
            {
                MessageBox.Show("Please select items from both ListViews.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            // Extract description from the selected item in listRandom
            string randomDescription = ((ListViewItem)listRandom.SelectedItem).Content.ToString();

            // Extract the selected item from listOption
            string optionContent = ((ListViewItem)listOption.SelectedItem).Content.ToString();

            // Split the content to get number and description
            string[] optionParts = optionContent.Split(',');
            if (optionParts.Length == 2) // Ensure the format is as expected
            {
                // Extract number and description from the selected item in listOption
                optionNumber = optionParts[0];
                optionDescription = optionParts[1].Trim(); // Only take the description part
            }

            // Check if the extracted descriptions match
            if (optionDescription.Equals(randomDescription.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Correct!", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Incorrect!", "Result", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }





    }
}
