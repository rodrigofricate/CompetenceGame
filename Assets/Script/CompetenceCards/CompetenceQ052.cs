using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ052 : ICompetenceCard
{

    string questionText = "Ap�s mudar de �rea, procurei conhecer os fluxos da nova equipe e me adaptar �s mudan�as da melhor maneira.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Coragem;
    string number = "052";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
