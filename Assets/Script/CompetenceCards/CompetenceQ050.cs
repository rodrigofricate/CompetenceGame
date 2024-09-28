using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ050 : ICompetenceCard
{

    string questionText = "A minha gest�o compartilhou a sua opini�o, de forma transparente e cuidadosa, ao dar feedback para a equipe.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Coragem;
    string number = "050";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
