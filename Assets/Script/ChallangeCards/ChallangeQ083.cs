using Assets.Script.Interfaces;



namespace Assets.Script.ChallangeCards
{
    public class ChallangeQ083 : IChallangeCard
    {
        string challangeQuestion = "Cite um exemplo de como o uso de dados te ajudou a tomar uma decisão importante.";

        public string GetChallangeQuestion() { return challangeQuestion; }
    }
}
