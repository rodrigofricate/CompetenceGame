using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ030 : ICompetenceCard
{

    string questionText = "Desenvolvi um sistema para a mensura��o de dados da minha �rea.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.HabilidadeDigital;
    string number = "030";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
