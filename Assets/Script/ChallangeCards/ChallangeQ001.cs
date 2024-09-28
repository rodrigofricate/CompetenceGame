using Assets.Script.Interfaces;
using System;


namespace Assets.Script.ChallangeCards
{
    public class ChallangeQ001 : IChallangeCard
    {
        string challangeQuestion = "A produção acabou e o cliente está chateado pela demora na entrega. O que deve ser feito nessa situação?";
        public string GetChallangeQuestion() { return challangeQuestion; }
    }
}
