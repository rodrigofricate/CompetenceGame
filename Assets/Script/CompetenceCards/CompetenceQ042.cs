using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ042 : ICompetenceCard
{

    string questionText = "Simplifiquei um processo burocrático que era crítico em minha área.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Inovação;
    string number = "042";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
