using UnityEngine;

public struct BeatmapsDB
{
    public string SID;
    public string Title;
    public string Artist;
    public string Mapper;
    public string ImgDir;
    public string SongDir;
    public string SongFileName;
    public string Difficulty;
    public string PreviewTime;
    public string OsuFile;
    public string SongFolder;
    public string StarRating;

    public void strToObj(string mapDiff)
    {
        string[] data = mapDiff.Split("📂");
        SID = data[0];
        Title = data[1];
        Artist = data[2];
        Mapper = data[3];
        ImgDir = data[4];
        SongDir = data[5];
        SongFileName = data[6];
        Difficulty = data[7];
        PreviewTime = data[8];
        OsuFile = data[9];
        SongFolder = data[10];
    }

    public string objToStr()
    {
        return SID + "📂" + Title + "📂" + Artist + "📂" + Mapper + "📂" + ImgDir +
               "📂" + SongDir + "📂" + SongFileName + "📂" + Difficulty + "📂" + PreviewTime + "📂" + OsuFile + "📂" + SongFolder +"\n";
    }
}
