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
    public partial class MainMenu : Form
    {
        public static Mutex mut = new Mutex();
        public static AgentManager agentManager = new AgentManager();

        public static Button ThreadCurrentNode = new Button();
        public static Button ThreadPreviousNode = new Button();
        public static Button ThreadnbNode = new Button();
        public static Button ThreadnbParentsNode = new Button();
        public static SolverForm solverForm = new SolverForm();

        private delegate void SetControlPropertyThreadSafeDelegate(
            Control control,
            string propertyName,
            object propertyValue
        );

        public static void SetControlPropertyThreadSafe(
            Control control,
            string propertyName,
            object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate
                (SetControlPropertyThreadSafe),
                new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(
                    propertyName,
                    BindingFlags.SetProperty,
                    null,
                    control,
                    new object[] { propertyValue });
            }
        }


        public MainMenu()
        {
            InitializeComponent();
            agentManager.mainMenu = this;
            comboBox1.Items.AddRange(agentManager.getProblemNames().ToArray());
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to close this form ?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
                Environment.Exit(1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            quitButton.Text = "Leave the app";
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            int resultIndex = -1;
            string selectedPuzzle = (string)comboBox1.SelectedItem;
            
            resultIndex = comboBox1.FindStringExact(selectedPuzzle);

            if (resultIndex != -1)
            {
                agentManager.selectProblem(selectedPuzzle);
                this.Hide();
                solverForm.Show();
            }
        }
    }
}