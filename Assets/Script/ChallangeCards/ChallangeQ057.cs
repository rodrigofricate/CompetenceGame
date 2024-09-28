using Assets.Script.Interfaces;



namespace Assets.Script.ChallangeCards
{
    public class ChallangeQ057 : IChallangeCard
    {
        string challangeQuestion = "Devo alinhar as expectativas sobre resultados com o(a) cliente ou é melhor eu definir e controlar as entregas?";

        public string GetChallangeQuestion() { return challangeQuestion; }
    }
}
