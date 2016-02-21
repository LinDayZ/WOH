using UnityEngine;
using System.Collections;

public class EnemyAttack: MonoBehaviour {
	//определение публичной переменных
	public GameObject target;//цель Enemy
	public float coolDown;//время между атаками
	public float attackTimer;//время проведения атаки
							 //згидшс временно для теста
	void Start () {
		//устанавливаем начальное значение
		attackTimer=0;
		coolDown = 2.0f;
	}

	void Update () {
		Attack();
		//выдерживаем паузу
		if (attackTimer > 0)
			attackTimer -= Time.deltaTime;
		//пауза закончена, на всякий случай обнуляем результат
		if (attackTimer < 0)
			attackTimer = 0;
		
			//если пауза выдержана, но наносим очередной удар
			if (attackTimer == 0) {
				Attack();
				//устанавливаем размер между ударами
				attackTimer=coolDown;
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
			PlayerHealth ah = (PlayerHealth)target.GetComponent ("PlayerHealth");
			//и используем его метод изменения состояния здоровья 
			//(необходимо переписать AddjustCurrentHeath с учетом новых требований)
			ah.AddjustCurrentHealth(-10);
		}
	}
}
