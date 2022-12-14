using System;
using System.Diagnostics;
using System.IO;

namespace ChessFirst
{
    [Serializable]
    public class TakeRoot
    {
        //bool WaitOnplay = false;

        private readonly string path3 = @"temp";
        private string AllDrawReplacement = "";

        public static int AllDrawKind = 0;//0,1,2,3,4,5,6
        public static string AllDrawKindString = "";

        public AllDraw t = null;

        //public QuantumRefrigiz.AllDraw tt = null;

        private static void Log(Exception ex)
        {
            try
            {
                object a = new object();
                lock (a)
                {
                    string stackTrace = ex.ToString();
                    File.AppendAllText(ChessFirstForm.Root + "\\ErrorProgramRun.txt", stackTrace + ": On" + DateTime.Now.ToString()); // path of file where stack trace will be stored.
                }
            }
            catch (Exception t) { Log(t); }
        }

        private void SetAllDrawKindString()
        {
            object O = new object();
            lock (O)
            {
                if (AllDrawKind == 4)
                {
                    AllDrawKindString = "F_AllDrawBT.asd";
                }
                else
                if (AllDrawKind == 3)
                {
                    AllDrawKindString = "F_AllDrawFFST.asd";
                }
                else
                if (AllDrawKind == 2)
                {
                    AllDrawKindString = "F_AllDrawFTSF.asd";
                }
                else
                if (AllDrawKind == 1)
                {
                    AllDrawKindString = "F_AllDrawFFSF.asd";
                }
            }
        }

        private void SetAllDrawKind(bool UsePenaltyRegardMechnisam, bool AStarGreedyHeuristic)
        {
            object OO = new object();
            lock (OO)
            {
                if (UsePenaltyRegardMechnisam && AStarGreedyHeuristic)
                {
                    AllDrawKind = 4;
                }
                else
          if ((!UsePenaltyRegardMechnisam) && AStarGreedyHeuristic)
                {
                    AllDrawKind = 3;
                }

                if (UsePenaltyRegardMechnisam && (!AStarGreedyHeuristic))
                {
                    AllDrawKind = 2;
                }

                if ((!UsePenaltyRegardMechnisam) && (!AStarGreedyHeuristic))
                {
                    AllDrawKind = 1;
                }
            }
        }

        private bool DrawManagement(bool FOUND, bool UsePenaltyRegardMechnisam, bool AStarGreedyHeuristic)
        {
            object OO = new object();
            lock (OO)
            {
                SetAllDrawKind(UsePenaltyRegardMechnisam, AStarGreedyHeuristic);

                //Set Configuration To True for some unknown reason!.
                //UpdateConfigurationTableVal = true;                             
                SetAllDrawKindString();


                bool Found = false;
                string P = Path.GetFullPath(path3);
                AllDrawReplacement = Path.Combine(P, AllDrawKindString);

                Logger y = new Logger(AllDrawReplacement);
                //y.Dispose();

                y = new Logger(AllDrawKindString);
                //y.Dispose();

                if (File.Exists(AllDrawReplacement))
                {
                    if (AllDraw.HarasAct)
                    {
                        File.Delete(AllDrawReplacement);
                    }
                }
                if (File.Exists(AllDrawKindString))
                {
                    if (AllDraw.HarasAct)
                    {
                        File.Delete(AllDrawKindString);
                    }
                }
                AllDraw.HarasAct = false;
                if (File.Exists(AllDrawKindString))
                {

                    if (File.Exists(AllDrawReplacement))
                    {
                        if (((new System.IO.FileInfo(AllDrawKindString).Length) < (new System.IO.FileInfo(AllDrawReplacement)).Length))
                        {
                            File.Delete(AllDrawKindString);
                            File.Copy(AllDrawReplacement, AllDrawKindString);
                            Found = true;
                        }
                        else if (((new System.IO.FileInfo(AllDrawKindString).Length) > (new System.IO.FileInfo(AllDrawReplacement)).Length))
                        {
                            if (File.Exists(AllDrawReplacement))
                            {
                                File.Delete(AllDrawReplacement);
                            }

                            File.Copy(AllDrawKindString, AllDrawReplacement);
                            Found = true;
                        }
                    }
                    else
                    {
                        if (!Directory.Exists(Path.GetFullPath(path3)))
                        {
                            Directory.CreateDirectory(Path.GetFullPath(path3));
                        }

                        File.Copy(AllDrawKindString, AllDrawReplacement);
                        Found = true;

                    }
                    Found = true;
                }
                else if (File.Exists(AllDrawReplacement))
                {
                    File.Copy(AllDrawReplacement, AllDrawKindString);
                    Found = true;
                }

                return Found;
            }
        }
        public bool LoadJungle(string path, bool FOUND, bool Quantum, ChessFirstForm Curent, ref bool LoadTree, bool MovementsAStarGreedyHeuristicFound, bool IInoreSelfObjects, bool UsePenaltyRegardMechnisam, bool BestMovments, bool PredictHeuristic, bool OnlySelf, bool AStarGreedyHeuristic, bool ArrangmentsChanged)
        {
            object OO = new object();
            lock (OO)
            {
                bool DrawDrawen = false;
                //Load Middle Targets.
                try
                {
                    ChessFirstForm.AllDrawKindString = path;

                    if (File.Exists(ChessFirstForm.AllDrawKindString))
                    {
                        if (ChessFirstForm.MovmentsNumber >= 0)
                        {
                            //if (!Quantum)
                            {
                                RefregizMemmory tr = new RefregizMemmory(MovementsAStarGreedyHeuristicFound, IInoreSelfObjects, UsePenaltyRegardMechnisam, BestMovments, PredictHeuristic, OnlySelf, AStarGreedyHeuristic, ArrangmentsChanged);
                                t = tr.LoadJungle(path, Quantum, ChessFirstForm.OrderPlate);
                                if (t != null)
                                {
                                    Curent.Draw = t;

                                    LoadTree = true;
                                    Curent.Draw = Curent.RootFound();

                                    //Curent.Draw.UpdateLoseAndWinDepenOfKind(Curent.Draw.OrderP);


                                    t = Curent.Draw;
                                    //Curent.SetDrawFounding(ref FOUND, ref THIS, false);
                                    DrawDrawen = true;

                                    System.Windows.Forms.MessageBox.Show("Load Completed.");
                                }
                            }
                            /*else
                            {
                                RefregizMemmory tr = new RefregizMemmory(MovementsAStarGreedyHeuristicFound, IInoreSelfObjects, UsePenaltyRegardMechnisam, BestMovments, PredictHeuristic, OnlySelf, AStarGreedyHeuristic, ArrangmentsChanged);
                               tt =(QuantumRefrigiz.AllDraw) tr.LoadQ(Quantum, ChessFirstForm.OrderPlate);
                                if (t != null)
                                {

                                    Curent.DrawQ = tt;

                                    LoadTree = true;


                                    Curent.DrawQ = Curent.RootFoundQ();

                                    tt = Curent.DrawQ;

                                    DrawDrawen = true;

                                    System.Windows.Forms.MessageBox.Show("Load Completed.");
                                }
                            }*/
                        }
                        File.Delete(ChessFirstForm.AllDrawKindString);
                    }
                }
                catch (Exception t) { Log(t); }
                //System.Threading.Thread ttt = new System.Threading.Thread(new System.Threading.ThreadStart(Wait));
                //ttt.Start();
                //ttt.Join();

                return DrawDrawen;
            }
        }


        public bool Load(bool FOUND, bool Quantum, ChessFirstForm Curent, ref bool LoadTree, bool MovementsAStarGreedyHeuristicFound, bool IInoreSelfObjects, bool UsePenaltyRegardMechnisam, bool BestMovments, bool PredictHeuristic, bool OnlySelf, bool AStarGreedyHeuristic, bool ArrangmentsChanged)
        {
            object OO = new object();
            lock (OO)
            {
                DrawManagement(FOUND, UsePenaltyRegardMechnisam, AStarGreedyHeuristic);

                bool DrawDrawen = false;
                //Load Middle Targets.
                try
                {
                    if (File.Exists(ChessFirstForm.AllDrawKindString))
                    {
                        if (ChessFirstForm.MovmentsNumber >= 0)
                        {
                            //if (!Quantum)
                            {
                                RefregizMemmory tr = new RefregizMemmory(MovementsAStarGreedyHeuristicFound, IInoreSelfObjects, UsePenaltyRegardMechnisam, BestMovments, PredictHeuristic, OnlySelf, AStarGreedyHeuristic, ArrangmentsChanged);
                                t = tr.Load(Quantum, ChessFirstForm.OrderPlate);
                                if (t != null)
                                {
                                    Curent.Draw = t;

                                    LoadTree = true;
                                    Curent.Draw = Curent.RootFound();

                                    //Curent.Draw.UpdateLoseAndWinDepenOfKind(Curent.Draw.OrderP);


                                    t = Curent.Draw;
                                    //Curent.SetDrawFounding(ref FOUND, ref THIS, false);
                                    DrawDrawen = true;

                                    System.Windows.Forms.MessageBox.Show("Load Completed.");
                                }
                            }
                            /*else
                            {
                                RefregizMemmory tr = new RefregizMemmory(MovementsAStarGreedyHeuristicFound, IInoreSelfObjects, UsePenaltyRegardMechnisam, BestMovments, PredictHeuristic, OnlySelf, AStarGreedyHeuristic, ArrangmentsChanged);
                               tt =(QuantumRefrigiz.AllDraw) tr.LoadQ(Quantum, ChessFirstForm.OrderPlate);
                                if (t != null)
                                {

                                    Curent.DrawQ = tt;

                                    LoadTree = true;


                                    Curent.DrawQ = Curent.RootFoundQ();

                                    tt = Curent.DrawQ;

                                    DrawDrawen = true;

                                    System.Windows.Forms.MessageBox.Show("Load Completed.");
                                }
                            }*/
                        }
                        File.Delete(ChessFirstForm.AllDrawKindString);
                    }
                }
                catch (Exception t) { Log(t); }
                //System.Threading.Thread ttt = new System.Threading.Thread(new System.Threading.ThreadStart(Wait));
                //ttt.Start();
                //ttt.Join();

                return DrawDrawen;
            }
        }

        private void Wait()
        {
            object O = new object();
            lock (O)
            {
                PerformanceCounter myAppCpu =
                    new PerformanceCounter(
                        "Process", "% Processor Time", Process.GetCurrentProcess().ProcessName, true);


                ///do { WaitOnplay = true; } while (myAppCpu.NextValue() != 0);

                //WaitOnplay = false;
            }
        }

        public bool Save(bool FOUND, bool Quantum, ChessFirstForm Curent, ref bool LoadTree, bool MovementsAStarGreedyHeuristicFound, bool IInoreSelfObjects, bool UsePenaltyRegardMechnisam, bool BestMovments, bool PredictHeuristic, bool OnlySelf, bool AStarGreedyHeuristic, bool ArrangmentsChanged)
        {
            object OO = new object();
            lock (OO)
            {
                object o = new object();
                lock (o)
                {

                    if (!AllDraw.ChangedInTreeOccured)
                    {
                        return true;
                    }
                }
                //System.Threading.Thread ttt = new System.Threading.Thread(new System.Threading.ThreadStart(Wait));
                //ttt.Start();
                //ttt.Join();

                /*if (!Quantum)
                {
                    while (Curent.Draw.AStarGreedyString != null)
                        Curent.Draw = Curent.Draw.AStarGreedyString;
                }
                else
                {
                    while (Curent.DrawQ.AStarGreedyString != null)
                        Curent.DrawQ = Curent.DrawQ.AStarGreedyString;
                }
               if (UsePenaltyRegardMechnisam && AStarGreedyHeuristic)
                    AllDrawKind = 4;
                else
                                                     if ((!UsePenaltyRegardMechnisam) && AStarGreedyHeuristic)
                    AllDrawKind = 3;
                if (UsePenaltyRegardMechnisam && (!AStarGreedyHeuristic))
                    AllDrawKind = 2;
                if ((!UsePenaltyRegardMechnisam) && (!AStarGreedyHeuristic))
                    AllDrawKind = 1;
                //Set Configuration To True for some unknown reason!.
                //UpdateConfigurationTableVal = true;                             
                SetAllDrawKindString();
                */
                try
                {


                    AllDraw Stote = Curent.Draw;
                    if (!File.Exists(AllDrawKindString))
                    {
                        RefregizMemmory rt = new RefregizMemmory(MovementsAStarGreedyHeuristicFound, IInoreSelfObjects, UsePenaltyRegardMechnisam, BestMovments, PredictHeuristic, OnlySelf, AStarGreedyHeuristic, ArrangmentsChanged
                           );
                        //if (!Quantum)
                        {
                            if (Curent.Draw != null)
                            {
                                Curent.Draw = Curent.RootFound();
                                rt.AllDrawCurrentAccess = Curent.Draw;
                                rt.RewriteAllDraw(ChessFirstForm.OrderPlate);
                                AllDraw.DrawTable = false;
                                //.SetBoxText("\r\nSaved Completed.");
                                //Curent.RefreshBoxText();
                                //PictureBoxSendToBack();
                                //PictureBoxTimerGray.SendToBack();
                                //PictureBoxTimerBrown.SendToBack();
                                //MessageBox.Show("Saved Completed.");
                            }
                        }
                        /*else {
                            if (Curent.DrawQ != null)
                            {
                                Curent.DrawQ = Curent.RootFoundQ();
                                rt.AllDrawCurrentAccessQ = Curent.DrawQ;
                                rt.RewriteAllDrawQ(ChessFirstForm.OrderPlate);
                                QuantumRefrigiz.AllDraw.DrawTable = false;
    //Curent.SetBoxText("\r\nSaved Completed.");
                            //    Curent.RefreshBoxText();
                                //PictureBoxSendToBack();
                                //PictureBoxTimerGray.SendToBack();
                                //PictureBoxTimerBrown.SendToBack();
                                //MessageBox.Show("Saved Completed.");
                            }
                        */
                    }
                    else
                          if (File.Exists(AllDrawKindString))
                    {
                        //DrawManagement(FOUND, UsePenaltyRegardMechnisam, AStarGreedyHeuristic);
                        Again:
                        try
                        {
                            File.Delete(ChessFirstForm.AllDrawKindString);
                        }catch(Exception t)
                        {
                            System.Threading.Thread.Sleep(100);
                            goto Again;
                        }
                        RefregizMemmory rt = new RefregizMemmory(MovementsAStarGreedyHeuristicFound, IInoreSelfObjects, UsePenaltyRegardMechnisam, BestMovments, PredictHeuristic, OnlySelf, AStarGreedyHeuristic, ArrangmentsChanged
                            );
                        //"Universal Root Founding";
                        if (Curent.Draw != null)
                        {
                            Curent.Draw = Curent.RootFound();
                            rt.AllDrawCurrentAccess = Curent.Draw;
                            rt.RewriteAllDraw(ChessFirstForm.OrderPlate);
                            AllDraw.DrawTable = false;
                            // Curent.SetBoxText("\r\nSaved Completed.");
                            // Curent.RefreshBoxText();
                            //PictureBoxSendToBack();
                            //PictureBoxTimerGray.SendToBack();
                            //PictureBoxTimerBrown.SendToBack();
                            //MessageBox.Show("Saved Completed.");
                        }
                        //DrawManagement(FOUND, UsePenaltyRegardMechnisam, AStarGreedyHeuristic);

                    }
                    Curent.Draw = Stote;
                    return true;
#pragma warning disable CS0162 // Unreachable code detected
                    return true;
#pragma warning restore CS0162 // Unreachable code detected
                }
                catch (Exception t)
                {
                    Log(t);
                    return false;
                }
            }
        }
        public bool SaveJungle(bool FOUND, bool Quantum, ChessFirstForm Curent, ref bool LoadTree, bool MovementsAStarGreedyHeuristicFound, bool IInoreSelfObjects, bool UsePenaltyRegardMechnisam, bool BestMovments, bool PredictHeuristic, bool OnlySelf, bool AStarGreedyHeuristic, bool ArrangmentsChanged)
        {
            object OO = new object();
            lock (OO)
            {
                object o = new object();
                lock (o)
                {


                }
                //System.Threading.Thread ttt = new System.Threading.Thread(new System.Threading.ThreadStart(Wait));
                //ttt.Start();
                //ttt.Join();

                /*if (!Quantum)
                {
                    while (Curent.Draw.AStarGreedyString != null)
                        Curent.Draw = Curent.Draw.AStarGreedyString;
                }
                else
                {
                    while (Curent.DrawQ.AStarGreedyString != null)
                        Curent.DrawQ = Curent.DrawQ.AStarGreedyString;
                }
               if (UsePenaltyRegardMechnisam && AStarGreedyHeuristic)
                    AllDrawKind = 4;
                else
                                                     if ((!UsePenaltyRegardMechnisam) && AStarGreedyHeuristic)
                    AllDrawKind = 3;
                if (UsePenaltyRegardMechnisam && (!AStarGreedyHeuristic))
                    AllDrawKind = 2;
                if ((!UsePenaltyRegardMechnisam) && (!AStarGreedyHeuristic))
                    AllDrawKind = 1;
                //Set Configuration To True for some unknown reason!.
                //UpdateConfigurationTableVal = true;                             
                SetAllDrawKindString();
                */
                try
                {


                    AllDraw Stote = Curent.Draw;
                    if (!File.Exists(AllDrawKindString))
                    {
                        RefregizMemmory rt = new RefregizMemmory(MovementsAStarGreedyHeuristicFound, IInoreSelfObjects, UsePenaltyRegardMechnisam, BestMovments, PredictHeuristic, OnlySelf, AStarGreedyHeuristic, ArrangmentsChanged
                           );
                        //if (!Quantum)
                        {
                            if (Curent.Draw != null)
                            {
                                Curent.Draw = Curent.RootFound();
                                rt.AllDrawCurrentAccess = Curent.Draw;
                                rt.RewriteAllDraw(ChessFirstForm.OrderPlate);
                                AllDraw.DrawTable = false;
                                //.SetBoxText("\r\nSaved Completed.");
                                //Curent.RefreshBoxText();
                                //PictureBoxSendToBack();
                                //PictureBoxTimerGray.SendToBack();
                                //PictureBoxTimerBrown.SendToBack();
                                //MessageBox.Show("Saved Completed.");
                            }
                        }
                        /*else {
                            if (Curent.DrawQ != null)
                            {
                                Curent.DrawQ = Curent.RootFoundQ();
                                rt.AllDrawCurrentAccessQ = Curent.DrawQ;
                                rt.RewriteAllDrawQ(ChessFirstForm.OrderPlate);
                                QuantumRefrigiz.AllDraw.DrawTable = false;
    //Curent.SetBoxText("\r\nSaved Completed.");
                            //    Curent.RefreshBoxText();
                                //PictureBoxSendToBack();
                                //PictureBoxTimerGray.SendToBack();
                                //PictureBoxTimerBrown.SendToBack();
                                //MessageBox.Show("Saved Completed.");
                            }
                        */
                    }
                    else
                          if (File.Exists(AllDrawKindString))
                    {
                        //DrawManagement(FOUND, UsePenaltyRegardMechnisam, AStarGreedyHeuristic);

                        File.Delete(ChessFirstForm.AllDrawKindString);
                        RefregizMemmory rt = new RefregizMemmory(MovementsAStarGreedyHeuristicFound, IInoreSelfObjects, UsePenaltyRegardMechnisam, BestMovments, PredictHeuristic, OnlySelf, AStarGreedyHeuristic, ArrangmentsChanged
                            );
                        //"Universal Root Founding";
                        if (Curent.Draw != null)
                        {
                            Curent.Draw = Curent.RootFound();
                            rt.AllDrawCurrentAccess = Curent.Draw;
                            rt.RewriteAllDraw(ChessFirstForm.OrderPlate);
                            AllDraw.DrawTable = false;
                            // Curent.SetBoxText("\r\nSaved Completed.");
                            // Curent.RefreshBoxText();
                            //PictureBoxSendToBack();
                            //PictureBoxTimerGray.SendToBack();
                            //PictureBoxTimerBrown.SendToBack();
                            //MessageBox.Show("Saved Completed.");
                        }
                        //DrawManagement(FOUND, UsePenaltyRegardMechnisam, AStarGreedyHeuristic);

                    }
                    Curent.Draw = Stote;
                    return true;
#pragma warning disable CS0162 // Unreachable code detected
                    return true;
#pragma warning restore CS0162 // Unreachable code detected
                }
                catch (Exception t)
                {
                    Log(t);
                    return false;
                }
            }
        }
    }
}

