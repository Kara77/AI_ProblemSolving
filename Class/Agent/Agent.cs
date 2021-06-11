using System;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace AI_ProblemSolving
{
    class Task
    {
        public enum TYPE
        {
            changeProblem,
            changeSearchingAlgorithm,
            startResolution,
            doNextStep,
            resolveEverything,
            pauseResolution,
            randomBoard,
            createBoard,
            resetAll,
            reset,
            kill
        }

        public string board { get; set; }

        public TYPE type { get; set; }
        public string payload { get; set; }

        public Task(TYPE type, string payload = "", string board = "") {
            this.type = type;
            this.payload = payload;
            this.board = board;
        }
    }

    public class AgentManager
    {
        List<Task> taskList;
        List<Thread> agentList;
        private List<AProblem<ABoardState>> problems;
        private List<ASearchingAlgorithm<ABoardState>> searchingAlgorithms;
        private AProblem<ABoardState> selectedProblem;
        private ASearchingAlgorithm<ABoardState> selectedSearchingAlgorithm;
        private Control.ControlCollection control;
        public string board;

        public MainMenu mainMenu { get; set; }

        /*private void giveInstructionsToAgents()
        {
            if (this.taskList.Count > 0)
            {
                foreach(Agent agent in this.agentList)
                {
                    agent.doAction(taskList[0]);
                    taskList.RemoveAt(0);
                }
            }
        }

        private void addInstructions()
        {
            if (this.taskList.Count > 0)
            {
                foreach (Agent agent in this.agentList)
                {
                    agent.doAction(taskList[0]);
                    taskList.RemoveAt(0);
                }
            }
        }*/


        public void setControler(Control.ControlCollection control)
        {
            this.control = control;
        }

        public List<string> getProblemNames()
        {
            List<string> result = new List<string>();
            foreach (AProblem<ABoardState> problem in this.problems)
            {
                result.Add(problem.name);
            }
            return result;
        }

        public List<string> getSearchAlgorithmNames()
        {
            List<string> result = new List<string>();
            foreach (ASearchingAlgorithm<ABoardState> searchingAlgorithm in this.searchingAlgorithms)
            {
                result.Add(searchingAlgorithm.name);
            }
            return result;
        }

        public void selectProblem(string name)
        {
            

            foreach (AProblem<ABoardState> problem in this.problems)
            {
                if (name == problem.name)
                {
                    this.selectedProblem = problem;
                    this.taskList.Add(new Task(Task.TYPE.changeProblem, problem.name));
                    return;
                }
            }
            
            // throw new Exception("selectProblem: AgentManager doesn't know your problem.");
        }

        public List<string> getSearchingAlgorithmNames()
        {
            
            List<string> result = new List<string>();

            foreach (ASearchingAlgorithm<ABoardState> searchingAlgorithm in this.searchingAlgorithms)
            {
                result.Add(searchingAlgorithm.name);
            }
            
            return result;
        }

        public void selectSearchingAlgorithm(string name)
        {
            foreach (ASearchingAlgorithm<ABoardState> searchingAlgorithm in this.searchingAlgorithms)
            {
                if (name == searchingAlgorithm.name)
                {
                    this.selectedSearchingAlgorithm = searchingAlgorithm;
                    this.taskList.Add(new Task(Task.TYPE.changeSearchingAlgorithm, searchingAlgorithm.name));
                    return;
                }
            }
            
            // throw new Exception("selectProblem: AgentManager doesn't know your searching algorithm.");
        }


        public AgentManager()
        {
            taskList = new List<Task>();
            agentList = new List<Thread>();

            // Add problems that you want to implement ear :
            this.problems = new List<AProblem<ABoardState>> {
                new Puzzle(3),
                new Puzzle(5),
                new Queen(5)
            };

            // Add searching algorithms that you want to implement ear :
            this.searchingAlgorithms = new List<ASearchingAlgorithm<ABoardState>>
            {
                new BreadthFirstSearch(),
                new IterativeDeepeningSearch(5),
                new HillClimbing(),
                new GreedySearch(),
                new AStar(),
            };
        }

        public void runNewAgent()
        {
            if (this.agentList.Count <= 0)
            {
                Agent newAgent = new Agent(problems, searchingAlgorithms, ref taskList, control.Add);
                Thread agentThread = new Thread(newAgent.run);
                this.agentList.Add(agentThread);
                agentThread.Start();
            }
        }

        public void startOrderAgent()
        {
            this.taskList.Add(new Task(Task.TYPE.startResolution));
        }

        public void nextStepOrderAgent()
        {
            this.taskList.Add(new Task(Task.TYPE.doNextStep));
        }

        public void pauseResolutionOrderAgent()
        {
            this.taskList.Add(new Task(Task.TYPE.pauseResolution));
        }

        public void ChangeAlgoOrderAgent()
        {
            this.taskList.Add(new Task(Task.TYPE.changeSearchingAlgorithm));
        }

        public void RandomBoard()
        {
            this.taskList.Add(new Task(Task.TYPE.randomBoard));
        }

        public void resetProblem()
        {
            this.taskList.Add(new Task(Task.TYPE.reset));
        }

        public void resetAll()
        {
            this.taskList.Add(new Task(Task.TYPE.resetAll));
        }

        public void setOwnBoard(string board)
        {
            this.taskList.Add(new Task(Task.TYPE.createBoard, "", board));
        }


        ~AgentManager() { }
    }
    class Agent
    {
        private List<AProblem<ABoardState>> problems;
        private List<ASearchingAlgorithm<ABoardState>> searchingAlgoritms;
        private List<Task> tasks;
        private Action<Control> guiControler;
        private string ownBoard;

        private AProblem<ABoardState> currentProblem;
        private ASearchingAlgorithm<ABoardState> currentSearchingAlgorithm;

        private bool alive;
        private bool shouldWaitUser = false;
        private bool isSolving;
        private List<Node<ABoardState>> nodes;

        int count = 1;
        int x = 160;

        public Agent(
            List<AProblem<ABoardState>> problems,
            List<ASearchingAlgorithm<ABoardState>> searchingAlgoritms, 
            ref List<Task> tasks,
            Action<Control> guiControler
        )
        {
            this.problems = problems;
            this.searchingAlgoritms = searchingAlgoritms;
            this.tasks = tasks;
            this.guiControler = guiControler;
            this.alive = true;
            this.shouldWaitUser = true;
            this.isSolving = false;
            this.reset();
        }

        private void reset()
        {
            this.currentProblem = null;
            this.currentSearchingAlgorithm = null;
            this.alive = true;
            this.shouldWaitUser = true;
            this.isSolving = false;
            this.nodes = new List<Node<ABoardState>> ();
        }

        private void doOnePendingTask()
        {
            if (this.tasks.Count > 0)
            {
                MainMenu.mut.WaitOne();
                Task newTask = this.tasks[0];
                tasks.RemoveAt(0);
                MainMenu.mut.ReleaseMutex();
                switch (newTask.type)
                {
                    case Task.TYPE.changeProblem:
                        this.setProblem(newTask.payload);
                        Console.WriteLine("change problem !");
                        resetResolution();
                        break;
                    case Task.TYPE.changeSearchingAlgorithm:
                        Console.WriteLine("change  algo !");
                        shouldWaitUser = true;
                        this.setSearchingAlgorithm(newTask.payload);
                        resetResolution();
                        break;
                    case Task.TYPE.doNextStep:
                        Console.WriteLine("I do the next step !");
                        this.nodes = this.currentSearchingAlgorithm.resolveOneStep(ref this.nodes, ref this.currentProblem);
                        if (this.nodes.Count != 0)
                        {
                            this.showInThread(this.nodes[0].getState(), this.nodes[0].getDepth(), this.nodes[0].getParentNode());
                        }
                        break;
                    case Task.TYPE.startResolution:
                        Console.WriteLine("I resolve the solution !");
                        shouldWaitUser = false;
                        this.currentSearchingAlgorithm.isFinished = false;
                        this.currentSearchingAlgorithm.isSolved = false;
                        if (this.nodes.Count != 0)
                        {
                            this.showInThread(this.nodes[0].getState(), this.nodes[0].getDepth(), this.nodes[0].getParentNode());
                        }
                        break;
                    case Task.TYPE.pauseResolution:
                        Console.WriteLine("I stop the resolution !");
                        shouldWaitUser = true;
                        break;
                    case Task.TYPE.randomBoard:
                        Console.WriteLine("I random !");
                        this.currentProblem.initialState.RandomBoard();
                        this.resetResolution();
                        break;
                    case Task.TYPE.createBoard:
                        Console.WriteLine("I create a board !");
                        this.currentProblem.initialState.OwnBoard(newTask.board);
                        this.resetResolution();
                        break;
                    case Task.TYPE.resetAll:
                        this.currentProblem.resetCache();
                        Console.WriteLine("I reset everything !");
                        resetAll();
                        break;
                    case Task.TYPE.reset:
                        this.currentProblem.resetCache();
                        Console.WriteLine("I reset the problem !");
                        resetResolution();
                        break;
                    case Task.TYPE.kill:
                        break;
                }
            }
            if (this.currentSearchingAlgorithm != null && !this.currentSearchingAlgorithm.isFinished && shouldWaitUser == false)
            {
                this.nodes = this.currentSearchingAlgorithm.resolveOneStep(ref this.nodes, ref this.currentProblem);
                if (this.nodes.Count != 0)
                {
                    this.showInThread(this.nodes[0].getState(), this.nodes[0].getDepth(), this.nodes[0].getParentNode());
                }
            }
            else if (this.currentSearchingAlgorithm != null && this.currentSearchingAlgorithm.isFinished && shouldWaitUser == false)
            {
                SolverForm.EndResolved();
                shouldWaitUser = true;
            }
        }

        public void run()
        { 
            while (alive)
            {
                doOnePendingTask();
            }
            return;
        }
        private void showInThread(ABoardState current = null, uint nbparents = 0, ABoardState previous = null)
        {
            long nbnode;

            if (current == null)
            {
                MainMenu.SetControlPropertyThreadSafe(MainMenu.ThreadCurrentNode, "Text", "rien");
            } 
            else
            {
                MainMenu.SetControlPropertyThreadSafe(MainMenu.ThreadCurrentNode, "Text", current.toGraphicalString());
            }

            if (previous == null)
            {
                MainMenu.SetControlPropertyThreadSafe(MainMenu.ThreadPreviousNode, "Text", "rien");
            }
            else
            {
                MainMenu.SetControlPropertyThreadSafe(MainMenu.ThreadPreviousNode, "Text", previous.toGraphicalString());
            }
            MainMenu.SetControlPropertyThreadSafe(MainMenu.ThreadnbParentsNode, "Text", nbparents.ToString());

            if (MainMenu.ThreadnbNode.Text == "Bonjour je suis nbNode !")
            {
                nbnode = 0;
            }
            else
            {
                nbnode = Int64.Parse(MainMenu.ThreadnbNode.Text);
            }
            MainMenu.SetControlPropertyThreadSafe(MainMenu.ThreadnbNode, "Text", (nbnode + 1).ToString());
        }

        private void resetResolution()
        {
            if (currentProblem == null)
            {
                Console.WriteLine("I'm waiting for a problem to start !");
                return;
            }
            else if (currentSearchingAlgorithm == null)
            {
                Console.WriteLine("I'm waiting for a searching algorithm to start !");
                return;
            }
            this.nodes = new List<Node<ABoardState>> { new Node<ABoardState>(currentProblem.initialState) };
            this.isSolving = false;
            MainMenu.SetControlPropertyThreadSafe(MainMenu.ThreadnbNode, "Text", "0");
            showInThread(this.nodes[0].getState(), this.nodes[0].getDepth());
        }

        public void resetAll()
        {
            this.currentSearchingAlgorithm = null;
            this.nodes = null;
            this.isSolving = false;
            showInThread();
            MainMenu.SetControlPropertyThreadSafe(MainMenu.ThreadnbNode, "Text", "0");
        }

        void setProblem(string name)
        {
            foreach (AProblem<ABoardState> problem in this.problems)
            {
                if (name == problem.name)
                {
                    this.currentProblem = problem;
                    return;
                }
            }
            Console.Write("sorry but I don't know this problem :(");
        }

        void setSearchingAlgorithm(string name)
        {
            foreach (ASearchingAlgorithm<ABoardState> searchingAlgorithm in this.searchingAlgoritms)
            {
                Console.WriteLine("name: {0}, agenName: {1}", name, searchingAlgorithm.name);
                if (name == searchingAlgorithm.name)
                {
                    this.currentSearchingAlgorithm = searchingAlgorithm;
                    return;

                }
            }
            Console.Write("sorry but I don't know this searching algorithm :(");
        }

        ~Agent() { }
    }
}
