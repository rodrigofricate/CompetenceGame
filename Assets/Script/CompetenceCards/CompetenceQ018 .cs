using Assets.Script.Enums;
using Assets.Script.Interfaces;
using Unity.VisualScripting;


public class CompetenceQ018 : ICompetenceCard
{
    string number = "018";
    string questionText = "Eu e um(a) colega conclu�mos uma forma��o sobre uma ferramenta que est� em alta no mercado.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.HabilidadeDigital;


    public string GetNumber() { return number; }
    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
