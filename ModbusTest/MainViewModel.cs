using EasyModbus;
using System.Threading;
using System.Threading.Tasks;

namespace ModbusTest
{
    public class MainViewModel : PrimeViewModel
    {
        private string _Weight;
        public string Weight { get => _Weight; set => SetProperty(ref _Weight,value); }

        ModbusClient client;

        public MainViewModel()
        {
            client = new ModbusClient("127.0.0.1", 502); // 192.168.0.254
            AsyncInit();
        }

        private async void AsyncInit()
        {
            ReadWeight();
        }

        private async Task ReadWeight()
        {
            while (true)
            {
                try
                {
                    decimal w = -1;

                    if (!client.Connected)
                        client.Connect();
                    else
                        w = ((decimal)client.ReadHoldingRegisters(10, 1)[0]) / 100;

                    Weight = w.ToString();

                }
                catch {}
                finally 
                {
                    await Task.Delay(3000);
                }

            }
        }
    }
}
