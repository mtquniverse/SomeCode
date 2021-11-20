using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarcosQuijada.Chemibot {

public class SoundController : MonoBehaviour {


	public AudioSource music, musicMenu, gameOver, megaSpark, popUp, popUpWrong, priceTick, priceReward; 

    public AudioSource[] button, buttonBack, spark, impact;

    
	void Start() {
        ChangeSoundsVolume();
        ChangeMusicVolume();
    }


	public void PlayButton() {
		button[Random.Range(0, button.Length)].Play();
	}

	public void PlayButtonBack() {
		buttonBack[Random.Range(0, buttonBack.Length)].Play();
	}

	public void PlaySparkSound() {
		spark[Random.Range(0, spark.Length)].Play();
	}

	public void PlayImpactSound() {
		impact[Random.Range(0, impact.Length)].Play();
	}

    public void ChangeSoundsVolume() { 
		gameOver.volume = Game.soundsVol;
		megaSpark.volume = Game.soundsVol;
		popUp.volume = Game.soundsVol;
		popUpWrong.volume = Game.soundsVol;
		priceTick.volume = Game.soundsVol;
		priceReward.volume = Game.soundsVol;
		foreach (AudioSource sound in button) {
			sound.volume = Game.soundsVol;
		}
		foreach (AudioSource sound in buttonBack) {
			sound.volume = Game.soundsVol;
		}
		foreach (AudioSource sound in spark) {
			sound.volume = Game.soundsVol;
		}
		foreach (AudioSource sound in impact) {
			sound.volume = Game.soundsVol;
		}
	}


	public void ChangeMusicVolume() {
		music.volume = Game.musicVol;
		musicMenu.volume = Game.musicVol * 0.5f;
	}


	public void PlayMusic() {
		musicMenu.Stop();
		music.PlayDelayed(0.5f);
	}


	public void StopMusic() {
		music.Stop();
		musicMenu.Stop();
	}

	public void PlayMusicMenu() {
		music.Stop();
		musicMenu.Play();
	}

}

}
