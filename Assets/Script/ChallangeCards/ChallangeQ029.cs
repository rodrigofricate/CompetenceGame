using Assets.Script.Interfaces;



namespace Assets.Script.ChallangeCards
{
    public class ChallangeQ029 : IChallangeCard
    {
        string challangeQuestion = "Um(a) colega está com dificuldade em concluir uma atividade. " +
            "Eu tenho conhecimento sobre essa demanda, mas a minha agenda está repleta de compromissos. O que fazer?";

        public string GetChallangeQuestion() { return challangeQuestion; }
    }
}
