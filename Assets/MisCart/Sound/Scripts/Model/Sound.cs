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
        EngineSound,
        powerup2,
        setup1,
        アイテム投擲,
        Tap,            // OKボタンをクリックしたとき
        Cansel,         // Canselボタンをクリックしたとき
        Select,         // ボタンを押したとき
        paintland,
        paintfire,
        hacksuccess,
        hacklong,
        braking,
        itemselect,
        item,
        cddvd2,
        lap,
        charge,
        BoostCPU,
        CoundDown,     // レース開始時のカウントダウン
        Fanfare        // レース終了時のファンファーレ
    }

    // Resources/Sounds/BGM にサウンドを追加したときはここにも同じ名前で追加する
    public enum BGM
    {
        Title,
        deathmetal2,
        TitleSelect,
        Win,
        Lose
    }
}