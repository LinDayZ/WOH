//Атака игрока с нанесние урона Enemy
using UnityEngine;
using System.Collections;

public class PlayAttack : MonoBehaviour {
	//Определение публичных переменных
	public GameObject target;//цель игрока
	// Use this for initialization
	void Start () {
	
	}
	//цикл на каждый кадр
	
	// Update is called once per frame
	void Update () {
	//по нажатию клавиши F на клавиатуре происходит атака по Enemy
		if(Input.GetKeyUp(KeyCode.F)){
			Attack ();
		}
	}
	//атака Enemy
	private void Attack(){

		Debug.Log ("Player Attacking");
		//У цели Enemy ищим компонет с именем EnemyHealth - скрипт
		EnemyHealth eh=(EnemyHealth)target.GetComponent("EnemyHealth");
		//и используем его метод изменения состояния здоровья 
		//(необходимо переписать AddjustCurrentHeath с учетом новых требований)
		eh.AddjustCurrentHealth(-10);
	}
}
