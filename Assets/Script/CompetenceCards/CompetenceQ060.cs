using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ060 : ICompetenceCard
{

    string questionText = "Um(a) colega persistiu no sucesso de um projeto mesmo depois de enfrentar algumas dificuldades.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Coragem;
    string number = "060";

    public string GetNumber() { return number; }

    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
