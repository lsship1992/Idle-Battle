using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
public class DopInfoPerson : MonoBehaviour
{
    public float Attack;
    public float Hp;
    public float Defens;
    public float Speed;
    public int DamageReduction;
    public int CritDamage;
    public int CritChance;
    public int Evasion;
    public int Accuracy;
    public int DamageBonus;
    public int AntiCrit;
    public int Control;
    public int AntiControl;
    public int Treatment;
    public int Recovery;
    public Text AttackText;
    public Text HpText;
    public Text DefenTexts;
    public Text SpeedText;
    public Text DamageReductionText;
    public Text CritDamagTexte;
    public Text CritChanceText;
    public Text EvasionText;
    public Text AccuracyText;
    public Text DamageBonusText;
    public Text AntiCritText;
    public Text ControlText;
    public Text AntiControlText;
    public Text TreatmentText;
    public Text RecoveryText;

    private void Update()
    {
        AttackText.text = Convert.ToString((BigInteger)Attack);
        HpText.text = Convert.ToString((BigInteger)Hp);
        DefenTexts.text = Convert.ToString((BigInteger)Defens);
        SpeedText.text = Convert.ToString((BigInteger)Speed);
        DamageReductionText.text = $"��. �����: {DamageReduction.ToString()}";
        CritDamagTexte.text = $"���� ����: {CritDamage.ToString()}";
        CritChanceText.text = $"���� �����: {CritChance.ToString()}";
        EvasionText.text = $"���������: {Evasion.ToString()}";
        AccuracyText.text = $"��������: {Accuracy.ToString()}";
        DamageBonusText.text = $"����� �����: {DamageBonus.ToString()}";
        AntiCritText.text = $"����-����: {AntiCrit.ToString()}";
        ControlText.text = $"��������: {Control.ToString()}";
        AntiControlText.text = $"����-��������: {AntiControl.ToString()}";
        TreatmentText.text = $"�������: {Treatment.ToString()}";
        RecoveryText.text = $"��������������: {Recovery.ToString()}";

    }
}
