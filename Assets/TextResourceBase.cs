using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class TextResourceBase : GenericSingleTon<TextResourceBase>
{
    DummyWrapper dw = new DummyWrapper(); 
    [SerializeField] int _dummyCount;

    bool _isLoadEnd = false;

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.P))
        {
            //���� �����͸� ���� ĳ�������� ����
            MakeDummyDatas();
        }

        //if(Input.GetKeyDown(KeyCode.M))
        //{
        //    LoadDummyDatas();

        //}
        
    }
    //void LoadDummyDatas()
    //{
    //    string json;
    //    using(StreamReader rd = new StreamReader(Application.persistentDataPath + "/dummyData.json"))
    //    {
    //        json = rd.ReadToEnd();
    //    }

    //    if(string.IsNullOrEmpty(json) == false)
    //    {
    //        dw = JsonUtility.FromJson<DummyWrapper>(json);
    //        Debug.Log($"�� ������ ����� : {dw._datas[0].Value}, {dw._datas[0].iValue}");
    //    }

    //}
    public void LoadData()
    {
        if(_isLoadEnd == false) AsyncLoadData();
    }
    async void AsyncLoadData()
    {
        string json;
        using (StreamReader rd = new StreamReader(Application.persistentDataPath + "/dummyData.json"))
        {
            json =await rd.ReadToEndAsync(); // await Ű���带 ������
        }

        if( string.IsNullOrEmpty(json) == false ) 
        {
            await Task.Run(() =>
            {
                dw = JsonUtility.FromJson<DummyWrapper>(json);
            });
            _isLoadEnd= true;
        }
    }

    public bool isLoadFinish() => _isLoadEnd;
    void MakeDummyDatas()
    {
        for(int i = 0 ; i < _dummyCount; i++)
        {
            DummyData dd = new DummyData();
            System.Random rr = new System.Random();

            dd.Value = rr.NextDouble(); // �ؽ�Ʈ��� �Լ��� ���� ���� �޴´�.
            dd.iValue = rr.Next();
            dw._datas.Add(dd);


        }

        string json = JsonUtility.ToJson(dw);
        using (StreamWriter outStream = File.CreateText(Application.persistentDataPath + "/dummyData.json"))
        {
            outStream.Write(json);
        }

    }
}
[Serializable]
public class DummyWrapper
{
    public List<DummyData> _datas = new List<DummyData>();

}
[Serializable]
public class DummyData
{
    public double Value;
    public int iValue;

}
