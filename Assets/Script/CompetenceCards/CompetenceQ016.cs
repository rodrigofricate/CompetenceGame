using Assets.Script.Enums;
using Assets.Script.Interfaces;
using Unity.VisualScripting;


public class CompetenceQ016 : ICompetenceCard
{
    string number = "016";
    string questionText = "No meu dia a dia, pratico a escuta ativa com meus clientes e busco implementar as oportunidades de melhorias identificadas.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.CentralidadeNoCliente;


    public string GetNumber() { return number; }
    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
