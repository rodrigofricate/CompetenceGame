using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ044 : ICompetenceCard
{

    string questionText = "Otimizei minha rotina de trabalho por meio de uma ferramenta �gil.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Inova��o;
    string number = "044";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
