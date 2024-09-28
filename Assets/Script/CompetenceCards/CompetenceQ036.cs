using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ036 : ICompetenceCard
{

    string questionText = "Na reformula��o de um processo interno, testei v�rias possibilidades sem medo de errar.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Inova��o;
    string number = "036";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
