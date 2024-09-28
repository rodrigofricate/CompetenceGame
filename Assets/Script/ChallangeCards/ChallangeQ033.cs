using Assets.Script.Interfaces;



namespace Assets.Script.ChallangeCards
{
    public class ChallangeQ033 : IChallangeCard
    {
        string challangeQuestion = "Descobri que outra área está atuando no mesmo projeto que a minha equipe, " +
            "mas cada time teve suas próprias ideias sobre como desenvolvê-lo. O que fazer?";

        public string GetChallangeQuestion() { return challangeQuestion; }
    }
}
