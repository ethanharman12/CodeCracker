using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Code2
{
    public partial class CodeMain : Form
    {  
        public Dictionary<int, GameRecord> Records { get; set; }
        public int CurrentGuess { get; set; }
        public Game Game { get; set; }
        public bool GameInProgress { get; set; }
        public Button[] GuessButton { get; set; }
        public ComboBox[][] GuessCombo { get; set; }
        public Label[][] GuessLabel { get; set; }
        public TimeSpan TimePlayed { get; set; }
        public TimeSpan LastTimePlayed { get; set; }
        public GameTimer Timer { get; set; }
        public int TotalGames { get; set; }

        public CodeMain()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;

            CreateGuessForms(8);
            NewGame();
            
            Records = RecordsRepository.GetRecords();
            TotalGames = 0;
            TimePlayed = new TimeSpan(0);
            GameInProgress = false;
        }

        private void CreateGuessForms(int totalGuesses)
        {
            GuessCombo = new ComboBox[totalGuesses][];
            GuessLabel = new Label[totalGuesses][];
            GuessButton = new Button[totalGuesses];

            for (int i = 0; i < totalGuesses; i++)
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
                    GuessCombo[i][j].Size = new Size(30, 15);

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
                    GuessLabel[i][j].Size = new Size(15, 15);

                    this.Controls.Add(GuessCombo[i][j]);
                    this.Controls.Add(GuessLabel[i][j]);
                }

                GuessButton[i] = new Button();
                GuessButton[i].Location = new Point(40 + (60 * i), 180);
                GuessButton[i].Text = "Confirm";
                GuessButton[i].Click += new EventHandler(EvaluateGuess);
                GuessButton[i].Enabled = (i == 0);
                GuessButton[i].Size = new Size(50, 20);

                this.Controls.Add(GuessButton[i]);
            }

            Answer1.Location = new Point(60 + (60 * totalGuesses), 20);
            Answer2.Location = new Point(60 + (60 * totalGuesses), 60);
            Answer3.Location = new Point(60 + (60 * totalGuesses), 100);
            Answer4.Location = new Point(60 + (60 * totalGuesses), 140);
            ResetButton.Location = new Point(45 + (60 * totalGuesses), 180);
            PauseButton.Location = new Point(95 + (60 * totalGuesses), 180);
            PauseButton.Visible = false;

            TimeLabel.Location = new Point(30 + (60 * totalGuesses), 214);
            AverageLabel.Location = new Point(34 + (60 * totalGuesses), 230);

            FastLabel.Location = new Point(100 + (60 * totalGuesses), 214);
            SlowLabel.Location = new Point(100 + (60 * totalGuesses), 230);

            this.Size = new Size(190 + (60 * totalGuesses), 300);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
        private void ClearGame()
        {
            for (int i = 0; i < GuessCombo.Length; i++)
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
        }

        private void DrawAnswers(Game game)
        {
            Answer1.Text = game.Answers[0].ToString();
            Answer2.Text = game.Answers[1].ToString();
            Answer3.Text = game.Answers[2].ToString();
            Answer4.Text = game.Answers[3].ToString();

            GuessCombo[0][0].Focus();
        }

        private void EvaluateGuess(object sender, EventArgs e)
        {
            if(Timer.StartTime == null)
            {
                Timer.Start();
                PauseButton.Visible = true;
            }

            var evaluatedGuesses = Game.EvaluateGuess(GuessCombo[CurrentGuess].Select(combo => int.Parse(combo.Text)).ToArray());

            FillLabels(evaluatedGuesses.Item1, evaluatedGuesses.Item2);

            if (evaluatedGuesses.Item1 == 4)
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
        
        private int GetAnswersAsInt(int[] answers)
        {
            var totalAnswer = string.Empty;

            foreach (var answer in answers)
            {
                totalAnswer += answer.ToString();
            }

            return int.Parse(totalAnswer);
        }

        private void HideBoard()
        {
            GuessButton[CurrentGuess].Enabled = false;

            for (int i = 0; i < 4; i++)
            {
                GuessCombo[CurrentGuess][i].Enabled = false;
            }

            for(int i = 0; i < CurrentGuess; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    GuessLabel[i][j].Visible = false;
                }
            }
        }

        private void NextGuess()
        {
            GameInProgress = true;
            for (int j = 0; j < 4; j++)
            {
                GuessCombo[CurrentGuess][j].Enabled = false;
            }

            GuessButton[CurrentGuess].Enabled = false;

            if (CurrentGuess < Game.TotalGuesses - 1)
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
        
        private void NewGame()
        {
            Game = new Game(8);
            Timer = new GameTimer();
            CurrentGuess = 0;
            DrawAnswers(Game);
        }

        private void ShowAnswers()
        {
            Answer1.BackColor = Color.Turquoise;
            Answer2.BackColor = Color.Turquoise;
            Answer3.BackColor = Color.Turquoise;
            Answer4.BackColor = Color.Turquoise;

            ResetButton.Focus();

            TotalGames++;
            TimePlayed += TimeSpan.FromSeconds(Timer.GetCurrentSecondsElapsed());
            GameInProgress = false;
            contextMenuStrip1.Items[0].Text = "Total Games Played: " + TotalGames;
            contextMenuStrip1.Items[1].Text = "Total Time Played: " + TimePlayed;
            contextMenuStrip1.Items[2].Text = "Average: " + TimePlayed.TotalSeconds / TotalGames;      

            double secondsPlayed = (TimePlayed - LastTimePlayed).TotalSeconds;

            TimeLabel.Text = "Time: " + secondsPlayed.ToString("F2");
            TimeLabel.Visible = true;

            AverageLabel.Text = "Avg: " + (TimePlayed.TotalSeconds / TotalGames).ToString("F2");
            AverageLabel.Visible = true;

            var answersKey = GetAnswersAsInt(Game.Answers);

            if (!Records.ContainsKey(answersKey))
            {
                Records.Add(answersKey, new GameRecord(new List<double>() { secondsPlayed }));
            }
            else
            {
                FastLabel.Text = "Fast: " + Records[answersKey].Fastest.ToString("F2");
                SlowLabel.Text = "Slow: " + Records[answersKey].Slowest.ToString("F2");

                FastLabel.Visible = true;
                if (Records[answersKey].Fastest != Records[answersKey].Slowest)
                {
                    SlowLabel.Visible = true;
                }

                Records[answersKey].AddTime(secondsPlayed);
            }            
        }        

        private void ShowBoard()
        {
            GuessButton[CurrentGuess].Enabled = true;

            for (int i = 0; i < 4; i++)
            {
                GuessCombo[CurrentGuess][i].Enabled = true;
            }

            for (int i = 0; i < CurrentGuess; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    GuessLabel[i][j].Visible = true;
                }
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            this.PauseButton.Visible = false;
            ClearGame();
            NewGame();
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
            if (GameInProgress && contextMenuStrip1.Items.Count > 0)
            {
                TimePlayed += TimeSpan.FromSeconds(Timer.GetCurrentSecondsElapsed());
                contextMenuStrip1.Items[1].Text = "Total Time Played: " + TimePlayed;
            }
        }

        private void CodeMain_Activated(object sender, EventArgs e)
        {
            if (GameInProgress)
            {
                Timer.GetCurrentSecondsElapsed();
                Timer.Start();
            }
        }

        private void CodeMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            RecordsRepository.SaveRecords(Records);
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            if(GameInProgress) //pause
            {
                Timer.Pause();
                GameInProgress = false;
                PauseButton.Text = "Resume";
                PauseButton.Width = 80;
                HideBoard();
            }
            else //resume
            {
                GameInProgress = true;
                PauseButton.Text = "Pause";
                PauseButton.Width = 70;
                ShowBoard();
                if(CurrentGuess > 0)
                {
                    Timer.Start();
                    GuessCombo[CurrentGuess][0].Focus();
                }
            }

            //this.ResumeLayout(true);
            //this.PerformLayout();
        }
    }
}
