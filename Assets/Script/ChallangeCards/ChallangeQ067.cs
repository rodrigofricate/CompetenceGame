using Assets.Script.Interfaces;



namespace Assets.Script.ChallangeCards
{
    public class ChallangeQ067 : IChallangeCard
    {
        string challangeQuestion = "O que é mais importante: seguir um planejamento inicial ou se adaptar e garantir o valor agregado ao cliente?";

        public string GetChallangeQuestion() { return challangeQuestion; }
    }
}
