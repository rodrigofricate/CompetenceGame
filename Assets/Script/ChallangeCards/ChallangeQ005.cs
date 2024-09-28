using Assets.Script.Interfaces;
using System;


namespace Assets.Script.ChallangeCards
{
    public class ChallangeQ005 : IChallangeCard
    {
        string challangeQuestion = "Preciso conhecer as necessidades do meu público-alvo para desenvolver uma nova solução. Como posso levantar essas informações?";
        public string GetChallangeQuestion() { return challangeQuestion; }
    }
}
