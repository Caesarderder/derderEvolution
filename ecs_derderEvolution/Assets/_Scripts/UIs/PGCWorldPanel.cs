using Assets._Scripts.Models.World;
using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class PGCWorldPanel: ViewBase
{
    [SerializeField]
    TMP_InputField 
        if_worldSeedNum;
    [SerializeField]
    Button 
        btn_start,
        btn_back
        ;

    private WorldPropertyConfigSO
        ConfigSO;
    private WorldPropertyConfig
        CurConfig;


#region Unity

    private void Start()
    {
    }

    private void Update()
    {
    }
    public override void Show()
    {
        base.Show();

        ConfigSO=Manager<TableManager>.Inst.WorldPropertyConfig;
        CurConfig=ConfigSO.GetByIndex(0);

        if_worldSeedNum.text = CurConfig.WorldSeed.ToString();
        if_worldSeedNum.onEndEdit.AddListener(OnEditWorldSeed);

        btn_start.OnClickAsObservable().Subscribe(async x => {
            await Manager<ActManager>.Inst.LoadAct<GameAct>();
            //await Manager<UIManager>.Inst.ShowUI<GamePlayPanel>();  //¶¯Ì¬¼ÓÔØGamePlayPanel
        }).AddTo(this);

        btn_back.OnClickAsObservable().Subscribe(async x => {
            Manager<UIManager>.Inst.DestroyUI<PGCWorldPanel>();  
            await Manager<UIManager>.Inst.ShowUI<HomePanel>();  
        }).AddTo(this);
    }

    public override void Destroy()
    {
        base.Destroy();
    }

    public override void Hide()
    {
        base.Hide();
        if_worldSeedNum.onEndEdit.RemoveAllListeners();
    }


    public override void Load()
    {
        base.Load();
    }

    #endregion

    private void OnEditWorldSeed(string input)
    {


    }
}
