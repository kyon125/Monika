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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
   
    public partial class MainWindow : Window
    {
        int a = 0;
        int now = 1;
        int ctrl = 0;
        int musicplay = 0;
        int down_click = 0;
        int number = 0;
        string[] talking = new string[100];
        string[] playing = new string[1000];
        string[] shownumber = new string[1000];
        string testline = "";
        string filename = "";
        MediaPlayer playtest = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            menu.Source = new BitmapImage(new Uri("000.png", UriKind.Relative));
            play.Source = new BitmapImage(new Uri("Play.png", UriKind.Relative));
            value.Source = new BitmapImage(new Uri("Value.png", UriKind.Relative));
            add.Source = new BitmapImage(new Uri("Add.png", UriKind.Relative));
            down.Source = new BitmapImage(new Uri("Down.png", UriKind.Relative));
            breakmusic.Source = new BitmapImage(new Uri("Break.png", UriKind.Relative));
            back.Source = new BitmapImage(new Uri("Back.png", UriKind.Relative));
            next.Source = new BitmapImage(new Uri("Next.png", UriKind.Relative));
            Talkingset(talking[a]);
        }
              
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (a < 11)
            {
                talk.Text = talking[a];
                a++;

                if (a == 9)
                {
                    List<string> test = new List<string>();
                    string Twosence = "twice";
                    test.Add(Twosence);
                    System.IO.File.WriteAllText(@"D:\Test.txt", Twosence);
                    ctrl = 1;
                }
            }

            else if (20 <= a && a <= 30)
            {
                talk.Text = talking[a];
                a++;

                if (a == 27)
                {
                    List<string> test = new List<string>();
                    string Twosence = "three";
                    test.Add(Twosence);
                    System.IO.File.WriteAllText(@"D:\Test.txt", Twosence);
                    ctrl = 1;
                }
            }

            else if (40 <= a && a <= 43)
            {
                talk.Text = talking[a];
                a++;

                if (a == 43)
                {
                    ctrl = 1;
                }
            }           
                       
        }

        public void Talkingset(string sender)
        {
            talking[0] = "...mmmmm...?";
            talking[1] = ".......";
            talking[2] = "Welcome to this club, stranger...?";
            talking[3] = "In fast, I'm not sure why can you enter this world...";
            talking[4] = "Your gender, age, name...etc.";
            talking[5] = "Your everying makes me feel interested!";
            talking[6] = "...mmm....";
            talking[7] = "You can use the redio there";
            talking[8] = "And we can talk about ourselves.";
            talking[9] = "Do you want some tea?";

            talking[20] = "I'm very glad that you come back to see me.";
            talking[21] = "Because you know....";
            talking[22] = "Everytime, when you close the window,";
            talking[23] = "I will drop in the darkness...";
            talking[24] = "...mm...the feeling always makes me feel disgusted.";
            talking[25] = "But now, those things become insignificant.";
            talking[26] = "Because you come back by my side, right?";

            talking[40] = "......mmm......";
            talking[41] = "If we have a chance, I want to show you my piano skills.";
            talking[42] = "Maybe you will be infatuated me!";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if (System.IO.File.Exists((@"D:\Test.txt")))
            {
                testline = System.IO.File.ReadAllText(@"D:\Test.txt");
                if (testline == "twice")
                {
                    a = 20;
                }

                else if (testline == "three")
                {
                    a = 40;
                }
            }
            else
            {
                System.IO.File.WriteAllText(@"D:\Test.txt" ,testline);
            }            
        }

        private void play_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ctrl == 1 && number != 0)
            {
                if (musicplay == 0)
                {
                    musicplay = 1;
                    play.Source = new BitmapImage(new Uri("Pause.png", UriKind.Relative));
                    playtest.Open(new Uri(playing[now], UriKind.Relative));
                    playtest.Play();
                    if (0 < number && number < 10)
                    {
                        talk.Text = "0" + now + shownumber[now];
                    }
                    else if (number == 0)
                    {
                    }

                    else
                    {
                        talk.Text = now + shownumber[now];
                    }
                }

                else if (musicplay == 1)
                {
                    musicplay = 2;
                    play.Source = new BitmapImage(new Uri("Play.png", UriKind.Relative));
                    playtest.Pause();
                }
                else if (musicplay == 2)
                {
                    musicplay = 1;
                    play.Source = new BitmapImage(new Uri("Pause.png", UriKind.Relative));
                    playtest.Play();
                }
            }
        }

        private void MediaValue(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (ctrl == 1)
            {
                playtest.Volume = (double)Mediav.Value;
            }
        }

        private void add_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ctrl == 1)
            {
                Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog();
                Nullable<bool> result = openFile.ShowDialog();
                if (result == true)
                {
                    filename = openFile.FileName;
                    number++;
                    playing[number] = filename;
                    shownumber[number] = openFile.SafeFileName;
                    if (number < 10)
                    {
                        showplay.Text = showplay.Text + "\r\n" + "0" + number + shownumber[number] + "\r\n";
                    }
                    else
                    {
                        showplay.Text = showplay.Text + "\r\n" + number + shownumber[number] + "\r\n";
                    }
                }
            }
        }

        private void down_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ctrl == 1)
            {
                if (down_click == 0)
                {
                    showplay.Height = 0;
                    down_click = 1;
                    down.Source = new BitmapImage(new Uri("Open.png", UriKind.Relative));
                }

                else if (down_click == 1)
                {
                    showplay.Height = 350;
                    down_click = 0;
                    down.Source = new BitmapImage(new Uri("Down.png", UriKind.Relative));
                }
            }
        }

        private void breakmusic_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ctrl == 1 && musicplay != 0)
            {
                musicplay = 0;
                playtest.Stop();
                play.Source = new BitmapImage(new Uri("Play.png", UriKind.Relative));
            }
        }

        private void back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ctrl == 1 )
            {
                if (now == 1)
                {
                    now = number;
                    playtest.Open(new Uri(playing[now], UriKind.Relative));
                    playtest.Play();
                    if (0 < number && number < 10)
                    {
                        talk.Text = "0" + now + shownumber[now];
                    }
                    else if (number == 0)
                    {
                    }

                    else
                    {
                        talk.Text = now + shownumber[now];
                    }
                }

                else
                {
                    now--;
                    playtest.Open(new Uri(playing[now], UriKind.Relative));
                    playtest.Play();
                    if (0 < number && number < 10)
                    {
                        talk.Text = "0" + now + shownumber[now];
                    }
                    else if (number == 0)
                    {
                    }

                    else
                    {
                        talk.Text = now + shownumber[now];
                    }
                }
            }
        }

        private void next_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ctrl == 1)
            {
                if (now == number)
                {
                    now = 1;
                    playtest.Open(new Uri(playing[now], UriKind.Relative));
                    playtest.Play();
                    if (0 < number && number < 10)
                    {
                        talk.Text = "0" + now + shownumber[now];
                    }
                    else if (number == 0)
                    {
                    }

                    else
                    {
                        talk.Text = now + shownumber[now];
                    }
                }

                else
                {
                    now++;
                    playtest.Open(new Uri(playing[now], UriKind.Relative));
                    playtest.Play();
                    if (0 < number && number < 10)
                    {
                        talk.Text = "0" + now + shownumber[now];
                    }
                    else if (number == 0)
                    {
                    }

                    else
                    {
                        talk.Text = now + shownumber[now];
                    }
                }
            }
        }

    }
}
