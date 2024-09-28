using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ040 : ICompetenceCard
{

    string questionText = "Criei a rotina de experimentar e prototipar soluções, testando novas alternativas até entender qual é a melhor opção.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Inovação;
    string number = "040";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
