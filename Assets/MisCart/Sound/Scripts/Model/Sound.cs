using UnityEngine;

namespace Model
{
    // サウンドの種類
    public enum AudioType
    {
        SE,
        BGM
    }

    // Prefab/SE にサウンドを追加したときはここにも同じ名前で追加する
    public enum SE
    {
        SendToRaceScene,
        ButtonClick
    }

    // Prefab/BGM にサウンドを追加したときはここにも同じ名前で追加する
    public enum BGM
    {
        Title
    }
}