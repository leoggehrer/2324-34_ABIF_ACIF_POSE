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
        private MobilePhone? _other = null;
        private MobilePhone? _passive = null;
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
            set 
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

            if (_other == null 
                && _passive == null 
                && passive != this
                && passive.StartCallFrom(this) == true)
            {
                result = true;
                _passive = passive;
                _startCallTime = DateTime.Now;
                _lastCalledNumber = passive.PhoneNumber;
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

            if (_other == null 
                && _passive == null 
                && other != this
                && other.StartCallTo(this) == true)
            {
                result = true;
                _other = other;
                _startCallTime = DateTime.Now;
                _lastCalledNumber = other.PhoneNumber;
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

            if (_passive != null || _other != null)
            {
                DateTime stopCallTime = DateTime.Now;

                result = true;
                if (_passive != null)
                {
                    _secondsPassive += (int)(stopCallTime - _startCallTime).TotalSeconds;
                    _passive.StartCallFrom(this);
                    _passive = null;
                }
                if (_other != null)
                {
                    _secondsActive += (int)(stopCallTime - _startCallTime).TotalSeconds;
                    _centsToPay = _secondsActive / 60;
                    _other.StartCallFrom(this);
                    _other = null;
                }
            }
            return result;
        }
    }
}
