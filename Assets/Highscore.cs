using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    [SerializeField] string Name = "";
    private int Score = 0;
    private List<Tuple<string, int>> scores = new List<Tuple<string, int>>();
    private string savePath;
    [SerializeField] Transform ScoreParent;
    [SerializeField] TextMeshProUGUI ScorePrefab;
    [SerializeField] TextMeshProUGUI YourScore;
    [SerializeField] Transform SubmitPanel;
    [SerializeField] ScoreManager ScoreManager;

    void Start()
    {
        savePath = Application.persistentDataPath + "/scores.dat";
        LoadScores();
        Score = ScoreManager.Instance.Score;
        DisplayScores();
        YourScore.text = "Your score: " + Score;
    }

    public void AddScore()
    {
        if (Name == "") return;

        scores.Add(new Tuple<string, int>(Name, Score));
        scores.Sort((a, b) => b.Item2.CompareTo(a.Item2)); // Sort in descending order based on the score
        SaveScores();
        SubmitPanel.gameObject.SetActive(false);
        DisplayScores();
    }

    public void SetName(string name) { Name = name; }

    public void DisplayScores()
    {
        foreach (Transform child in ScoreParent)
        {
            Destroy(child.gameObject);
        }

        // Clear the child list
        ScoreParent.DetachChildren();

        foreach(var score in scores)
        {
            var scoreGameObject = Instantiate(ScorePrefab, ScoreParent);
            scoreGameObject.text = score.Item1 + ": " + score.Item2;
        }
    }

    public List<Tuple<string, int>> GetScores()
    {
        return scores;
    }

    private void SaveScores()
    {
        ScoreData data = new ScoreData();
        data.scores = scores;

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fileStream = File.Create(savePath);

        formatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    private void LoadScores()
    {
        if (File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = File.Open(savePath, FileMode.Open);

            try
            {
                ScoreData data = (ScoreData)formatter.Deserialize(fileStream);
                scores = data.scores;
            }
            catch (Exception e)
            {
                Debug.LogError("Error loading scores: " + e.Message);
            }

            fileStream.Close();
        }
    }
}

[Serializable]
public class ScoreData
{
    public List<Tuple<string, int>> scores;
}
