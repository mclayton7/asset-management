namespace AssetManagement.Hid;

public class InputService
{
    public event EventHandler<string>? RfidRecieved;
    public event EventHandler<string>? BarcodeScanned;
}