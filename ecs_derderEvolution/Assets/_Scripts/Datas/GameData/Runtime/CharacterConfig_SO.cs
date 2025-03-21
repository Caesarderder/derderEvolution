using UnityEngine;
using System.Collections.Generic;
using System.Linq;


///
/// !!! Machine generated code !!!
///
/// A class which deriveds ScritableObject class so all its data 
/// can be serialized onto an asset data file.
/// 
[System.Serializable]
public class CharacterConfig_SO : ScriptableObject 
{	
    [HideInInspector] [SerializeField] 
    public string SheetName = "";
    
    [HideInInspector] [SerializeField] 
    public string WorksheetName = "";
    
    // Note: initialize in OnEnable() not here.
    public CharacterConfig[] dataArray;

    private Dictionary<int,CharacterConfig> _map;
    public Dictionary<int,CharacterConfig> Map{
        get
        {
//            if(_map!=null)
//            {
//                _map=dataArray.ToDictionary(x=> x.Id,x=>x);
//            }
            return _map;
        }
    }
    public void Init()
    {
        if(_map==null)
        {
            _map=dataArray.ToDictionary(x=> x.Id,x=>x);
        }
    }

    
    void OnEnable()
    {		
//#if UNITY_EDITOR
        //hideFlags = HideFlags.DontSave;
//#endif
        // Important:
        //    It should be checked an initialization of any collection data before it is initialized.
        //    Without this check, the array collection which already has its data get to be null 
        //    because OnEnable is called whenever Unity builds.
        // 		
        if (dataArray == null)
            dataArray = new CharacterConfig[0];

    }
    
    //
    // Highly recommand to use LINQ to query the data sources.
    //

}
