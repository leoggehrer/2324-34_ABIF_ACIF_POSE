namespace MobilePhone.Logic
{
    /// <summary>
    /// Simulation of a simple mobile phone
    /// </summary>
    public class MobilePhone
    {
        #region fields
        #endregion fields

        /// <summary>
        /// Constructors
        /// </summary>
        public MobilePhone(string phoneNumber)
        {
        }

        public MobilePhone(string phoneNumber, string name):this(phoneNumber)
        {
        }

        /// <summary>
        /// Properties
        /// </summary>

        public string PhoneNumber
        {
            get { return null; }
            set {  }
        }

        public string LastCalledNumber
        {
            get { return null; }
            set { }
        }

        public int SecondsActive
        {
            get { return -1; }
        }

        public int SecondsPassive
        {
            get { return -1; }
        }

        public int CentsToPay
        {
            get 
            { 
                return -1; 
            }
        }

        /// <summary>
        /// With Errorhandling (see taskdescription)
        /// </summary>
        public string Name
        {
            get { return null; }
            set { }
        }


        /// <summary>
        /// Mobile initiates a call to a passive mobile phone. Time starts counting
        /// for both mobiles.
        /// </summary>
        /// <param name="passive">passive mobile</param>
        /// <returns>Returns true when phone call started correctly. False when active or passive phone is already busy (already talking).</returns>
        public bool StartCallTo(MobilePhone passive)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Starts the call for the passive mobile
        /// </summary>
        /// <param name="other"></param>
        private bool StartCallFrom(MobilePhone other)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// End the call and also the call by the other mobile. Calculate duration and
        /// by the active caller the costs of the call.
        /// </summary>
        /// <returns>false, if there is no call pending</returns>
        public bool StopCall()
        {
            throw new NotImplementedException();
        }
    }
}
