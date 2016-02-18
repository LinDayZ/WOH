//Скрипт описывающий простуб логику преследования игрока противником 
using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	// определяем настраиваем переменые
	public Transform target;//Цель
	public int moveSpeed;// скрость перемещения
	public int rotationSpeed;//скорость поворота
	public Transform myTransform;//временная переменная для хранения ссылки на свойство transform (это оптимизации)

	void Awake(){
		//ссылаемся на свойство transform, чтобы сократить время обращения к мему в теле скрипта
		myTransform=transform;
	}
	//начальная оптимизация 
	void Start () {
	//ищем объект по тегу Player
		GameObject go=GameObject.FindGameObjectWithTag("Player");
		//и ставим на него прицел (делаем нашей целью)
		target=go.transform;
	}

	// Update is called once per frame
	void Update () {
		//чертим линию  от нас к игроку (видно только в редакторе)
		Debug.DrawLine(target.position,myTransform.position,Color.yellow);
		//поварачиваемся в сторону игрока(цели)
		myTransform.rotation=Quaternion.Slerp(myTransform.rotation,Quaternion.LookRotation(target.position-myTransform.position),rotationSpeed * Time.deltaTime);
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
	}
}
