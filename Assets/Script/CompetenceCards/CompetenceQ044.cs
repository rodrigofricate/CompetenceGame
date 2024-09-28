using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ044 : ICompetenceCard
{

    string questionText = "Otimizei minha rotina de trabalho por meio de uma ferramenta ágil.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Inovação;
    string number = "044";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
