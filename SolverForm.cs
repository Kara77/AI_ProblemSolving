using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

namespace AI_ProblemSolving
{
    public partial class SolverForm : Form
    {
        bool finish = false;
        int count = 0;
        string timerTxt;

        private void DisableButtons()
        {
            resolveButton.Enabled = false;
            StopButton.Enabled = false;
            RestartButton.Enabled = false;
            resetButton.Enabled = false;
            nextStepButton.Enabled = false;
        }

        private void EnableButtons()
        {
            resolveButton.Enabled = true;
            StopButton.Enabled = true;
            RestartButton.Enabled = true;
            resetButton.Enabled = true;
            nextStepButton.Enabled = true;
        }

        private void EnableOkButtons()
        {
            okButton.Enabled = true;
            okCreateBoardButton.Enabled = true;
            randomizeButton.Enabled = true;
        }

        private void DisableOkButtons()
        {
            okButton.Enabled = false;
            okCreateBoardButton.Enabled = false;
            randomizeButton.Enabled = false;
        }

        private void ResetTimer()
        {
            count = 0;
            timer1.Stop();
            TimerLabel.Text = count.ToString() + " sec";
        }

        private void initThreadNode(string text, int x, int y, Button toDisplay)
        {
            toDisplay.Text = text;
            toDisplay.Name = "threadConsole";
            toDisplay.Size = new Size(80, 85);
            toDisplay.Location = new Point(x, y);
            this.Controls.Add(toDisplay);
        }

        private void initThreadNodeMetric(string text, int x, int y, Button toDisplay)
        {
            toDisplay.Text = text;
            toDisplay.Name = "threadConsole";
            toDisplay.Size = new Size(120, 31);
            toDisplay.Location = new Point(x, y);
            this.Controls.Add(toDisplay);
        }

        public SolverForm()
        {
            initThreadNode("none", 153, 381, MainMenu.ThreadCurrentNode);
            initThreadNode("none", 153, 296, MainMenu.ThreadPreviousNode);
            initThreadNodeMetric("0", 150, 474, MainMenu.ThreadnbNode);
            initThreadNodeMetric("0", 195, 512, MainMenu.ThreadnbParentsNode);

            InitializeComponent();
            algoSelectionComboBox.Items.AddRange(MainMenu.agentManager.getSearchAlgorithmNames().ToArray());
            MainMenu.agentManager.setControler(Controls);
            MainMenu.agentManager.runNewAgent();
            DisableButtons();
            EnableOkButtons();
            label7.Hide();
            TimerLabel.Hide();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to close the app ?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                this.Close();
                Environment.Exit(1);
            }
        }

        private void textCreateBoard_TextChanged(object sender, EventArgs e)
        {

        }

        private void RandomizeButton_Click(object sender, EventArgs e)
        {
            MainMenu.agentManager.RandomBoard();
        }

        private void resolveButton_Click(object sender, EventArgs e)
        {
            MainMenu.agentManager.startOrderAgent();
            StopButton.Enabled = true;
            RestartButton.Enabled = false;
            returnMainMenuButton.Enabled = false;
            DisableOkButtons();
            okCreateBoardButton.Enabled = false;
            label7.Show();
            TimerLabel.Show();
            nextStepButton.Enabled = false;
            TimerLabel.Text = count.ToString() + " sec";
            timer1.Start();
        }

        private void returnMainMenuButton_Click(object sender, EventArgs e)
        {
            MainMenu.agentManager.mainMenu.Show();
            this.Hide();
            timer1.Stop();
            DisableButtons();
            EnableOkButtons();
            label7.Hide();
            TimerLabel.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnableOkButtons();
            ResetTimer();
            timerTxt = TimerLabel.Text;
            
            quitButton.Text = "Leave the app";
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            int resultIndex = -1;
            string selectedAlgo = (string)algoSelectionComboBox.SelectedItem;

            resultIndex = algoSelectionComboBox.FindStringExact(selectedAlgo);
            if (resultIndex == -1)
            {
                MessageBox.Show("Please select an algorithm");
                return;
            }
            MainMenu.agentManager.selectSearchingAlgorithm((string)algoSelectionComboBox.SelectedItem);
            EnableButtons();
            ResetTimer();
        }

        private void algoSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        { }

        private void nextStepButton_Click(object sender, EventArgs e)
        {
            MainMenu.agentManager.nextStepOrderAgent();
            DisableOkButtons();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("STOPPP");
            MainMenu.agentManager.pauseResolutionOrderAgent();
            nextStepButton.Enabled = true;
            StopButton.Enabled = false;
            returnMainMenuButton.Enabled = true;
            timer1.Stop();
            RestartButton.Enabled = true;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            MainMenu.agentManager.resetAll();
            algoSelectionComboBox.ResetText();
            DisableButtons();
            EnableOkButtons();
            ResetTimer();
            label7.Hide();
            TimerLabel.Hide();
        }

        private void okCreateBoardButton_Click(object sender, EventArgs e)
        {
            ResetTimer();
            MainMenu.agentManager.setOwnBoard(textCreateBoard.Text);
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            MainMenu.agentManager.resetProblem();
            ResetTimer();
        }

        private void TimerLabel_Tick(object sender, EventArgs e)
        {
            count++;
            TimerLabel.Text = count.ToString() + " sec";
        }

        public static void EndResolved()
        {
            MainMenu.solverForm.timer1.Stop();

            MessageBox.Show("it's finished !!!");
            return;
        }
    }
}