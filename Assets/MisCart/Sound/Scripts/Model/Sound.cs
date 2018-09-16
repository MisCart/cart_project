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
<<<<<<< HEAD
        ButtonClick,
        bomb1,
        boost2,
        encount1,
        SE_car_drive,
        powerup2,
        setup1,
        アイテム投擲,



=======
        Tap,
        Cansel,
        Select,
        bomb1
>>>>>>> f59ae4934cf9955724ccc55d733f75608c05c2e2
    }

    // Resources/Sounds/BGM にサウンドを追加したときはここにも同じ名前で追加する
    public enum BGM
    {
        Title,
<<<<<<< HEAD
        deathmetal2
=======
        TitleSelect
>>>>>>> f59ae4934cf9955724ccc55d733f75608c05c2e2
    }
}