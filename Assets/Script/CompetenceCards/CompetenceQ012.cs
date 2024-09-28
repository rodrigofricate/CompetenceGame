using Assets.Script.Enums;
using Assets.Script.Interfaces;
using Unity.VisualScripting;


public class CompetenceQ012 : ICompetenceCard
{
    string number = "012";
    string questionText = "Um(a) colega criou a rotina de consultar, regularmente, indicadores de experi�ncia e satisfa��o dos clientes para entender " +
        "se as atividades que desempenha est�o no caminho certo.";
    EnumCompetenceAnsware rigthAnsware = EnumCompetenceAnsware.CentralidadeNoCliente;


    public string GetNumber() { return number; }
    public string GetTitle() { return questionText; }
    public EnumCompetenceAnsware GetRigthAnsware() { return rigthAnsware; }



}
