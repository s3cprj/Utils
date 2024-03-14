using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public static class SettingsManager
{
    private static string filePath = "mydata/Settings.json";

    public static void SaveSettings(Dictionary<string, string> settings)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(settings, options);
        File.WriteAllText(filePath, jsonString);
    }

    public static Dictionary<string, string> LoadSettings()
    {
        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);
        }
        return new Dictionary<string, string>();
    }

    // 特定のキーに対するバリューを取得する
    public static string GetSettingValueByKey(string key)
    {
        var settings = LoadSettings();
        if (settings.ContainsKey(key))
        {
            return settings[key];
        }
        else
        {
            return null; // キーが存在しない場合はnull
        }
    }

    // 特定のキーの値を変更する（キーがなければ追加）
    public static void UpdateSettingValueByKey(string key, string newValue)
    {
        var settings = LoadSettings();
        settings[key] = newValue; // 存在するキーの値を更新、または新しいキーを追加
        SaveSettings(settings); // 更新後の設定をファイルに保存
    }
}
