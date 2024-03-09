using NAudio.CoreAudioApi;

class VolumeController
{
    private MMDevice GetDefaultDevice()
    {
        MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
        return DevEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
    }

    public void SetVolume(int value)
    {
        MMDevice device = GetDefaultDevice();
        // ミュートを強制解除
        device.AudioEndpointVolume.Mute = false;
        // 音量を変更
        device.AudioEndpointVolume.MasterVolumeLevelScalar = ((float)value / 100.0f);
    }

    public void Unmute()
    {
        // ミュートを強制解除
        MMDevice device = GetDefaultDevice();
        device.AudioEndpointVolume.Mute = false;
    }
}
