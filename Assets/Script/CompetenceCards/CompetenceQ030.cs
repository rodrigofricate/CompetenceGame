using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ030 : ICompetenceCard
{

    string questionText = "Desenvolvi um sistema para a mensuração de dados da minha área.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.HabilidadeDigital;
    string number = "030";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
