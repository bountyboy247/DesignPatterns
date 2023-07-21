using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.DSAs.DPs.Bitmaskings {
    public class SufficientTeam {
        public SufficientTeam() {
            string[] rs = new string[] {
               "algorithms","math","java","reactjs","csharp","aws"
            };
            IList<IList<string>> list = new List<IList<string>>() {
                new List<string>(){"algorithms","math","java"},
                new List<string>(){"algorithms","math","reactjs"},
                new List<string>(){ "java", "csharp", "aws" },
                new List<string>(){"reactjs","csharp"},
                new List<string>(){"csharp","math"},
                new List<string>(){ "aws", "java" }
            };
            int[] ans = SmallestSufficientTeam(rs,list);
        }
        public int[] SmallestSufficientTeam(string[] req_skills, IList<IList<string>> people) {
            Dictionary<string,int> map = new Dictionary<string,int>();
            for(int i = 0; i < req_skills.Length; i++) {
                map.Add(req_skills[i], i);
            }
            int masking = (1 << req_skills.Length) - 1;

            return null;
        }

    }
}
