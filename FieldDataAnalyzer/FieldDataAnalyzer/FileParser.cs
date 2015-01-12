using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FieldDataAnalyzer
{
	class FileParser
	{

		public FileParser()
		{

		}

		public List<string> ParseGeneralData(string filename)
		{
			var result = new List<string>();
			var sr = new StreamReader(filename);
			string buf;
			while (!sr.EndOfStream)
			{
				buf = sr.ReadLine();
				if (buf != "")
					result.Add(buf.Split(new char[] { ' ', '\t' })[0]);
			}
			return result;
		}

		public List<string[]> ParseSchema(string filename)
		{
			var result = new List<string[]>();
			var sr = new StreamReader(filename);
			string[] buf;
			while (!sr.EndOfStream)
			{
				buf = sr.ReadLine().Split(new char[] {' ', '\t'});
				if (buf.Count() != 0)
					result.Add(new string[]{buf[0], buf[1]});
			}
			return result;
		}

		public List<PipeData> ParsePipes(string filename)
		{
			var result = new List<PipeData>();
			var sr = new StreamReader(filename);
			string[] buf;
			while (!sr.EndOfStream)
			{
				buf = sr.ReadLine().Split(new char[] { ' ', '\t' });
				if (buf.Count() != 0)
					result.Add(new PipeData()
					{
						Num = Convert.ToInt32(buf[0]),
						Length = Convert.ToDouble(buf[1]),
						OuterD = Convert.ToDouble(buf[2]),
						Width = Convert.ToDouble(buf[3]),
						InnerD = Convert.ToDouble(buf[4]),
						Roughness = Convert.ToDouble(buf[5]),
						StartNode = buf[6],
						EndNode = buf[7],
						OuterT = Convert.ToDouble(buf[8])
					});
			}
			return result;
		}

		public List<string[]> ParseWells(string filename)
		{
			var result = new List<string[]>();
			var sr = new StreamReader(filename);
			string[] buf;
			while (!sr.EndOfStream)
			{
				buf = sr.ReadLine().Split(new char[] { ' ', '\t' });
				if (buf.Count() != 0)
					result.Add(new string[] { buf[0], buf[1] });
			}
			return result;
		}

		public List<SkvData> ParseSkv(string filename)
		{
			var result = new List<SkvData>();
			var sr = new StreamReader(filename);
			string[] buf;
			while (!sr.EndOfStream)
			{
				buf = sr.ReadLine().Split(new char[] { ' ', '\t' });
				if (buf.Count() != 0)
					result.Add(new SkvData
					{
						Name = buf[0],
						Date = Convert.ToDateTime(buf[1]),
						G_gas = Convert.ToDouble(buf[2]),
						G_condensat = Convert.ToDouble(buf[3]),
						P_ust = Convert.ToDouble(buf[4]),
						T_ust = Convert.ToDouble(buf[5]),
						P_shl = Convert.ToDouble(buf[6]),
						T_sl = Convert.ToDouble(buf[7])
					});
			}
			return result;
		}

		public List<SborData> ParseSbor(string filename)
		{
			var result = new List<SborData>();
			var sr = new StreamReader(filename);
			string[] buf;
			while (!sr.EndOfStream)
			{
				buf = sr.ReadLine().Split(new char[] { ' ', '\t' });
				if (buf.Count() != 0)
					result.Add(new SborData
					{
						Date = Convert.ToDateTime(buf[0]),
						P = Convert.ToDouble(buf[1]),
						T = Convert.ToDouble(buf[2])
					});
			}
			return result;
		}
	}

	class PipeData
	{
		public int Num;
		public double Length;
		public double OuterD;
		public double Width;
		public double InnerD;
		public double Roughness;
		public string StartNode;
		public string EndNode;
		public double OuterT;
	}

	class SkvData
	{
		public string Name;
		public DateTime Date;
		public double G_gas;
		public double G_condensat;
		public double P_ust;
		public double T_ust;
		public double P_shl;
		public double T_sl;
	}

	class SborData
	{
		public DateTime Date;
		public double P;
		public double T;
	}
}
