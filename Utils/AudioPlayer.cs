using NAudio.Wave;
using System;

public class Mp3Player
{
    private WaveOutEvent outputDevice;
    private Mp3FileReader audioFile;
    private string currentFilePath;
    public bool IsRepeating { get; set; } // 繰り返し再生を制御するプロパティ

    public void PlayMp3File(string filePath)
    {
        currentFilePath = filePath; // 現在のファイルパスを保存
        Play(); // 再生の処理を共通化
    }

    private void Play()
    {
        DisposeWave(); // 既存の再生を停止し、リソースを解放します

        outputDevice = new WaveOutEvent();
        audioFile = new Mp3FileReader(currentFilePath);
        outputDevice.Init(audioFile);
        outputDevice.Play();
        outputDevice.PlaybackStopped += OnPlaybackStopped;
    }

    private void OnPlaybackStopped(object sender, StoppedEventArgs args)
    {
        DisposeWave(); // リソースのクリーンアップ

        if (IsRepeating) // 繰り返し再生が有効な場合、再生を再開します
        {
            Play();
        }
    }

    public void Stop()
    {
        IsRepeating = false; // 繰り返し再生を無効化
        DisposeWave(); // 再生の停止とリソースの解放
    }

    public void DisposeWave()
    {
        if (outputDevice != null)
        {
            outputDevice.Stop();
            outputDevice.Dispose();
            outputDevice = null;
        }
        if (audioFile != null)
        {
            audioFile.Dispose();
            audioFile = null;
        }
    }
}
