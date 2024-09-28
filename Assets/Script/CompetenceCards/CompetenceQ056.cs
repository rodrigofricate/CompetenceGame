using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ056 : ICompetenceCard
{

    string questionText = "Assumi um novo projeto que representa um grande desafio profissional.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Coragem;
    string number = "056";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
