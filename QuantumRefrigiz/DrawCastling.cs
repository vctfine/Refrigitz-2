using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
namespace QuantumRefrigiz
{
    [Serializable]
    public class DrawCastling
    {
        private readonly StringBuilder Space = new StringBuilder("&nbsp;");
        private readonly int Spaces = 0;

        public static bool KingGrayNotCheckedByQuantumMove = false;
        public static bool KingBrownNotCheckedByQuantumMove = false;

        public int WinOcuuredatChiled = 0; public int[] LoseOcuuredatChiled = { 0, 0, 0 };



        //Initiate Global Variables.
        private List<int[]> ValuableSelfSupported = new List<int[]>();

        public bool MovementsAStarGreedyHeuristicFoundT = false;
        public bool IgnoreSelfObjectsT = false;
        public bool UsePenaltyRegardMechnisamT = false;
        public bool BestMovmentsT = false;
        public bool PredictHeuristicT = true;
        public bool OnlySelfT = false;
        public bool AStarGreedyHeuristicT = false;

        public bool ArrangmentsChanged = true;
        public static long MaxHeuristicxK = -20000000000000000;
        public float Row, Column;
        public Color color;
        public int[,] Table = null;
        public ThinkingQuantumChess[] CastlingThinking = new ThinkingQuantumChess[1];
        public int Current = 0;
        public int Order;
        private readonly int CurrentAStarGredyMax = -1;

        private static void Log(Exception ex)
        {

            try
            {
                object a = new object();
                lock (a)
                {
                    string stackTrace = ex.ToString();
                    //Write to File.
                    Helper.WaitOnUsed(AllDraw.Root + "\\ErrorProgramRun.txt"); File.AppendAllText(AllDraw.Root + "\\ErrorProgramRun.txt", stackTrace + ": On" + DateTime.Now.ToString());

                }
            }

            catch (Exception) { }

        }
        public void Dispose()
        {

            ValuableSelfSupported = null;

        }

        public double ReturnHeuristic()
        {
            int HaveKilled = 0;

            double a = 0;
            for (int ii = 0; ii < 1; ii++)
            {
                a += CastlingThinking[ii].ReturnHeuristic(-1, -1, Order, false, ref HaveKilled);
            }

            return a;
        }

        //Constructor 1.

        //Constructor 2.
        public DrawCastling(int CurrentAStarGredy, bool MovementsAStarGreedyHeuristicTFou, bool IgnoreSelfObject, bool UsePenaltyRegardMechnisa, bool BestMovment, bool PredictHurist, bool OnlySel, bool AStarGreedyHuris, bool Arrangments, float i, float j, Color a, int[,] Tab, int Ord, bool TB, int Cur//, ref AllDraw. THIS
            )
        {

            object balancelock = new object();
            lock (balancelock)
            {


                CurrentAStarGredyMax = CurrentAStarGredy;
                MovementsAStarGreedyHeuristicFoundT = MovementsAStarGreedyHeuristicTFou;
                IgnoreSelfObjectsT = IgnoreSelfObject;
                UsePenaltyRegardMechnisamT = UsePenaltyRegardMechnisa;
                BestMovmentsT = BestMovment;
                PredictHeuristicT = PredictHurist;
                OnlySelfT = OnlySel;
                AStarGreedyHeuristicT = AStarGreedyHuris;
                ArrangmentsChanged = Arrangments;
                //Iniatite Global Variables.
                Table = new int[8, 8];
                for (int ii = 0; ii < 8; ii++)
                {
                    for (int jj = 0; jj < 8; jj++)
                    {
                        Table[ii, jj] = Tab[ii, jj];
                    }
                }

                if (Order == 1)
                {
                    for (int ii = 0; ii < 1; ii++)
                    {
                        CastlingThinking[ii] = new ThinkingQuantumChess(ii, 7, CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfObjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, (int)i, (int)j, a, CloneATable(Tab), 1, Ord, TB, Cur, 1, 7);
                    }
                }
                else
                {
                    for (int ii = 0; ii < 1; ii++)
                    {
                        CastlingThinking[ii] = new ThinkingQuantumChess(ii, -7, CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfObjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, (int)i, (int)j, a, CloneATable(Tab), 1, Ord, TB, Cur, 1, -7);
                    }
                }
                Row = i;
                Column = j;
                color = a;
                Order = Ord;
                Current = Cur;
            }

        }

        private int[,] CloneATable(int[,] Tab)
        {

            object O = new object();
            lock (O)
            {
                //Create and new an Object.
                int[,] Table = new int[8, 8];
                //Assigne Parameter To New Objects.
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Table[i, j] = Tab[i, j];
                    }
                }
                //Return New Object.

                return Table;
            }

        }

        private bool[,] CloneATable(bool[,] Tab)
        {

            object O = new object();
            lock (O)
            {
                //Create and new an Object.
                bool[,] Table = new bool[8, 8];
                //Assigne Parameter To New Objects.
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Table[i, j] = Tab[i, j];
                    }
                }
                //Return New Object.

                return Table;
            }

        }

        //Clone a Copy.
        public void Clone(ref DrawCastling AA//, ref AllDraw. THIS
            )
        {

            int[,] Tab = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Tab[i, j] = Table[i, j];
                }
            }
            //Initiate a Construction Object and Clone a Copy.
            AA = new DrawCastling(CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfObjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, Row, Column, color, CloneATable(Table), Order, false, Current)
            {
                ArrangmentsChanged = ArrangmentsChanged
            };
            for (int i = 0; i < AllDraw.KingMovments; i++)
            {

                AA.CastlingThinking[i] = new ThinkingQuantumChess(i, 6, CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfObjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, (int)Row, (int)Column);
                CastlingThinking[i].Clone(ref AA.CastlingThinking[i]);

            }
            AA.Table = new int[8, 8];
            for (int ii = 0; ii < 8; ii++)
            {
                for (int jj = 0; jj < 8; jj++)
                {
                    AA.Table[ii, jj] = Tab[ii, jj];
                }
            }

            AA.Row = Row;
            AA.Column = Column;
            AA.Order = Order;
            AA.Current = Current;
            AA.color = color;

        }
        //Draw an Instatnt King on the Table Method.
        public void DrawCastlingOnTable(ref Graphics g, int CellW, int CellH)
        {
            object balancelockS = new object();

            lock (balancelockS)
            {
                if (g == null)
                {
                    return;
                }

                try
                {


                    if (((int)Row >= 0) && ((int)Row < 8) && ((int)Column >= 0) && ((int)Column < 8))
                    { //Gray Order.
                        if (Order == 1)
                        {
                            object O1 = new object();
                            lock (O1)
                            {    //Draw an Instant from File of Gray Soldeirs.
                                 //Draw an Instatnt Gray King Image On the Table.
                                g.DrawImage(Image.FromFile(AllDraw.ImagesSubRoot + "KG.png"), new Rectangle((int)(Row * CellW), (int)(Column * CellH), CellW, CellH));

                            }

                        }
                        else
                        {
                            object O1 = new object();
                            lock (O1)
                            {    //Draw an Instant from File of Gray Soldeirs.
                                 //Draw an Instatnt Brown King Image On the Table.
                                g.DrawImage(Image.FromFile(AllDraw.ImagesSubRoot + "KB.png"), new Rectangle((int)(Row * CellW), (int)(Column * CellH), CellW, CellH));

                            }
                        }
                    }


                }
                catch (Exception t)
                {
                    Log(t);
                }

            }
        }
    }
}
//End of Documentation.
