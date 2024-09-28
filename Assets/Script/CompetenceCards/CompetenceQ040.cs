using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ040 : ICompetenceCard
{

    string questionText = "Criei a rotina de experimentar e prototipar solu��es, testando novas alternativas at� entender qual � a melhor op��o.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Inova��o;
    string number = "040";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
