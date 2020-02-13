using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public AudioClip backgroundSound;

	public Text scoreText;
	
	public Text playerHPText;

	public GameObject enemyPrefab;
	
	public GameObject playerHPBar;

	public GameObject player;

	public GameObject[] HPBars;

	public GameObject[] spawnArea;

	public int score;

	public int playerHP;

	public float firstRespawnTime = 7f;

	public float respawnTime = 3f;

	public static GameManager instance = null; // 싱글톤 패턴으로 생성하여 하나의 인스턴스만 가지도록 함
	void Awake()
	{
		if (instance == null)
			instance = this;

		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);

		InitGame();
	}

	//Initializes the game for each level.
	void InitGame()
	{
		AudioSource.PlayClipAtPoint(backgroundSound, transform.position);

		InvokeRepeating("enemySpawn", firstRespawnTime, respawnTime);
	}

	void Update()
	{
		scoreText.text = "SCORE\n" + score;
		playerHPText.text = ""+playerHP;
		HPBarStateChange();
	}

	public void enemySpawn()
	{
		respawnTime = Random.Range(5f, 10f);
		int spawnPoint = Random.Range(0, spawnArea.Length);
		GameObject enemy = GameObject.Instantiate(enemyPrefab, spawnArea[spawnPoint].transform.position, Quaternion.identity);
		enemy.GetComponent<EnemyMovement>().targetPlayer = player;
	}
	public void HPBarStateChange()
	{
		if(playerHP < 300)
		{
			HPBars[19].SetActive(false);
		}
		if (playerHP < 285)
		{ 
			HPBars[18].SetActive(false);
		}
		if (playerHP < 270)
		{
			HPBars[17].SetActive(false);
		}
		if (playerHP < 255)
		{
			HPBars[16].SetActive(false);
		}
		if (playerHP < 240)
		{
			HPBars[15].SetActive(false);
		}
		if (playerHP < 225)
		{
			HPBars[14].SetActive(false);
		}
		if (playerHP < 210)
		{
			HPBars[13].SetActive(false);
		}
		if (playerHP < 195)
		{
			HPBars[12].SetActive(false);
		}
		if (playerHP < 180)
		{
			HPBars[11].SetActive(false);
		}
		if (playerHP < 165)
		{
			HPBars[10].SetActive(false);
		}
		if (playerHP < 150)
		{
			HPBars[9].SetActive(false);
		}
		if (playerHP < 135)
		{
			HPBars[8].SetActive(false);
		}
		if (playerHP < 120)
		{
			HPBars[7].SetActive(false);
		}
		if (playerHP < 105)
		{
			HPBars[6].SetActive(false);
		}
		if (playerHP < 90)
		{
			HPBars[5].SetActive(false);
		}
		if (playerHP < 75)
		{
			HPBars[4].SetActive(false);
		}
		if (playerHP < 60)
		{
			HPBars[3].SetActive(false);
		}
		if (playerHP < 45)
		{
			HPBars[2].SetActive(false);
		}
		if (playerHP < 30)
		{
			HPBars[1].SetActive(false);
		}
		if (playerHP < 15)
		{
			HPBars[0].SetActive(false);
		}
		if (playerHP < 0)
		{
			scoreText.text = "Game Over";
		}


	}

}
