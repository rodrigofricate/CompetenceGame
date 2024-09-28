using Assets.Script.Interfaces;



namespace Assets.Script.ChallangeCards
{
    public class ChallangeQ053 : IChallangeCard
    {
        string challangeQuestion = "Estou criando um novo serviço. Devo implantá-lo somente depois que estiver totalmente pronto ou posso lançar uma versão beta?";

        public string GetChallangeQuestion() { return challangeQuestion; }
    }
}
