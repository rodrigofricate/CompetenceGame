using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ048 : ICompetenceCard
{

    string questionText = "A minha equipe de trabalho buscou uma startup para nos ajudar a resolver um problema.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Inovação;
    string number = "048";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
