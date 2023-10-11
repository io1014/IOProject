using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class LinqPractice : MonoBehaviour
{
    List<int> ints = new List<int>();
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            int addValue = Random.Range(0, 1000);
            ints.Add(addValue);
        }

        if(Input.GetMouseButtonDown(1))
        {
            //// 가장 큰 값을 검색해서 출력
            //int result = int.MinValue;
            //foreach(var data in ints)
            //{
            //    if(result < data)
            //    {
            //        result = data;
            //    }
            //}
            //// result에는 가장 큰 int값이 남게 됨
            foreach(var data in ints)
            {
                Debug.Log($"List in value : {data}");
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var results = from data in ints  // 어떤 컬렉션에서 데이터를 꺼낼것인가를 in뒤에 지정
                                             // 각 데이터요소를 어떤 이름으로 쓸것인가. from 뒤에 지정
                                             // foreach문을 참고하면 이해
                          orderby data descending // orderby 대표적인 필터링 쿼리, 정렬
                                                  // 정렬할 기준 데이터를 orderby 뒤에 쓰고 맨뒤에 정렬방식
                                                  // descending 내림차순, ascending 오름차순
                          where data % 2 == 0 // 조건식을 where 문 뒤에 작성
                          where data > 900 //여러개 작성해서 여러 필터링을 가할 수 있음
                          select data; // 필터링한 데이터에서 어떤 데이터를 최종적으로 추출할 것인가.

            foreach(var data in results)
            {
                Debug.Log($"ordered data : {data}");
            }
        }
    }
}
