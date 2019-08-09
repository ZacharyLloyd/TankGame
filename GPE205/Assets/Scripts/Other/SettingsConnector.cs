using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsConnector : MonoBehaviour
{
    public bool isMulitplayerEnabled;
    public bool isMapRandom;
    public bool isMapSeeded;
    public bool isMapOfTheDay;
    public float musicVolume;
    public float sfxVolume;
    public int seed;
    public Slider musicSlider;
    public Slider sfxSlider;
    public Toggle multiplayerToggle;
    public Toggle seedMap;
    public TMP_InputField seedNumber;
    public Toggle randomMap;
    public Toggle mapOfTheDay;
    // Start is called before the first frame update
    void Start()
    {
        Settings.settingsInstance.musicSlider = musicSlider;
        Settings.settingsInstance.sfxSlider = sfxSlider;
        Settings.settingsInstance.multiplayerToggle = multiplayerToggle;
        Settings.settingsInstance.seedMap = seedMap;
        Settings.settingsInstance.seedNumber = seedNumber;
        Settings.settingsInstance.randomMap = randomMap;
        Settings.settingsInstance.mapOfTheDay = mapOfTheDay;
        SendSettingsData();
        Settings.settingsInstance.LoadSettings();
    }
    public void SendSettingsData()
    {
        Settings.settingsInstance.isMulitplayerEnabled = isMulitplayerEnabled;
        Settings.settingsInstance.isMapRandom = isMapRandom;
        Settings.settingsInstance.isMapSeeded = isMapSeeded;
        Settings.settingsInstance.isMapOfTheDay = isMapOfTheDay;
        Settings.settingsInstance.musicVolume = musicVolume;
        Settings.settingsInstance.sfxVolume = sfxVolume;
        Settings.settingsInstance.seed = seed;
    }
    public void SaveSettings()
    {
        SendSettingsData();
        Settings.settingsInstance.SaveSettings();
    }
    public void SetMultiplayerEnabled(bool multiplayerEnabled)
    {
        isMulitplayerEnabled = multiplayerEnabled;
    }
    //Set the music volume
    public void SetMusicVolume(float newMusicVolume)
    {
        musicVolume = newMusicVolume;
    }
    //Set the SFX volume
    public void SetSfxVolume(float newSfxVolume)
    {
        sfxVolume = newSfxVolume;
    }
    public void SetMapOfTheDay(bool motd)
    {
        isMapOfTheDay = motd;
    }
    public void SetRandomMap(bool random)
    {
        isMapRandom = random;
    }
    public void SetSeedMap(bool seeded)
    {
        isMapSeeded = seeded;
    }
}
