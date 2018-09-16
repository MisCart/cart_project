using UnityEngine;

namespace Model
{
    // サウンドの種類
    public enum AudioType
    {
        SE,
        BGM
    }

    // Resources/Sounds/SE にサウンドを追加したときはここにも同じ名前で追加する
    public enum SE
    {
        SendToRaceScene,
        ButtonClick,
        bomb1,
        boost2,
        encount1,
        SE_car_drive,
        powerup2,
        setup1,
        アイテム投擲,



    }

    // Resources/Sounds/BGM にサウンドを追加したときはここにも同じ名前で追加する
    public enum BGM
    {
        Title,
        deathmetal2
    }
}