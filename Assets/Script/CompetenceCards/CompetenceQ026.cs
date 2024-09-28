using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ026 : ICompetenceCard
{

    string questionText = "Aprendi a utilizar um novo sistema.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.HabilidadeDigital;
    string number = "026";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
