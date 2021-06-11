using System;
using System.Windows.Forms;

namespace AI_ProblemSolving
{
    class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        /// 
        

        [STAThread]
        static void Main()
        {
            string Puzzlechoice;
            string name;
            string Algochoice;
            // AgentManager agentManager = new AgentManager();
            AProblem<ABoardState> problem;

            // ASearchingAlgorithm<ABoardState> searchingAlgorithm = new BreadthFirstSearch();
            ASearchingAlgorithm<ABoardState> searchingAlgorithm;

            //get your problem and the problem name
            // should list all problem name from the AgentManager
            Puzzlechoice = "puzzle"; // Console.ReadLine();

            //set the Puzzle with the selection above
            if (Puzzlechoice == "puzzle")
            {
                int[,] example = new int[2, 2] { { 0, 3 }, { 2, 1 } };
                // int[,] example = new int[3, 3] { { 7, 2, 4 }, { 5, 0, 6 }, { 8, 3, 1} };
                problem = new Puzzle(2, ref example); // You could also put new Puzzle(3) to generate a puzzle with a random initial state.
            } 
            else if (Puzzlechoice == "queen")
            {
                problem = new Queen(4); // You could also put new Puzzle(3) to generate a puzzle with a random initial state.
            }
            else
            {
                Console.WriteLine("can't indentify which puzzle you selected.");
                return;
            }

            //display if everything goes well
            //Puzzle.displayGoalstate();    display the goal state of your problem
            //Puzzle.displayInitialstate(); display the initial state of your problem

            //get your algo user wanna use
            // Console.WriteLine("Enter the algorithm you want to use (xxx):");
            // Algochoice = Console.ReadLine();
            Algochoice = "as";
            switch (Algochoice)
            {
                case "bfs":
                    searchingAlgorithm = new BreadthFirstSearch();
                    break;
                case "ids":
                    searchingAlgorithm = new IterativeDeepeningSearch(20);
                    break;
                case "as":
                    searchingAlgorithm = new GreedySearch();
                    break;
                case "hc":
                    searchingAlgorithm = new HillClimbing();
                    break;
                default:
                    Console.Write("Niktamel !");
                    return;
            }

            //resolve the problem (should show step by step movement in cmd)
            (Node<ABoardState> firstNode, Node<ABoardState> lastNode) = searchingAlgorithm.resolve(problem);

            Console.WriteLine("finish !!");
            firstNode.getState().consoleDisplay();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
            return;
        }
    }
}
