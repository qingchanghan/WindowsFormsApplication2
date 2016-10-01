using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class Station
    {
        public string StationName;
        public Dictionary<Line, int> PlaceOfLine = new Dictionary<Line, int>();
        public bool isTrans;
        public int TransLineCount;
        public List<string> TransLine = new List<string>();
        public bool isBoundary = false;
        public List<string> EndStas = new List<string>();
        private int TransStaNo;
        public int ID;
        public Tuple<int, int> position;

        public Station(string[] infos, Line l)
        {
            ID = Convert.ToInt32(infos[0]);
            position = Tuple.Create(Convert.ToInt32(infos[1]), Convert.ToInt32(infos[2]));
            StationName = infos[3];
            int pointer = 4;
            if (infos.Length > 4)
            {
                if (infos[4].Equals("IsBound"))
                {
                    isBoundary = true;
                    if (!EndStas.Contains(infos[5]))
                        EndStas.Add(infos[5]);
                    pointer = 6;
                }
            }
            if (infos.Length > pointer)
            {
                for (int i = pointer; i < infos.Length; i++)
                {
                    TransLine.Add(infos[i]);
                }
                TransLine.Add(l.LineName);
                TransLineCount = infos.Length - pointer + 1;
                isTrans = true;
            }
            PlaceOfLine.Add(l, l.getStaCount() + 1);
        }

        public void addLine(Line l)
        {
            if (!PlaceOfLine.ContainsKey(l))
                PlaceOfLine.Add(l, l.getStaCount() + 1);
        }
        public void setTransStaNo(int i)
        {
            if (isTrans)
                TransStaNo = i;
        }
        public int getTransStaNo()
        {
            return TransStaNo;
        }
        public override string ToString()
        {
            return StationName.ToString();
        }
        public void addEndSta(string[] infos)
        {
            if (infos[1].Equals("IsBound"))
            {
                isBoundary = true;
                if (!EndStas.Contains(infos[2]))
                    EndStas.Add(infos[2]);
            }
        }
    }
}
