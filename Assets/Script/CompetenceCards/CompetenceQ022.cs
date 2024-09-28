using Assets.Script.Enums;
using Assets.Script.Interfaces;
using Unity.VisualScripting;


public class CompetenceQ022 : ICompetenceCard
{
    
    string questionText = "A minha gestão utilizou dados para auxiliar na escolha de um fornecedor.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.HabilidadeDigital;
    string number = "022";

    public string GetNumber() { return number; }
    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
