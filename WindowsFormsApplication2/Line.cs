using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class Line
    {
        public string LineName;
        public List<Station> Stations = new List<Station>();
        public List<Tuple<string, Station>> TransStations = new List<Tuple<string, Station>>();
        public List<int> oneWayFlag = new List<int>();
        public bool isOneWay = false;
        public bool isRoundLine = false;
        private int LineTransSta = 0;


        public Line(string name)
        {
            LineName = name;
        }

        public int getStaCount()
        {
            return Stations.Count;
        }

        public void addSta(Station s, int flag)
        {
            Stations.Add(s);
            oneWayFlag.Add(flag);
            if (s.isTrans)
            {
                foreach (string lName in s.TransLine)
                {
                    if (!lName.Equals(LineName))
                        TransStations.Add(Tuple.Create(lName, s));
                }
                LineTransSta++;

            }
        }
        public int TransStaCount()
        {
            return LineTransSta;
        }

    }
}
