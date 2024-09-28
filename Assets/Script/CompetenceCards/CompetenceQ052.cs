using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ052 : ICompetenceCard
{

    string questionText = "Após mudar de área, procurei conhecer os fluxos da nova equipe e me adaptar às mudanças da melhor maneira.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Coragem;
    string number = "052";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
