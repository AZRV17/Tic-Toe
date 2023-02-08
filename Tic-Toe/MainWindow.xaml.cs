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

namespace Tic_Toe
{
    public partial class MainWindow : Window
    {
        private char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private int choice;
        private char symbol = 'X';
        private char AI_symbol = 'O';
        private int counter = 1;
        private int canPlay = 0;
        
        public MainWindow()
        {
            InitializeComponent();
            TextBlock.Text = string.Empty;
        }

        private void Start_btn_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Random rnd = new Random();

            List<Button> buttons = new List<Button>() { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };

            if (Start_btn.Content == "Stop")
            {
                canPlay = 0;
                Start_btn.Content = "Start";
            }
            else
            {
                arr = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                TextBlock.Text = "";
                foreach (Button b in buttons)
                {
                    b.Content = "";
                }
                Start_btn.Content = "Stop";
                canPlay = 1;
                if (counter % 2 != 0)
                {
                    symbol = 'X';
                    AI_symbol = 'O';
                }
                else
                {
                    symbol = 'O';
                    AI_symbol = 'X';
                    Bot_move();
                }
                counter++;
            }
        }

        private string CheckWin()
        {

            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return "Победа " + arr[1];
            }
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return "Победа " + arr[4];
            }
            else if (arr[7] == arr[8] && arr[8] == arr[9])
            {
                return "Победа " + arr[7];
            }
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return "Победа " + arr[1];
            }
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return "Победа " + arr[2];
            }
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return "Победа " + arr[3] ;
            }
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return "Победа " + arr[1];
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return "Победа " + arr[3];
            }
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return "Ничья";
            }
            else
            {
                return "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            

            if (canPlay == 1 && button.Content == "")
            {
                Player_move(button);
                string winner = CheckWin();
                TextBlock.Text = winner;
                if (winner != "")
                {
                    canPlay = 3;
                    Start_btn.Content = "Start";
                }
                else
                {
                    Bot_move();
                    winner = CheckWin();
                    TextBlock.Text = winner;
                    if (winner != "")
                    {
                        canPlay = 3;
                        Start_btn.Content = "Start";
                    }
                }
            }
            else if (canPlay == 0)
            {
                MessageBox.Show("Сначала нажмите Start");
            }
        }

        private void Player_move(Button button)
        {

            if (canPlay == 1 && button.Content == "")
            {
                char[] delete = { 'b', 't', 'n' };
                choice = int.Parse(button.Name.ToString().TrimStart(delete));
                button.Content = symbol;
                arr[choice] = symbol;
            }
        }

        private void Bot_move()
        {
            char[] delete = { 'b', 't', 'n' };
            Random rnd = new Random();

            List<Button> buttons = new List<Button>() { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
            
            int randomIndex = rnd.Next(buttons.Count);
            Button randomBtn = buttons[randomIndex];

            int i = 1;

            List<object> tmp = new List<object>();

            foreach (Button b in buttons)
            {
                tmp.Add(b.Content);
            }

            while (i == 1)
            {
                if (tmp.Contains(""))
                {
                    if (randomBtn.Content == "")
                    {
                        choice = int.Parse(randomBtn.Name.ToString().TrimStart(delete));
                        randomBtn.Content = AI_symbol;
                        arr[choice] = AI_symbol;

                        i = 0;
                    }
                    else
                    {
                        randomIndex = rnd.Next(buttons.Count);
                        randomBtn = buttons[randomIndex];
                    }
                }
                else
                {
                    i = 0;
                }
            }
        }
    }
}
