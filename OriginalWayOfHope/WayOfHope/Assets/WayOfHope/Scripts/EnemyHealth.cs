﻿using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	//публичные переменные для настроек
	public int maxHealth=150;
	//Приватные переменные для настроек
	private int _curHealth=100;
	private float healthBarLength;
	//производятся начальные расчеты при создании объекта
	void Start () {
		//задаем начальную ширину бара здоровья
		healthBarLength=Screen.width/2;
		//предотвращаем ввод неправильно числа здоровья
		if(maxHealth<1)maxHealth=1;
		_curHealth = maxHealth;
	}

	// Update is called once per frame
	void Update () {

	}
	//функция графического интерфейса
	void OnGUI()
	{
		//выводит бар о состояние здоровья человека
		GUI.Box(new Rect(10,40,healthBarLength,20),_curHealth+"/"+maxHealth);
	}
	//произвольные рассчеты размера бара и здоровья..
	public void AddjustCurrentHealth(int adj){
		_curHealth += adj;
		//Блок по предотвращению получения неверного состояния здоровья
		//меньше нуля и больше максимума
		//так как изменяем здоровье из вне
		if(_curHealth<0)_curHealth=0;
		if (_curHealth > maxHealth)_curHealth = maxHealth;
		//расчет бара непосредственно
		healthBarLength=(Screen.width/2)*(_curHealth/(float)maxHealth);
	}
}
