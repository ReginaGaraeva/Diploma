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
			List<string> result = new List<string>();
			StreamReader sr = new StreamReader(filename);
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
			List<string[]> result = new List<string[]>();
			StreamReader sr = new StreamReader(filename);
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
			List<PipeData> result = new List<PipeData>();
			StreamReader sr = new StreamReader(filename);
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
}
