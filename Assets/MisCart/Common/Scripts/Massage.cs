using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Transition;

public class Massage : MonoBehaviour {

    [SerializeField]private Text messageText;
    //　表示するメッセージ
    private string message;
    //　1回のメッセージの最大文字数
    [SerializeField]
    private int maxTextLength = 90;
    //　1回のメッセージの現在の文字数
    private int textLength = 0;
    //　メッセージの最大行数
    [SerializeField]
    private int maxLine = 3;
    //　現在の行
    private int nowLine = 0;
    //　テキストスピード
    [SerializeField]
    private float textSpeed = 0.05f;
    //　経過時間
    private float elapsedTime = 0f;
    //　今見ている文字番号
    private int nowTextNum = 0;
    //　マウスクリックを促すアイコン
    private Image clickIcon;
    //　クリックアイコンの点滅秒数
    [SerializeField]
    private float clickFlashTime = 0.2f;
    //　1回分のメッセージを表示したかどうか
    private bool isOneMessage = false;
    //　メッセージをすべて表示したかどうか
    private bool isEndMessage = false;

    private int CountPhase = 0;
    private bool GotoNextStep = true;
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject TM;

    public void ChangeGotoStep(bool i)
    {
        GotoNextStep = i;
    }

    void Start()
    {
        clickIcon = transform.Find("Canvas/Panel/Image").GetComponent<Image>();
        clickIcon.enabled = false;
        //messageText = transform.Find("Panel/text3").GetComponent<Text>();
        messageText.text = "";
        SetMessage("こんにちは！miscartの世界へようこそ！   \n"
            + "これからチュートリアルを開始します。\n"
            + "文字を送るには、ゲームパッドのBボタンか\n"
            + "キーボードのZキーを押してください。\n"
 
            + "まずは走行してみましょう\n"
            + "ゲームパッド:Bボタン押し続ける\n"
            + "キーボード　:Zボタン押し続ける\n"
            + "\n"

            + "左折、右折\n"
            + "ゲームパッド:左アナログスティック\n"
            + "キーボード　:←キー、→キー\n"
            + "\n"

             + "バック\n"
            + "ゲームパッド:Bボタン押し続ける\n"
            + "キーボード　:Xキー押し続ける\n"
            + "\n"

             + "バックカメラ\n"
            + "ゲームパッド:L2ボタン\n"
            + "キーボード　:Qキー押し続ける\n"
            + "\n"

            + "いい感じです！    \n"
            + "\n"
            + "\n"
            + "\n"

            + "次はドリフトです\n"
            + "ゲームパッド:走行中にR1を押しつつ曲がる\n"
            + "キーボード　:走行中にCを押しつつ曲がる \n"
            + "\n"

             + "上手くできましたか？\n"
            + "\n"
            + "\n"
            + "\n"

             + "次はブーストダッシュです\n"
            + "ゲームパッド:R2\n"
            + "キーボード　:Vキー\n"
            + "\n"

             + "画面下の黄色いエネルギーが\n"
            + "一定量ある場合に発動可能です\n"
            + "エネルギーは黄色いパネルに乗ることで\n"
            + "チャージできます\n"

             + "その調子です！\n"
            + "\n"
            + "\n"
            + "\n"

             + "次はアイテムを使ってみましょう\n"
            + "アイテムはUSBメモリに触れることで\n"
            + "獲得できます\n"
            + "\n"

             + "CD\n"
            + "当たると爆発するCDを\n"
            + "前方に飛ばす\n"
            + "\n"

             + "DVD\n"
            + "当たると爆発するDVDを\n"
            + "飛ばす\n"
            + "一番近い敵を追尾する\n"

             + "延長コード\n"
            + "当たった敵の最高速度を\n"
            + "一定時間半減させる\n"
            + "\n"

             + "その他にも選んだカート専用の\n"
            + "スペシャルアイテムもあります\n"
            + "\n"
            + "\n"

             + "アイテム使用\n"
            + "ゲームパッド:L1\n"
            + "キーボード　:Spaceキー\n"
            + "\n"

             + "使い方は分かりましたか？\n"
            + "これでチュートリアルは終了です\n"
            + "ぜひ色々なコースで遊んでみてください！\n"
            + "\n"

            

             + "\n"
            + "\n"
            + "\n"
            + "\n"

             + "\n"
            + "\n"
            + "\n"
            + "\n"

             + "\n"
            + "\n"
            + "\n"
            + "\n"
        );
    }

    void Update()
    {
        if (GotoNextStep)
        {
            if (Panel.activeSelf==false)
            {
                Panel.SetActive(true);
            }

            //　メッセージが終わっていない、または設定されている
            if (isEndMessage || message == null)
            {
                return;
            }

            //　1回に表示するメッセージを表示していない	
            if (!isOneMessage)
            {

                //　テキスト表示時間を経過したら
                if (elapsedTime >= textSpeed)
                {
                    messageText.text += message[nowTextNum];
                    //　改行文字だったら行数を足す
                    if (message[nowTextNum] == '\n')
                    {
                        nowLine++;
                    }
                    nowTextNum++;
                    textLength++;
                    elapsedTime = 0f;

                    //　メッセージを全部表示、または行数が最大数表示された
                    if (nowTextNum >= message.Length || textLength >= maxTextLength || nowLine >= maxLine)
                    {
                        isOneMessage = true;
                    }
                }
                elapsedTime += Time.deltaTime;

                //　メッセージ表示中にマウスの左ボタンを押したら一括表示
                if ((Input.GetMouseButtonDown(0)) || (Input.GetKeyDown(KeyCode.Joystick1Button0)) || (Input.GetKeyDown(KeyCode.Z)))
                {
                    //　ここまでに表示しているテキストを代入
                    var allText = messageText.text;

                    //　表示するメッセージ文繰り返す
                    for (var i = nowTextNum; i < message.Length; i++)
                    {
                        allText += message[i];

                        if (message[i] == '\n')
                        {
                            nowLine++;
                        }
                        nowTextNum++;
                        textLength++;

                        //　メッセージがすべて表示される、または１回表示限度を超えた時
                        if (nowTextNum >= message.Length || textLength >= maxTextLength || nowLine >= maxLine)
                        {
                            messageText.text = allText;
                            isOneMessage = true;
                            break;
                        }
                    }
                }
                //　1回に表示するメッセージを表示した
            }
            else
            {

                elapsedTime += Time.deltaTime;

                //　クリックアイコンを点滅する時間を超えた時、反転させる
                if (elapsedTime >= clickFlashTime)
                {
                    clickIcon.enabled = !clickIcon.enabled;
                    elapsedTime = 0f;
                }

                //　マウスクリックされたら次の文字表示処理
                if ((Input.GetMouseButtonDown(0)) || (Input.GetKeyDown(KeyCode.Joystick1Button0)) || (Input.GetKeyDown(KeyCode.Z)))
                {
                    //Debug.Log(messageText.text.Length);


                    messageText.text = "";
                    nowLine = 0;
                    clickIcon.enabled = false;
                    elapsedTime = 0f;
                    textLength = 0;
                    isOneMessage = false;

                    CountPhase++;
                    Debug.Log("Phase:" + CountPhase);
                    if ((CountPhase == 5)||(CountPhase==7) || (CountPhase == 10) || (CountPhase == 17) || (CountPhase == 18))
                    {
                        GotoNextStep = false;
                    }

                    if (CountPhase == 18)
                    {
                        //シーン遷移処理
                        SceneLoader.LoadScene(Model.GameScenes.Title);
                    }

                    //　メッセージが全部表示されていたらゲームオブジェクト自体の削除
                    if (nowTextNum >= message.Length)
                    {
                        nowTextNum = 0;
                        isEndMessage = true;
                        transform.GetChild(0).gameObject.SetActive(false);

                        //　それ以外はテキスト処理関連を初期化して次の文字から表示させる
                    }
                }
            }


        }
        else
        {
            TM.GetComponent<TutorialManager>().SwitchActive(true);
            Panel.SetActive(false);
            
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            GotoNextStep = true;
            Debug.Log(GotoNextStep);
        }
    }

    void SetMessage(string message)
    {
        this.message = message;
    }
    //　他のスクリプトから新しいメッセージを設定
    public void SetMessagePanel(string message)
    {
        SetMessage(message);
        transform.GetChild(0).gameObject.SetActive(true);
        isEndMessage = false;
    }
}
