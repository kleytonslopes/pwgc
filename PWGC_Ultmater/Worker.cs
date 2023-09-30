using Engine;
using Engine.Entities;

namespace PWGC_Ultmater
{
    public class Worker
    {
        // This method will be called when the thread is started.
        public void DoWork()
        {
            while (!_shouldStop)
            {

                if (Connection.session == null)
                    Connection.session = Connection.OpenSessison();

                if (Connection.session != null)
                    GlobalSystem.config = Config.GetAllConfig();
            }
        }
        public void RequestStop()
        {
            _shouldStop = true;
        }
        // Volatile is used as hint to the compiler that this data
        // member will be accessed by multiple threads.
        private volatile bool _shouldStop;
    }
}
