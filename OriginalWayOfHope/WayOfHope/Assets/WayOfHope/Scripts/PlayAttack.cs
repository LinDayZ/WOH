﻿//Атака игрока с нанесние урона Enemy
using UnityEngine;
using System.Collections;

public class PlayAttack : MonoBehaviour {
	//Определение публичных переменных
	public GameObject target;//цель игрока
	public float coolDown;//время между атаками
	public float attackTimer;//время проведения атаки 
							//public временно для теста
	// Use this for initialization
	void Start () {
		//устанавливаем начальное значение 
		attackTimer = 0;
		if (coolDown == 0) {
			coolDown = 2.0f;
		}
	
	}
	//цикл на каждый кадр
	
	// Update is called once per frame
	void Update () {
		//выдерживаем паузу
		if (attackTimer > 0)
			attackTimer -= Time.deltaTime;
		//пауза закончена, на всякий случай обнуляем результат
		if (attackTimer < 0)
			attackTimer = 0;
		//По нажатию на клавишу Fy на клавиатуре происходит Enemy
		if (Input.GetKeyUp (KeyCode.F)) {
			//если пауза выдержана, но наносим очередной удар
			if (attackTimer == 0) {
				Attack();
				//устанавливаем размер между ударами
				attackTimer=coolDown;
			}
		}
	//по нажатию клавиши F на клавиатуре происходит атака по Enemy
		if(Input.GetKeyUp(KeyCode.F)){
			Attack ();
		}
	}
	//атака Enemy
	private void Attack(){
		//вводим переменную distance и вычисляем расстояние между игроком
		//и его целью
		float distance = Vector3.Distance (target.transform.position, transform.position);
		//вычисляем единичный векор направления к цели
		Vector3 dir = (target.transform.position - transform.position).normalized;
		//вычисляем нахождение цели в поле зрения (значение 0 и отрицательное - сзади)
		//значение+впереди. Значение меняется от -1 до 1
		float direction = Vector3.Dot (dir, transform.forward);
		//усли дистанция меньше максимальной, то можем нанести урон
		if (distance < 2 && direction > 0) {
			//У цели Enemy ищим компонет с именем EnemyHealth - скрипт
			EnemyHealth eh = (EnemyHealth)target.GetComponent ("EnemyHealth");
			//и используем его метод изменения состояния здоровья 
			//(необходимо переписать AddjustCurrentHeath с учетом новых требований)
			eh.AddjustCurrentHealth (-10);
		}
	}
}
