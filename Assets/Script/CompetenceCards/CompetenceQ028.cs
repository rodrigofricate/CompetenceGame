using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ028 : ICompetenceCard
{

    string questionText = "Construí um novo projeto por meio da tecnologia.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.HabilidadeDigital;
    string number = "028";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
