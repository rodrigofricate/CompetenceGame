using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ034 : ICompetenceCard
{

    string questionText = "Com uma nova proposta, aprimorei o fluxo de atendimento da minha área.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Inovação;
    string number = "034";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
