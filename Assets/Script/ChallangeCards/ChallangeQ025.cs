using Assets.Script.Interfaces;



namespace Assets.Script.ChallangeCards
{
    public class ChallangeQ025 : IChallangeCard
    {
        string challangeQuestion = "Como posso contribuir para que fornecedores, parceiros e demais áreas também considerem os clientes no centro de suas decisões?";

        public string GetChallangeQuestion() { return challangeQuestion; }
    }
}
