using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class ManegerLeader : MonoBehaviour {
	
	/*ToDo　共通項のみここに作り、継承で必要なものを分岐.
	　　　　
	　　　　継承で使うデータは全てpublicにしなければいけない為、全てpublicにしてある.
	*/
	
	public string FileName = "CSV/Stage1";
	
	public int TalkNumber = 0;
	public int TalkMax = 1023;
	public string[] LeftCommand;
	public string[] RightCommand;
	
	public bool GoForward = true;
	
	/*public GameObject TextBox;
	public GameObject DisplayText;*/
	
	public int TalkCount = 0;
	
	void Start () {
		//Debug.Log(FileName.Length);
		
		LeftCommand = new string[TalkMax];
		RightCommand = new string[TalkMax];
		
		csvRead_AddData(FileName);
		
		Debug.Log(RightCommand[0]);
		Debug.Log(RightCommand[1]);
		Debug.Log(LeftCommand[0]);
		Debug.Log(LeftCommand[1]);
	}
	
	void Update () {
		//playerprefsを使用して、設定ごとに動作を変える
		if( LeftCommand == "　場面転換" ||
			LeftCommand == "　背景変更" ||
			LeftCommand == "　　左登場" ||
			LeftCommand == "　　右登場" ||
			LeftCommand == "　　左削除" ||
			LeftCommand == "　　右削除" ||
			LeftCommand == "　　右更新" ||
			LeftCommand == "　　左更新" ||
			LeftCommand == "フラグオン" ||
			LeftCommand == "フラグオフ" ||
			LeftCommand == "　コメント" ||){
				TalkCount++;
		}
		
	}
	
//-----------------------------------------------------------------------
	void csvRead_AddData(string fileName){
		TextAsset csv = Resources.Load(fileName) as TextAsset;
        StringReader reader = new StringReader(csv.text);
        while(reader.Peek() > -1){
            string line = reader.ReadLine();
            string[] values = line.Split(',');
			LeftCommand[TalkNumber] = values[0];
			RightCommand[TalkNumber] = values[1];
			TalkNumber++;
			if(reader.Peek() <= -1){
				TalkNumber = 0;
			}
		}
	}
}
