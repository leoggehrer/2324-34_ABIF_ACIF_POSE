namespace MobilePhone.Logic
{
    /// <summary>
    /// Simulation of a simple mobile phone
    /// </summary>
    public class MobilePhone
    {
        #region fields
        private string _name = string.Empty;
        private string _phoneNumber = string.Empty;
        private string _lastCalledNumber = string.Empty;
        private int _secondsActive = 0;
        private int _secondsPassive = 0;
        private int _centsToPay = 0;

        private DateTime _startCallTime;
        private MobilePhone? _callFrom = null;
        private MobilePhone? _callTo = null;
        private bool _inProcess = false;
        #endregion fields

        /// <summary>
        /// Constructors
        /// </summary>
        public MobilePhone(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public MobilePhone(string phoneNumber, string? name)
            :this(phoneNumber)
        {
            Name = name ?? string.Empty;
        }

        #region properties
        public string Name
        {
            get { return _name; }
            set 
            {
                if (string.IsNullOrEmpty(value) || char.IsLetter(value[0]) == false || value.Length < 2)
                {
                    _name = "ERROR";
                }
                else
                {
                    _name = value;
                }
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            private set 
            {
                _phoneNumber = value;
            }
        }

        public string LastCalledNumber
        {
            get { return _lastCalledNumber; }
        }

        public int SecondsActive
        {
            get { return _secondsActive; }
        }

        public int SecondsPassive
        {
            get { return _secondsPassive; }
        }

        public int CentsToPay
        {
            get 
            { 
                return _centsToPay; 
            }
        }
        private bool IsConnected
        {
            get
            {
                return _callTo != null || _callFrom != null;
            }
        }

        #endregion properties

        /// <summary>
        /// Mobile initiates a call to a passive mobile phone. Time starts counting
        /// for both mobiles.
        /// </summary>
        /// <param name="passive">passive mobile</param>
        /// <returns>Returns true when phone call started correctly. False when active or passive phone is already busy (already talking).</returns>
        public bool StartCallTo(MobilePhone passive)
        {
            bool result = false;

            if (_inProcess == false
                && IsConnected == false
                && passive.IsConnected == false)
            {
                _inProcess = true;
                passive.StartCallFrom(this);
                _callFrom = null;
                _callTo = passive;
                _startCallTime = DateTime.Now;
                _lastCalledNumber = passive.PhoneNumber;
                result = true;
                _inProcess = false;
            }
            return result;
        }

        /// <summary>
        /// Starts the call for the passive mobile
        /// </summary>
        /// <param name="other"></param>
        private bool StartCallFrom(MobilePhone other)
        {
            bool result = false;

            if (_inProcess == false
                && IsConnected == false
                && other.IsConnected == false)
            {
                _inProcess = true;
                other.StartCallTo(this);
                _callFrom = other;
                _callTo = null;
                _startCallTime = DateTime.Now;
                _lastCalledNumber = other.PhoneNumber;
                result = true;
                _inProcess = false;
            }
            return result;
        }

        /// <summary>
        /// End the call and also the call by the other mobile. Calculate duration and
        /// by the active caller the costs of the call.
        /// </summary>
        /// <returns>false, if there is no call pending</returns>
        public bool StopCall()
        {
            bool result = false;

            if (_inProcess == false && IsConnected)
            {
                DateTime stopCallTime = DateTime.Now;
                int duration = (int)((stopCallTime - _startCallTime).TotalSeconds * 20);
                int payUnits = (duration / 30);

                payUnits += (duration % 30) != 0 ? 1 : 0;

                _inProcess = true;
                if (_callTo != null)
                {
                    _secondsActive += duration;
                    _centsToPay += payUnits * 4;
                    _callTo.StopCall();
                    _callTo = null;
                }
                if (_callFrom != null)
                {
                    _secondsPassive += duration;
                    _callFrom.StopCall();
                    _callFrom = null;
                }
                result = true;
            }
            _inProcess = false;
            return result;
        }
    }
}
