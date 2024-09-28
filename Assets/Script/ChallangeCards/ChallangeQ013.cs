using Assets.Script.Interfaces;



namespace Assets.Script.ChallangeCards
{
    public class ChallangeQ013 : IChallangeCard
    {
        string challangeQuestion = "Vou planejar um grande projeto, mas não conheço o histórico das últimas edições. Como descobrir o que deu certo ou não?";

        public string GetChallangeQuestion() { return challangeQuestion; }
    }
}
