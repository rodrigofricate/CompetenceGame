using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ038 : ICompetenceCard
{

    string questionText = "Um(a) colega sugeriu mudanças para otimizar um processo de trabalho.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Inovação;
    string number = "038";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
