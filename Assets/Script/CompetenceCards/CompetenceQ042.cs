using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ042 : ICompetenceCard
{

    string questionText = "Simplifiquei um processo burocr�tico que era cr�tico em minha �rea.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Inova��o;
    string number = "042";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
