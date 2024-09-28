using Assets.Script.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Interfaces
{
    public interface ICompetenceCard
    {
        public string GetNumber();
        public string GetTitle();
        public EnumCompetenceAnsware GetRigthAnsware();
    }
}
