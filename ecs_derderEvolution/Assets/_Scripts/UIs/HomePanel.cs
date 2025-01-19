using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class HomePanel : ViewBase
{
    [SerializeField]
    Button 
        btn_start,
        btn_UGCWorld
        ;

#region Unity
    public override void Show()
    {
        base.Show();

        btn_start.OnClickAsObservable().Subscribe(async x => {
            Manager<UIManager>.Inst.DestroyUI<PGCWorldPanel>();  
            await Manager<UIManager>.Inst.ShowUI<PGCWorldPanel>();  
        });
    }

    public override void Destroy()
    {
        base.Destroy();
    }

    public override void Hide()
    {
        base.Hide();
    }

    public override void Load()
    {
        base.Load();
    }

    #endregion
}
