using Assets.Script.Interfaces;
using System;


namespace Assets.Script.ChallangeCards
{
    public class ChallangeQ009 : IChallangeCard
    {
        string challangeQuestion = "A minha área disponibiliza um canal para atendimento digital aos clientes, mas eles preferem fazer contato via telefone. " +
            "Como posso incentivar o uso do canal digital?";

        public string GetChallangeQuestion() { return challangeQuestion; }
    }
}
