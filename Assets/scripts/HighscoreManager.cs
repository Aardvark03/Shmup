using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable()]
public class HighscoreEntry : IComparable {
    public int score;
    public string name;

    public HighscoreEntry(string _name, int _score) {
        score = _score;
        name = _name;
    }

    public int CompareTo(object obj)
    {
        if (obj is HighscoreEntry) {
            return this.score.CompareTo((obj as HighscoreEntry).score);
        }
        throw new ArgumentException("HighscoreEntry can only be compared to another HighscoreEntry");
    }
}

public class HighscoreManager {
    private HighscoreManager() {}

    private static HighscoreManager instance;
    private HighscoreEntry[] highscore;

    public static HighscoreManager Instance {
        get {
            if (instance == null) {
                instance = new HighscoreManager();
            }
            return instance;
        }
    }

    public void saveHighscore() {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/highscore.dat", FileMode.Create);

        formatter.Serialize(file, highscore);

        file.Close();
    }

    void loadHighscore() {
        if (!File.Exists(Application.persistentDataPath + "/highscore.dat")) {
            Debug.Log("No Highscore to Load");
          
            highscore = new HighscoreEntry[10];
            
            for (int i = 0; i < 10; i++) {
                highscore[i] = new HighscoreEntry("Empty", 0); 
            }

            return;
        }
        
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream file = File.Open(Application.persistentDataPath + "/highscore.dat", FileMode.Open); 
        highscore = (HighscoreEntry[]) formatter.Deserialize(file);
        file.Close();
    }

    public bool checkHighscore(int score) {
        loadHighscore();

        for (int i = 0; i < 10; i++) {
            if (highscore[i].score < score) {
                if (i != 9) {
                    continue;
                }
            }
            if (i == 0) {
                return false;
            }

            int rank;

            if (i == 9) {
                rank = i;
            } else {
                rank = i - 1;
            }

            for (int j = 1; j <= rank; j++) {
                highscore[j-1] = highscore[j];
            }
            highscore[rank] = new HighscoreEntry("Player", score);

            saveHighscore();
            
            return true;
        }
        return false;
    }

    public string getHighscoreTable() {
        loadHighscore(); 

        string table = "";
        for (int i = 9; i >= 0; i--) {
            HighscoreEntry current = highscore[i];
            table += current.name;
            table += ": ";
            table += current.score;
            table += "\n";
        }

        return table;
    }
}


