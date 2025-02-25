using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics;
using System.IO;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    int characterIndex;
    public GameObject spawnPoint;
    int[] otherPlayers;
    int index;

    [SerializeField] private PlayerMovement playerMovement;

    private const string textFileName = "playerNames";

    void Start()
    {
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        GameObject mainCharacter = Instantiate(playerPrefabs[characterIndex], 
            spawnPoint.transform.position, Quaternion.identity);
        mainCharacter.GetComponent<NameScript>().SetPlayerName(
            PlayerPrefs.GetString("PlayerName"));

        PlayManager.instance.SetCharacter(mainCharacter);
        //playerMovement.SetCharacter(mainCharacter);

        otherPlayers = new int[PlayerPrefs.GetInt("PlayerCount")];


        PlayManager.instance.SetMaxPlayerIndex(otherPlayers.Length+1);

        string[] nameArray = ReadLinesFromFile(textFileName);
        for(int i=0; i<otherPlayers.Length; i++)
        {
            spawnPoint.transform.position += new Vector3(0.02f, 0, 0.02f);
            index = Random.Range(0, playerPrefabs.Length-1);
            GameObject character = Instantiate(playerPrefabs[index], 
                spawnPoint.transform.position, Quaternion.identity);
            character.GetComponent<NameScript>().SetPlayerName(
                nameArray[Random.Range(0, nameArray.Length-1)]);

            PlayManager.instance.SetCharacter(character);
        }
    }

   string[] ReadLinesFromFile(string fileName)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(fileName);

        if(textAsset !=null)
        return textAsset.text.Split(new[] {'\r', '\n'}, 
        System.StringSplitOptions.RemoveEmptyEntries);

        else
            Debug.LogError("File not found: " + fileName); return new string[0];

    }
}