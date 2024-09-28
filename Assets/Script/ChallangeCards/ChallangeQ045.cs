using Assets.Script.Interfaces;



namespace Assets.Script.ChallangeCards
{
    public class ChallangeQ045 : IChallangeCard
    {
        string challangeQuestion = "Um canal de atendimento está fora do ar e preciso pensar em formas de minimizar o impacto aos clientes. Quais ações podem ajudar?";

        public string GetChallangeQuestion() { return challangeQuestion; }
    }
}
