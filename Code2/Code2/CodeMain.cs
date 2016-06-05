using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Code2
{
    public partial class CodeMain : Form
    {
        private string[] answers;

        public string[] Answers
        {
            get { return answers; }
            set { answers = value; }
        }

        public int AnswersAsInt
        {
            get
            {
                string totalAnswer = string.Empty;

                foreach (var sting in Answers)
                {
                    totalAnswer += sting;
                }

                return int.Parse(totalAnswer);
            }
        }

        private Dictionary<int, GameRecord> records;

        public Dictionary<int, GameRecord> Records
        {
            get { return records; }
            set { records = value; }
        }

        private int currentGuess;

        public int CurrentGuess
        {
            get { return currentGuess; }
            set { currentGuess = value; }
        }

        private bool gameInProgress;

        public bool GameInProgress
        {
            get { return gameInProgress; }
            set { gameInProgress = value; }
        }        

        private DateTime gameStart;

        public DateTime GameStart
        {
            get { return gameStart; }
            set { gameStart = value; }
        }
        
        private Button[] guessButton;

        public Button[] GuessButton
        {
            get { return guessButton; }
            set { guessButton = value; }
        }        

        private ComboBox[][] guessCombo;

        public ComboBox[][] GuessCombo
        {
            get { return guessCombo; }
            set { guessCombo = value; }
        }      

        private Label[][] guessLabel;

        public Label[][] GuessLabel
        {
            get { return guessLabel; }
            set { guessLabel = value; }
        }        

        private TimeSpan timePlayed;

        public TimeSpan TimePlayed
        {
            get { return timePlayed; }
            set { timePlayed = value; }
        }

        private TimeSpan lastTimePlayed;

        public TimeSpan LastTimePlayed
        {
            get { return lastTimePlayed; }
            set { lastTimePlayed = value; }
        }        

        private int totalGames;

        public int TotalGames
        {
            get { return totalGames; }
            set { totalGames = value; }
        }        

        private int totalGuesses;

        public int TotalGuesses
        {
            get { return totalGuesses; }
            set { totalGuesses = value; }
        }

        public CodeMain()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            
            NewGame();
            
            LoadRecords();
            CreateGuessForms();      
            TotalGames = 0;
            TimePlayed = new TimeSpan(0);
            GameInProgress = false;
        }

        private void CreateGuessForms()
        {
            GuessCombo = new ComboBox[TotalGuesses][];
            GuessLabel = new Label[TotalGuesses][];
            GuessButton = new Button[TotalGuesses];

            for (int i = 0; i < TotalGuesses; i++)
            {
                GuessCombo[i] = new ComboBox[4];
                GuessLabel[i] = new Label[4];

                for (int j = 0; j < 4; j++)
                {
                    GuessCombo[i][j] = new ComboBox();
                    GuessCombo[i][j].DataSource = new List<string>() {"", "1", "2", "3", "4", "5", "6" };
                    GuessCombo[i][j].Location = new Point(40 + (60 * i), 20 + (40 * j));
                    GuessCombo[i][j].Enabled = (i == 0);
                    GuessCombo[i][j].MaxLength = 1;
                    GuessCombo[i][j].Size = new System.Drawing.Size(30, 15);

                    GuessCombo[i][j].TextChanged +=new EventHandler(FocusNext);

                    GuessLabel[i][j] = new Label();
                    GuessLabel[i][j].BorderStyle = BorderStyle.FixedSingle;
                    GuessLabel[i][j].BackColor = Color.White;
                    GuessLabel[i][j].Text = " ";
                    GuessLabel[i][j].Location = (j < 2)
                                                    ? (j % 2 == 1)
                                                        ? new Point(40 + (60 * i), 225)   //1
                                                        : new Point(40 + (60 * i), 210)   //0
                                                    : (j % 2 == 1)
                                                        ? new Point(55 + (60 * i), 225)   //3
                                                        : new Point(55 + (60 * i), 210);  //2
                    GuessLabel[i][j].Size = new System.Drawing.Size(15, 15);

                    this.Controls.Add(GuessCombo[i][j]);
                    this.Controls.Add(GuessLabel[i][j]);
                }

                GuessButton[i] = new Button();
                GuessButton[i].Location = new Point(40 + (60 * i), 180);
                GuessButton[i].Text = "Confirm";
                GuessButton[i].Click += new EventHandler(EvaluateGuess);
                GuessButton[i].Enabled = (i == 0);
                GuessButton[i].Size = new System.Drawing.Size(50, 20);

                this.Controls.Add(GuessButton[i]);
            }

            Answer1.Location = new Point(60 + (60 * TotalGuesses), 20);
            Answer2.Location = new Point(60 + (60 * TotalGuesses), 60);
            Answer3.Location = new Point(60 + (60 * TotalGuesses), 100);
            Answer4.Location = new Point(60 + (60 * TotalGuesses), 140);
            ResetButton.Location = new Point(45 + (60 * TotalGuesses), 180);

            TimeLabel.Location = new Point(30 + (60 * TotalGuesses), 214);
            AverageLabel.Location = new Point(34 + (60 * TotalGuesses), 230);

            FastLabel.Location = new Point(100 + (60 * TotalGuesses), 214);
            SlowLabel.Location = new Point(100 + (60 * TotalGuesses), 230);

            this.Size = new Size(190 + (60 * TotalGuesses), 300);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CreateRandomAnswers()
        {
            Random rand = new Random();

            string[] temp = new string[4];

            for (int i = 0; i < 4; i++)
            {
                temp[i] = ((int)(rand.NextDouble() * 6) + 1).ToString();
            }

            Answers = temp;

            Answer1.Text = temp[0].ToString();
            Answer2.Text = temp[1].ToString();
            Answer3.Text = temp[2].ToString();
            Answer4.Text = temp[3].ToString();
        }

        private void EvaluateGuess(object sender, EventArgs e)
        {
            if (CurrentGuess == 0)
            {
                GameStart = DateTime.Now;
                GameInProgress = true;
                LastTimePlayed = TimePlayed;
            }

            List<int> completeCorrect = new List<int>();
            int wrongSpot = 0;

            for (int i = 0; i < 4; i++)
            {
                if (GuessCombo[CurrentGuess][i].Text == Answers[i])
                {
                    completeCorrect.Add(i);
                }
            }

            List<string> unusedGuesses = new List<string>();
            List<string> unusedAnswers = new List<string>();

            for (int i = 0; i < 4; i++)
            {
                if (!completeCorrect.Contains(i))
                {
                    unusedGuesses.Add(GuessCombo[CurrentGuess][i].Text);
                    unusedAnswers.Add(Answers[i]);
                }
            }

            foreach (string i in unusedGuesses.Distinct())
            {
                int gCount = unusedGuesses.Count(ug => ug == i);
                int aCount = unusedAnswers.Count(ua => ua == i);

                for (int j = 0; j < Math.Min(gCount, aCount); j++)
                {
                    wrongSpot++;//not the actual index
                }
            }

            FillLabels(completeCorrect.Count, wrongSpot);

            if (completeCorrect.Count == 4)
            {
                ShowAnswers();
                GuessButton[CurrentGuess].Enabled = false;

                for (int i = 0; i < 4; i++)
                {
                    GuessCombo[CurrentGuess][i].Enabled = false;
                }
            }
            else
            {
                NextGuess();
            }
        }

        private void FillLabels(int completeCorrect, int wrongSpot)
        {
            for (int i = 0; i < completeCorrect; i++)
            {
                GuessLabel[CurrentGuess][i].BackColor = Color.Goldenrod;
            }

            for (int i = completeCorrect; i < completeCorrect + wrongSpot; i++)
            {
                GuessLabel[CurrentGuess][i].BackColor = Color.CornflowerBlue;
            }
        }

        private void FocusNext(object sender, EventArgs e)
        {
            this.SelectNextControl((Control)sender, true, true, false, false);
        }

        private void LoadRecords()
        {
            Records = new Dictionary<int, GameRecord>();
            if (File.Exists(Path.Combine(Path.GetTempPath(), "CodeRecords.txt")))
            {
                var stringRecords = File.ReadAllLines(Path.Combine(Path.GetTempPath(), "CodeRecords.txt"));

                foreach (var sting in stringRecords)
                {
                    var sides = sting.Split(new string[] { ",=," }, StringSplitOptions.RemoveEmptyEntries);

                    var key = Int32.Parse(sides[0]);
                    var times = sides[1].Split(',');

                    List<double> values = new List<double>();
                    foreach (var time in times)
                    {
                        values.Add(Double.Parse(time));
                    }

                    Records[key] = new GameRecord(values);
                }
            }
        }

        private void NewGame()
        {
            CurrentGuess = 0;
            TotalGuesses = 8;            
            CreateRandomAnswers();
        }

        private void NextGuess()
        {
            for (int j = 0; j < 4; j++)
            {
                GuessCombo[CurrentGuess][j].Enabled = false;
            }

            GuessButton[CurrentGuess].Enabled = false;

            if (CurrentGuess < TotalGuesses - 1)
            {
                CurrentGuess++;

                for (int j = 0; j < 4; j++)
                {
                    GuessCombo[CurrentGuess][j].Enabled = true;
                }

                GuessCombo[CurrentGuess][0].Focus();
                GuessButton[CurrentGuess].Enabled = true;
            }
            else
            {
                ShowAnswers();
            }
        }

        private void SaveRecords()
        {
            string serializedRecords = string.Empty;

            foreach (var rec in Records)
            {
                serializedRecords += rec.Key + ",=";
                foreach (var time in rec.Value.Times)
                {
                    serializedRecords += ',' + time.ToString("F2");
                }
                serializedRecords += Environment.NewLine;
            }

            File.WriteAllText(Path.Combine(Path.GetTempPath(), "CodeRecords.txt"), serializedRecords);
        }

        private void ShowAnswers()
        {
            Answer1.BackColor = Color.Turquoise;
            Answer2.BackColor = Color.Turquoise;
            Answer3.BackColor = Color.Turquoise;
            Answer4.BackColor = Color.Turquoise;

            ResetButton.Focus();

            TotalGames++;
            TimePlayed += DateTime.Now.Subtract(GameStart);
            GameInProgress = false;
            contextMenuStrip1.Items[0].Text = "Total Games Played: " + TotalGames;
            contextMenuStrip1.Items[1].Text = "Total Time Played: " + TimePlayed;
            contextMenuStrip1.Items[2].Text = "Average: " + TimePlayed.TotalSeconds / TotalGames;      

            double secondsPlayed = (TimePlayed - LastTimePlayed).TotalSeconds;

            TimeLabel.Text = "Time: " + secondsPlayed.ToString("F2");
            TimeLabel.Visible = true;

            AverageLabel.Text = "Avg: " + (TimePlayed.TotalSeconds / TotalGames).ToString("F2");
            AverageLabel.Visible = true;                      

            if (!Records.ContainsKey(AnswersAsInt))
            {
                Records.Add(AnswersAsInt, new GameRecord(new List<double>() { secondsPlayed }));
            }
            else
            {
                FastLabel.Text = "Fast: " + Records[AnswersAsInt].Fastest.ToString("F2");
                SlowLabel.Text = "Slow: " + Records[AnswersAsInt].Slowest.ToString("F2");

                FastLabel.Visible = true;
                if (Records[AnswersAsInt].Fastest != Records[AnswersAsInt].Slowest)
                {
                    SlowLabel.Visible = true;
                }

                Records[AnswersAsInt].AddTime(secondsPlayed);
            }            
        }        

        private void ResetButton_Click(object sender, EventArgs e)
        {
            NewGame();            

            for (int i = 0; i < TotalGuesses; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    GuessCombo[i][j].SelectedIndex = 0;
                    GuessCombo[i][j].Enabled = (i == 0);
                    GuessLabel[i][j].BackColor = Color.White;
                }
                GuessButton[i].Enabled = (i == 0);
            }

            Answer1.BackColor = Color.Black;
            Answer2.BackColor = Color.Black;
            Answer3.BackColor = Color.Black;
            Answer4.BackColor = Color.Black;

            AverageLabel.Visible = false;
            TimeLabel.Visible = false;
            FastLabel.Visible = false;
            SlowLabel.Visible = false;
            GuessCombo[0][0].Focus();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {    
            this.Show();        
            this.WindowState = FormWindowState.Normal;
            this.Activate();            
        }

        private void CodeMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void CodeMain_Deactivate(object sender, EventArgs e)
        {
            if (GameInProgress)
            {
                TimePlayed += DateTime.Now.Subtract(GameStart);
                contextMenuStrip1.Items[1].Text = "Total Time Played: " + TimePlayed;
            }
        }

        private void CodeMain_Activated(object sender, EventArgs e)
        {
            GameStart = DateTime.Now;
        }

        private void CodeMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveRecords();
        }
    }
}
