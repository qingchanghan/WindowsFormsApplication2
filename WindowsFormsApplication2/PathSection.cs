using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class PathSection
    {
        public LinkedList<Station> list = new LinkedList<Station>();
        public string LineName;
        public bool isTrans = true;
        public Station from;
        public Station to;

        public PathSection(string s)
        {
            LineName = s;

        }
        public override string ToString()
        {
            string s = null;
            if (isTrans)
                s += "\n换乘" + LineName;//添加格式修改
            foreach (Station sta in list)
            {
                s += "\n" + sta;
            }
            return s;
        }
        public void addSta(Station s)
        {
            if (list.Count == 0)
                from = s;
            list.AddLast(s);
            to = s;

        }
        public int GetLen()
        {
            return list.Count();
        }
        public void copy(PathSection p)
        {
            list.Clear();
            foreach (Station s in p.list)
            {
                list.AddLast(s);
            }
            LineName = p.LineName;
            isTrans = p.isTrans;
            from = p.from;
            to = p.to;
        }
    }
}
