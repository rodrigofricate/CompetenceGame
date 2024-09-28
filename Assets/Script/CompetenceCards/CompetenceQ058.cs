using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ058 : ICompetenceCard
{

    string questionText = "Identifiquei um fator de risco em um projeto e compartilhei com a equipe de trabalho, mesmo sabendo que teremos que repensar fluxos já definidos.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Coragem;
    string number = "058";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
