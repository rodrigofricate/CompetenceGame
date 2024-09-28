using Assets.Script.Interfaces;



namespace Assets.Script.ChallangeCards
{
    public class ChallangeQ041 : IChallangeCard
    {
        string challangeQuestion = "Preciso saber como as entregas de um projeto estão agregando valor ao público-alvo, mas há várias áreas trabalhando juntas." +
            " Quais ferramentas podem me ajudar?";

        public string GetChallangeQuestion() { return challangeQuestion; }
    }
}
