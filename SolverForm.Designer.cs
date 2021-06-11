using System.Drawing;
using System.Windows.Forms;

namespace AI_ProblemSolving
{
    partial class SolverForm
    {
        private void ImageExampleForm_Paint(object sender, PaintEventArgs e)
        {
            // Create image.
            Image newImage = Image.FromFile("SampImag.jpg");

            // Create Point for upper-left corner of image.
            Point ulCorner = new Point(100, 100);

            // Draw image to screen.
            e.Graphics.DrawImage(newImage, ulCorner);
        }

        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.quitButton = new System.Windows.Forms.Button();
            this.resolveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.returnMainMenuButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textCreateBoard = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.randomizeButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.algoSelectionComboBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.nextStepButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.okCreateBoardButton = new System.Windows.Forms.Button();
            this.RestartButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TimerLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.agentManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.agentManagerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.quitButton.Location = new System.Drawing.Point(1085, 604);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(149, 31);
            this.quitButton.TabIndex = 0;
            this.quitButton.Text = "Leave the app";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // resolveButton
            // 
            this.resolveButton.BackColor = System.Drawing.Color.YellowGreen;
            this.resolveButton.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.resolveButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.resolveButton.Location = new System.Drawing.Point(22, 127);
            this.resolveButton.Name = "resolveButton";
            this.resolveButton.Size = new System.Drawing.Size(115, 31);
            this.resolveButton.TabIndex = 8;
            this.resolveButton.Text = "Resolve";
            this.resolveButton.UseVisualStyleBackColor = false;
            this.resolveButton.Click += new System.EventHandler(this.resolveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Current node :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 481);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Number of nodes :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 520);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Number of parent nodes :";
            // 
            // returnMainMenuButton
            // 
            this.returnMainMenuButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.returnMainMenuButton.Location = new System.Drawing.Point(1085, 568);
            this.returnMainMenuButton.Name = "returnMainMenuButton";
            this.returnMainMenuButton.Size = new System.Drawing.Size(149, 30);
            this.returnMainMenuButton.TabIndex = 14;
            this.returnMainMenuButton.Text = "Return main menu";
            this.returnMainMenuButton.UseVisualStyleBackColor = false;
            this.returnMainMenuButton.Click += new System.EventHandler(this.returnMainMenuButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Previous node :";
            // 
            // textCreateBoard
            // 
            this.textCreateBoard.Location = new System.Drawing.Point(185, 78);
            this.textCreateBoard.Name = "textCreateBoard";
            this.textCreateBoard.Size = new System.Drawing.Size(185, 23);
            this.textCreateBoard.TabIndex = 20;
            this.textCreateBoard.TextChanged += new System.EventHandler(this.textCreateBoard_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Create your own board :";
            // 
            // randomizeButton
            // 
            this.randomizeButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.randomizeButton.Location = new System.Drawing.Point(185, 101);
            this.randomizeButton.Name = "randomizeButton";
            this.randomizeButton.Size = new System.Drawing.Size(185, 31);
            this.randomizeButton.TabIndex = 19;
            this.randomizeButton.Text = "Randomize";
            this.randomizeButton.UseVisualStyleBackColor = false;
            this.randomizeButton.Click += new System.EventHandler(this.RandomizeButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Algorithm selected :";
            // 
            // algoSelectionComboBox
            // 
            this.algoSelectionComboBox.FormattingEnabled = true;
            this.algoSelectionComboBox.Location = new System.Drawing.Point(160, 29);
            this.algoSelectionComboBox.Name = "algoSelectionComboBox";
            this.algoSelectionComboBox.Size = new System.Drawing.Size(251, 24);
            this.algoSelectionComboBox.TabIndex = 24;
            this.algoSelectionComboBox.SelectedIndexChanged += new System.EventHandler(this.algoSelectionComboBox_SelectedIndexChanged);
            // 
            // okButton
            // 
            this.okButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.okButton.Location = new System.Drawing.Point(417, 25);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(37, 30);
            this.okButton.TabIndex = 26;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // nextStepButton
            // 
            this.nextStepButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.nextStepButton.Location = new System.Drawing.Point(22, 201);
            this.nextStepButton.Name = "nextStepButton";
            this.nextStepButton.Size = new System.Drawing.Size(115, 31);
            this.nextStepButton.TabIndex = 27;
            this.nextStepButton.Text = "Next Step";
            this.nextStepButton.UseVisualStyleBackColor = false;
            this.nextStepButton.Click += new System.EventHandler(this.nextStepButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.BackColor = System.Drawing.Color.Orange;
            this.StopButton.Location = new System.Drawing.Point(22, 164);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(115, 31);
            this.StopButton.TabIndex = 28;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.resetButton.Location = new System.Drawing.Point(143, 238);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(115, 31);
            this.resetButton.TabIndex = 29;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // okCreateBoardButton
            // 
            this.okCreateBoardButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.okCreateBoardButton.Location = new System.Drawing.Point(376, 74);
            this.okCreateBoardButton.Name = "okCreateBoardButton";
            this.okCreateBoardButton.Size = new System.Drawing.Size(37, 30);
            this.okCreateBoardButton.TabIndex = 30;
            this.okCreateBoardButton.Text = "OK";
            this.okCreateBoardButton.UseVisualStyleBackColor = false;
            this.okCreateBoardButton.Click += new System.EventHandler(this.okCreateBoardButton_Click);
            // 
            // RestartButton
            // 
            this.RestartButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.RestartButton.Location = new System.Drawing.Point(22, 238);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(115, 31);
            this.RestartButton.TabIndex = 31;
            this.RestartButton.Text = "Restart";
            this.RestartButton.UseVisualStyleBackColor = false;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.TimerLabel_Tick);
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Location = new System.Drawing.Point(195, 171);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(42, 17);
            this.TimerLabel.TabIndex = 32;
            this.TimerLabel.Text = "0 sec";
            this.TimerLabel.Click += new System.EventHandler(this.TimerLabel_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(145, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 33;
            this.label7.Text = "Timer :";
            // 
            // agentManagerBindingSource
            // 
            this.agentManagerBindingSource.DataSource = typeof(AI_ProblemSolving.AgentManager);
            // 
            // SolverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 647);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.RestartButton);
            this.Controls.Add(this.okCreateBoardButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.nextStepButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.algoSelectionComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.randomizeButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textCreateBoard);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.returnMainMenuButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resolveButton);
            this.Controls.Add(this.quitButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SolverForm";
            this.Text = "Solvator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.agentManagerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button quitButton;
        private Button resolveButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button returnMainMenuButton;
        private Label label4;
        private TextBox textCreateBoard;
        private Label label5;
        private Button randomizeButton;
        private Label label6;
        private ComboBox algoSelectionComboBox;
        private Button okButton;
        private BindingSource agentManagerBindingSource;
        private Button nextStepButton;
        private Button StopButton;
        private Button resetButton;
        private Button okCreateBoardButton;
        private Button RestartButton;
        private Timer timer1;
        private Label TimerLabel;
        private Label label7;
    }
}

