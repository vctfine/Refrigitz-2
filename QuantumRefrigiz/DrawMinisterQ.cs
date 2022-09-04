using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
namespace QuantumRefrigiz
{
    [Serializable]
    public class DrawMinisterQ//:DrawKingQ
    {
        private readonly StringBuilder Space = new StringBuilder("&nbsp;");

        //#pragma warning disable CS0414 // The field 'DrawMinisterQ.Spaces' is ASsigned but its value is never used
        private readonly int Spaces = 0;
        //#pragma warning restore CS0414 // The field 'DrawMinisterQ.Spaces' is ASsigned but its value is never used

        //A quantum move cannot be used to take a piece.
        public bool IsQuntumMove = false;
        //Pieces have rings around them, filled in with colour. These rings show the probability that the piece is in that square.
        public bool RingHalf = false;
        public int WinOcuuredatChiled = 0; public int[] LoseOcuuredatChiled = { 0, 0, 0 };



        //Initiate Global Variable.
        private List<int[]> ValuableSelfSupported = new List<int[]>();

        public bool MovementsAStarGreedyHeuristicFoundT = false;
        public bool IgnoreSelfObjectsT = false;
        public bool UsePenaltyRegardMechnisamT = false;
        public bool BestMovmentsT = false;
        public bool PredictHeuristicT = true;
        public bool OnlySelfT = false;
        public bool AStarGreedyHeuristicT = false;

        public bool ArrangmentsChanged = true;
        public static double MaxHeuristicxM = double.MinValue;
        public float Row, Column;
        public Color color;
        public int[,] Table = null;
        public int Current = 0;
        public int Order;



        public ThinkingQuantumChess[] MinisterThinkingQuantum = new ThinkingQuantumChess[AllDraw.MinisterMovments];
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

        public bool MaxFound(ref bool MaxNotFound)
        {


            double a = ReturnHeuristic();
            if (MaxHeuristicxM < a)
            {
                object O2 = new object();
                lock (O2)
                {
                    MaxNotFound = false;
                    if (ThinkingQuantumChess.MaxHeuristicx < MaxHeuristicxM)
                    {
                        ThinkingQuantumChess.MaxHeuristicx = a;
                    }

                    MaxHeuristicxM = a;
                }

                return true;
            }

            MaxNotFound = true;

            return false;
        }
        public double ReturnHeuristic()
        {
            int HaveKilled = 0;

            double a = 0;
            for (int ii = 0; ii < AllDraw.MinisterMovments; ii++)
            {
                a += MinisterThinkingQuantum[ii].ReturnHeuristic(-1, -1, Order, false, ref HaveKilled);
            }

            return a;
        }
        //constructor 1.

        //Constructor 2.
        public DrawMinisterQ(int CurrentAStarGredy, bool MovementsAStarGreedyHeuristicTFou, bool IgnoreSelfObject, bool UsePenaltyRegardMechnisa, bool BestMovment, bool PredictHurist, bool OnlySel, bool AStarGreedyHuris, bool Arrangments, float i, float j, Color a, int[,] Tab, int Ord, bool TB, int Cur//, ref AllDraw. THIS
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
                //Initiate Global Variables.
                Table = new int[8, 8];
                for (int ii = 0; ii < 8; ii++)
                {
                    for (int jj = 0; jj < 8; jj++)
                    {
                        Table[ii, jj] = Tab[ii, jj];
                    }
                }

                for (int ii = 0; ii < AllDraw.MinisterMovments; ii++)
                {
                    MinisterThinkingQuantum[ii] = new ThinkingQuantumChess(ii, 5, CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfObjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, (int)i, (int)j, a, CloneATable(Tab), 32, Ord, TB, Cur, 2, 5);
                }

                Row = i;
                Column = j;
                color = a;
                Current = Cur;
                Order = Ord;
            }

        }

        private int[,] CloneATable(int[,] Tab)
        {

            object O = new object();
            lock (O)
            {
                //Create and new an Object.
                int[,] Table = new int[8, 8];
                //ASsigne Parameter To New Objects.
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
                //ASsigne Parameter To New Objects.
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
        public void Clone(ref DrawMinisterQ AA//, ref AllDraw. THIS
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
            //Initiate an Object and Clone a Construction Objectve.
            AA = new DrawMinisterQ(CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfObjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, Row, Column, color, CloneATable(Table), Order, false, Current)
            {
                ArrangmentsChanged = ArrangmentsChanged
            };
            for (int i = 0; i < AllDraw.MinisterMovments; i++)
            {

                AA.MinisterThinkingQuantum[i] = new ThinkingQuantumChess(i, 5, CurrentAStarGredyMax, MovementsAStarGreedyHeuristicFoundT, IgnoreSelfObjectsT, UsePenaltyRegardMechnisamT, BestMovmentsT, PredictHeuristicT, OnlySelfT, AStarGreedyHeuristicT, ArrangmentsChanged, (int)Row, (int)Column);
                MinisterThinkingQuantum[i].Clone(ref AA.MinisterThinkingQuantum[i]);


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
        //Draw an Mnister on the Table.
        public void DrawMinisterOnTable(ref Graphics g, int CellW, int CellH)
        {
            object balancelockS = new object();

            lock (balancelockS)
            {
                if (g == null)
                {
                    return;
                }

                int LastRowQ = -1, LastColumnQ = -1;


                if (AllDraw.LastRowQ != Row && AllDraw.LastColumnQ != Column && AllDraw.LastRowQ != -1 && AllDraw.LastColumnQ != -1)

                {
                    if (AllDraw.QuntumTable[0, (int)Row, (int)Column] != -1 && AllDraw.QuntumTable[0, (int)Row, (int)Column] != -1)
                    {
                        LastRowQ = AllDraw.QuntumTable[0, (int)Row, (int)Column];
                        LastColumnQ = AllDraw.QuntumTable[1, (int)Row, (int)Column];
                        IsQuntumMove = true;
                    }
                    else
                    if (AllDraw.LastRowQ != -1 && AllDraw.LastColumnQ != -1)
                    {
                        LastRowQ = AllDraw.LastRowQ;
                        LastColumnQ = AllDraw.LastColumnQ;
                        AllDraw.LastRowQ = -1;
                        AllDraw.LastColumnQ = -1;
                        IsQuntumMove = true;
                    }
                    AllDraw.LastRowQ = -1;
                    AllDraw.LastColumnQ = -1;
                    AllDraw.NextRowQ = -1;
                    AllDraw.NextColumnQ = -1;

                }

                if (AllDraw.QuntumTable[0, (int)Row, (int)Column] != -1 && AllDraw.QuntumTable[1, (int)Row, (int)Column] != -1)
                {
                    LastRowQ = AllDraw.QuntumTable[0, (int)Row, (int)Column];
                    LastColumnQ = AllDraw.QuntumTable[1, (int)Row, (int)Column];
                    RingHalf = true;
                }
                else
                    if (IsQuntumMove)
                {
                    RingHalf = true;
                    if (AllDraw.LastRowQ != -1 && AllDraw.LastColumnQ != -1)
                    {
                        LastRowQ = AllDraw.LastRowQ;
                        LastColumnQ = AllDraw.LastColumnQ;
                        AllDraw.LastRowQ = -1;
                        AllDraw.LastColumnQ = -1;
                    }
                }

                lock (balancelockS)
                {
                    //Gray Color.
                    if (((int)Row >= 0) && ((int)Row < 8) && ((int)Column >= 0) && ((int)Column < 8))
                    {
                        //Gray Order.
                        if (Order == 1)
                        {
                            object O1 = new object();
                            lock (O1)
                            {    //Draw an Instant from File of Gray Soldeirs.
                                 //Draw a Gray Instatnt Minister Image on the Table.

                                g.DrawImage(Image.FromFile(AllDraw.ImagesSubRoot + "MG.png"), new Rectangle((int)(Row * CellW), (int)(Column * CellH), CellW, CellH));
                                if (RingHalf)
                                {
                                    float Prob = 180;
                                    if (AllDraw.Less != 0)
                                    {
                                        Prob = (float)(180 * (AllDraw.Less / double.MaxValue));
                                    }

                                    g.DrawArc(new Pen(new SolidBrush(Color.Red)), new Rectangle((int)((Row * CellW)), (int)(Column * CellH), CellW, CellH), -45, Prob);
                                    if (LastRowQ != -1 && LastColumnQ != -1)
                                    {
                                        g.DrawImage(Image.FromFile(AllDraw.ImagesSubRoot + "MG.png"), new Rectangle(LastRowQ * CellW, LastColumnQ * CellH, CellW, CellH));
                                        g.DrawArc(new Pen(new SolidBrush(Color.Red)), new Rectangle((LastRowQ * CellW), (int)(LastColumnQ * (float)CellH), CellW, CellH), -45, Prob);
                                        AllDraw.QuntumTable[0, (int)Row, (int)Column] = LastRowQ;
                                        AllDraw.QuntumTable[1, (int)Row, (int)Column] = LastColumnQ;
                                        AllDraw.QuntumTable[0, LastRowQ, LastColumnQ] = -1;
                                        AllDraw.QuntumTable[1, LastRowQ, LastColumnQ] = -1;
                                    }
                                    else
                if (AllDraw.QuntumTable[0, (int)Row, (int)Column] != -1 && AllDraw.QuntumTable[1, (int)Row, (int)Column] != -1)
                                    {
                                        g.DrawImage(Image.FromFile(AllDraw.ImagesSubRoot + "MG.png"), new Rectangle(AllDraw.QuntumTable[0, (int)Row, (int)Column] * CellW, AllDraw.QuntumTable[1, (int)Row, (int)Column] * CellH, CellW, CellH));
                                        g.DrawArc(new Pen(new SolidBrush(Color.Red)), new Rectangle((AllDraw.QuntumTable[0, (int)Row, (int)Column] * CellW), (int)(AllDraw.QuntumTable[1, (int)Row, (int)Column] * (float)CellH), CellW, CellH), -45, Prob);

                                    }
                                }
                                else
                                {
                                    g.DrawArc(new Pen(new SolidBrush(Color.Red)), new Rectangle((int)((Row * CellW)), (int)(Column * CellH), CellW, CellH), -45, 360);
                                }
                            }
                        }
                        else
                        {
                            object O1 = new object();
                            lock (O1)
                            {

                                g.DrawImage(Image.FromFile(AllDraw.ImagesSubRoot + "MB.png"), new Rectangle((int)(Row * CellW), (int)(Column * CellH), CellW, CellH));
                                if (RingHalf)
                                {
                                    float Prob = 180;
                                    if (AllDraw.Less != 0)
                                    {
                                        Prob = (float)(180 * (AllDraw.Less / double.MaxValue));
                                    }

                                    g.DrawArc(new Pen(new SolidBrush(Color.Red)), new Rectangle((int)((Row * CellW)), (int)(Column * CellH), CellW, CellH), -45, Prob);
                                    if (LastRowQ != -1 && LastColumnQ != -1)
                                    {
                                        g.DrawImage(Image.FromFile(AllDraw.ImagesSubRoot + "MB.png"), new Rectangle(LastRowQ * CellW, LastColumnQ * CellH, CellW, CellH));
                                        g.DrawArc(new Pen(new SolidBrush(Color.Red)), new Rectangle((LastRowQ * CellW), (int)(LastColumnQ * (float)CellH), CellW, CellH), -45, Prob);
                                        AllDraw.QuntumTable[0, (int)Row, (int)Column] = LastRowQ;
                                        AllDraw.QuntumTable[1, (int)Row, (int)Column] = LastColumnQ;
                                        AllDraw.QuntumTable[0, LastRowQ, LastColumnQ] = -1;
                                        AllDraw.QuntumTable[1, LastRowQ, LastColumnQ] = -1;
                                    }
                                    else
                                    if (AllDraw.QuntumTable[0, (int)Row, (int)Column] != -1 && AllDraw.QuntumTable[1, (int)Row, (int)Column] != -1)
                                    {
                                        g.DrawImage(Image.FromFile(AllDraw.ImagesSubRoot + "MB.png"), new Rectangle(AllDraw.QuntumTable[0, (int)Row, (int)Column] * CellW, AllDraw.QuntumTable[1, (int)Row, (int)Column] * CellH, CellW, CellH));
                                        g.DrawArc(new Pen(new SolidBrush(Color.Red)), new Rectangle((AllDraw.QuntumTable[0, (int)Row, (int)Column] * CellW), (int)(AllDraw.QuntumTable[1, (int)Row, (int)Column] * (float)CellH), CellW, CellH), -45, Prob);

                                    }
                                }
                                else
                                {
                                    g.DrawArc(new Pen(new SolidBrush(Color.Red)), new Rectangle((int)((Row * CellW)), (int)(Column * CellH), CellW, CellH), -45, 360);
                                }
                            }
                        }
                    }
                }

            }
        }
    }
}

//End of Documentation.
