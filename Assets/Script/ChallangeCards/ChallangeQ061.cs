using Assets.Script.Interfaces;



namespace Assets.Script.ChallangeCards
{
    public class ChallangeQ061 : IChallangeCard
    {
        string challangeQuestion = "Preciso garantir um bom design no desenvolvimento de um produto ou o que vale é o conteúdo?";

        public string GetChallangeQuestion() { return challangeQuestion; }
    }
}
