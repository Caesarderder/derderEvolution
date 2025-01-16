using UnityEngine;

public class GamePlayDM : DataModule
{
    #region Fileds 亻尔 女子
    //关卡状态
    private Intent _intent;

    #endregion


    #region Init
    public override void OnCreate()
    {
        base.OnCreate();
        _intent = Intent.Get();
        EventAggregator.Subscribe<SActLoadEvent>(OnEnterGame);
        EventAggregator.Subscribe<SActUnloadedEvent>(OnExitGame);
    }
    public override void OnDestory()
    {
        base.OnDestory();
        EventAggregator.Unsubscribe<SActLoadEvent>(OnEnterGame);
        EventAggregator.Unsubscribe<SActUnloadedEvent>(OnExitGame);
    }

    public void OnEnterGame(SActLoadEvent evt)
    {
    }

    public void OnExitGame(SActUnloadedEvent evt)
    {
    }

    #endregion

}
