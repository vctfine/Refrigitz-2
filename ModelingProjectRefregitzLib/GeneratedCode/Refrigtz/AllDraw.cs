﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Refrigtz
{
	using RefrigtzAll;
	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;

	public class AllDraw
	{
		public List<AllDraw> ADraw;

		private ChessPerdict APredict;

		public static bool AStarGreadyFirstSearch;

		public int AStarGreedy;

		private IEnumerable<int> AStarGreedyIndex;

		private int AStarGreedyIndexVlue;

		public static int AStarGreedyiLevelMax;

		public static Double AStarGreedytMaxCount;

		public static int BridgeHigh;

		public static int BridgeMidle;

		public static int BridgeMovments;

		public static int BridgeValue;

		public bool BridgesKing;

		public IEnumerable<DrawBridge> BridgesOnTable;

		private int CL;

		private int CL1;

		private int CL2;

		private int CL3;

		private int CL4;

		private int CL5;

		private int CL6;

		private static List<int> ClList;

		public static Double CurrentHuristic;

		public IEnumerable<int> CurrentTable;

		public static bool DrawTable;

		public static bool DynamicAStarGreedytPrograming;

		public static int ElefantHigh;

		public static int ElefantMidle;

		public static int ElefantMovments;

		public static int ElefantValue;

		public IEnumerable<DrawElefant> ElephantOnTable;

		public static bool FoundATable;

		public static int HourseHight;

		public static int HourseMidle;

		public static int HourseMovments;

		public static int HourseValue;

		public IEnumerable<DrawHourse> HoursesOnTable;

		private int Hureturn;

		public static string ImageRoot;

		public static string ImagesSubRoot;

		private int Ki;

		private int Ki1;

		private int Ki2;

		private int Ki3;

		private int Ki4;

		private int Ki5;

		private int Ki6;

		private static List<int> KiList;

		public static int KingHigh;

		public static int KingMidle;

		public static int KingMovments;

		public IEnumerable<DrawKing> KingOnTable;

		public static int KingValue;

		public static Double Less;

		private static int LevelAStarGreedyFirsDynamic;

		public static int LoopHuristicIndex;

		public static int MaxAStarGreedy;

		private static object MaxBridgesFounded;

		private static object MaxElephntFounded;

		private static object MaxHourseFounded;

		private List<Double> MaxHuristicAStarGreedytBackWard;

		private List<int> MaxHuristicAStarGreedytBackWardTable;

		private static object MaxKingFounded;

		private Double MaxLess1;

		private Double MaxLess2;

		private Double MaxLess3;

		private Double MaxLess4;

		private Double MaxLess5;

		private Double MaxLess6;

		private static object MaxMinisterFounded;

		private static object MaxSoldeirFounded;

		public static int MinisterHigh;

		public static int MinisterMidle;

		public static int MinisterMovments;

		public IEnumerable<DrawMinister> MinisterOnTable;

		public static int MinisterValue;

		public static int MouseClick;

		public int Move;

		public static bool NoTableFound;

		private int RW;

		private int RW1;

		private int RW2;

		private int RW3;

		private int RW4;

		private int RW5;

		private int RW6;

		private static List<int> RWList;

		public static bool RedrawTable;

		public static int SignAchmaz;

		public static int SignAttack;

		public static int SignHitting;

		public static int SignMovments;

		public static int SignReducedAttacked;

		public static int SignSupport;

		public static bool SodierConversionOcuured;

		public static int SodierHigh;

		public static int SodierMidle;

		public static int SodierMovments;

		public static int SodierValue;

		public IEnumerable<DrawSoldier> SolderesOnTable;

		public static List<AllDraw> StoreADraw;

		public static List<int> StoreADrawAStarGreedy;

		public static string SyntaxToWrite;

		public FormRefrigtz THIS;

		public static List<int> TableCurrent;

		public static IEnumerable<int> TableHuristic;

		public List<int> TableList;

		public static List<int> TableListAction;

		public static IEnumerable<int> TableVeryfy;

		public static IEnumerable<int> TableVeryfyConst;

		private bool ThinkingFinished;

		private bool ToFindMovments;

		public static bool UseDoubleTime;

		public static int increasedProgress;

		private static void Log(Exception ex)
		{
			throw new System.NotImplementedException();
		}

		public AllDraw(ref FormRefrigtz th)
		{
		}

		public AllDraw(AllDraw THi)
		{
		}

		public virtual void Clone(AllDraw AA)
		{
			throw new System.NotImplementedException();
		}

		public virtual bool AllCurrentAStarGreedyThinkingFinished(AllDraw Dum, int i, int j, int Kind)
		{
			throw new System.NotImplementedException();
		}

		public virtual void BeginIndexFoundingMaxLessofMaxList(int ListIndex, List<Double> Founded, ref Double Less)
		{
			throw new System.NotImplementedException();
		}

		public virtual AllDraw CopyRemeiningItems(AllDraw ADummy, int Order)
		{
			throw new System.NotImplementedException();
		}

		private List<List<Double>> FoundOfBestMovments(int AStarGreedy, ref List<Double> i, ref List<Double> j, ref List<Double> k, AllDraw Dummy, Color a, int Order)
		{
			throw new System.NotImplementedException();
		}

		public virtual IEnumerable<int> Huristic(List<AllDraw> A, Color a, int ij, ref Double Less, int Order)
		{
			throw new System.NotImplementedException();
		}

		public virtual IEnumerable<int> HuristicAStarGreedySearch(int AStarGreedyi, List<AllDraw> A, Color a, ref Double Less, int Order, bool CurrentTableHuristic)
		{
			throw new System.NotImplementedException();
		}

		public virtual IEnumerable<int> HuristicCurrentTable(AllDraw ADra, Color a, int Order)
		{
			throw new System.NotImplementedException();
		}

		private void IncreaseprogressBarRefregitzValue(ProgressBar Refregitz, int value)
		{
			throw new System.NotImplementedException();
		}

		public virtual void Initiate(int ii, int jj, Color a, IEnumerable<int> Table, int Order, bool TB, ref Timer timer, ref Timer TimerColor)
		{
			throw new System.NotImplementedException();
		}

		public virtual AllDraw InitiateAStarGreedyt(int iAStarGreedy, int ii, int jj, Color a, IEnumerable<int> Table, int Order, bool TB, ref Timer timer, ref Timer TimerColor, ref Double Less)
		{
			throw new System.NotImplementedException();
		}

		public virtual void InitiateForEveryKindThingHome(AllDraw DummyHA, int ii, int jj, Color a, IEnumerable<int> Table, int Order, bool TB, int IN)
		{
			throw new System.NotImplementedException();
		}

		public virtual void InitiateGenetic(int ii, int jj, Color a, IEnumerable<int> Table, int Order, bool TB)
		{
			throw new System.NotImplementedException();
		}

		private void IsPenaltyRegardMateAtBranch(int Order, ref int Do, AllDraw Base)
		{
			throw new System.NotImplementedException();
		}

		private bool IsToMateHasLessDeeperThanForMate(AllDraw A, int Order, ref int ToMate, ref int ForMate, int AStarGreedy)
		{
			throw new System.NotImplementedException();
		}

		public virtual void MakePenaltyAllMateBranches(AllDraw A, int Order)
		{
			throw new System.NotImplementedException();
		}

		public virtual void MakeRegardAllMateBranches(AllDraw A, int Order)
		{
			throw new System.NotImplementedException();
		}

		private int MaxOfThreeHuristic(Double _1, Double _2, Double _3, Double _4, Double _5, Double _6)
		{
			throw new System.NotImplementedException();
		}

		public virtual void RecoonstructADraw(ref List<AllDraw> ADrawAll)
		{
			throw new System.NotImplementedException();
		}

		public virtual void RemovePenalltyFromFirstBranches(AllDraw A)
		{
			throw new System.NotImplementedException();
		}

		public virtual void SetRowColumn(int index)
		{
			throw new System.NotImplementedException();
		}

		private void SetprogressBarRefregitzValue(ProgressBar Refregitz, int value)
		{
			throw new System.NotImplementedException();
		}

		private void SetprogressBarUpdate(ProgressBar Refregitz)
		{
			throw new System.NotImplementedException();
		}

		private void Wait(AllDraw Dum, int i, int j, int k, int Kind, bool AStarGreedy)
		{
			throw new System.NotImplementedException();
		}

		public virtual bool isEnemyThingsinStable(IEnumerable<int> TableHuristic, IEnumerable<int> TableAction, int Order)
		{
			throw new System.NotImplementedException();
		}

	}
}

