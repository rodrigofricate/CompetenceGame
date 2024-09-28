using Assets.Script.Enums;
using Assets.Script.Interfaces;


public class CompetenceQ054 : ICompetenceCard
{

    string questionText = "Questionei meus colegas de trabalho sobre o contrato com um fornecedor antigo, propondo novos fornecedores que podem melhorar nossas entregas.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.Coragem;
    string number = "054";

    public string GetNumber() { return number; }


    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
