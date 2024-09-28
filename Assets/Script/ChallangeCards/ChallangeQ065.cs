using Assets.Script.Interfaces;



namespace Assets.Script.ChallangeCards
{
    public class ChallangeQ065 : IChallangeCard
    {
        string challangeQuestion = "Em que momento a minha equipe deve fazer uma pausa para analisar as nossas entregas e ver o que foi bom ou precisa melhorar?";

        public string GetChallangeQuestion() { return challangeQuestion; }
    }
}
