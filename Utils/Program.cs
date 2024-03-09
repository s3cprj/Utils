using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // プロセスの実行
        ScriptRunner process = new ScriptRunner();
        await process.RunAsync("mydata/sound.exe");
        Thread.Sleep(10000);
        process.Stop();
        Console.WriteLine("here");
        Thread.Sleep(5000);

        // ボリューム設定がコメントアウトされています
        VolumeController vc = new VolumeController();
        vc.SetVolume(30);

        // 音再生
        var player = new Mp3Player();
        player.IsRepeating = true; // 繰り返し再生を有効にする
        player.PlayMp3File("mydata/Warning.mp3");
        Thread.Sleep(10000);
        player.Stop();
        Thread.Sleep(5000);

        // CSVの読み取り
        for (int i = 0; i < 5; i++) {
            string filePath = "mydata/test-data.csv"; // CSVファイルのパスを指定
            int numberOfLines = 15; // 読み込む行数
            double threshold = 0.5; // trueの割合の閾値

            bool result = FileUtil.CheckTruePercentageInRecentLines(filePath, numberOfLines, threshold);
            Console.WriteLine(result);
            Thread.Sleep(5000);
        }
    }
}
