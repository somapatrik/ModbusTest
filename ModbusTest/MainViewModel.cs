using EasyModbus;
using System.Threading;
using System.Threading.Tasks;

namespace ModbusTest
{
    public class MainViewModel : PrimeViewModel
    {
        private string _Weight;
        public string Weight { get => _Weight; set => SetProperty(ref _Weight,value); }


        private ModbusClient _client;
        public ModbusClient client { get => _client; set => SetProperty(ref _client,value); }


        private bool _Connected;
        public bool Connected { get => _Connected; set => SetProperty(ref _Connected, value); }


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
                decimal w = -1;
                Connected = client.Available(200);
                try
                {
                    

                    if (!client.Available(200) || !client.Connected)
                        client.Connect();
                    else
                        w = ((decimal)client.ReadHoldingRegisters(10, 1)[0]) / 100;
                }
                catch {}
                finally 
                {
                    Weight = w.ToString();
                    await Task.Delay(3000);
                }

            }
        }
    }
}
