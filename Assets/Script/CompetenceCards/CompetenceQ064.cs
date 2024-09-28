using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ064 : ICompetenceCard
{

    string questionText = "Apontei para a minha gest�o alguns pontos de melhoria que podem ajudar no papel de lideran�a.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Coragem;
    string number = "064";

    public string GetNumber() { return number; }

    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
