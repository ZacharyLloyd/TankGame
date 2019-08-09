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
    //Sending the data to the settings where they can update the ui
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
    //The the settings in the connector
    public void SaveSettings()
    {
        //Send the data to the settings
        SendSettingsData();
        //Save the new settings
        Settings.settingsInstance.SaveSettings();
    }
    //Set the multiplayer variable to be passed on
    public void SetMultiplayerEnabled(bool multiplayerEnabled)
    {
        isMulitplayerEnabled = multiplayerEnabled;
    }
    //Set the music volume to th variable to be passed on
    public void SetMusicVolume(float newMusicVolume)
    {
        musicVolume = newMusicVolume;
    }
    //Set the SFX volume to the variable to be passed on
    public void SetSfxVolume(float newSfxVolume)
    {
        sfxVolume = newSfxVolume;
    }
    //Set the map of the day variable to be passed on
    public void SetMapOfTheDay(bool motd)
    {
        isMapOfTheDay = motd;
    }
    //Set the random map variable to be passed on
    public void SetRandomMap(bool random)
    {
        isMapRandom = random;
    }
    //Set the seed map variable to be passed on
    public void SetSeedMap(bool seeded)
    {
        isMapSeeded = seeded;
    }
}
